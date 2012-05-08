// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Data;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

namespace Microsoft.Data.EFLazyLoading
{
    /// <summary>
    /// Extends ObjectContext to support lazy loading.
    /// </summary>
    public abstract class LazyObjectContext : ObjectContext
    {
        private static IObjectTypeCache _objectTypeCache = new ObjectTypeCacheImpl();

        /// <summary>
        /// Implementation of <see cref="IObjectTypeCache" /> interface for resolving EntityKey to concrete type mapping.
        /// </summary>
        public static IObjectTypeCache ObjectTypeCache
        {
            get { return _objectTypeCache; }
            set { _objectTypeCache = value; }
        }

        /// <summary>
        /// Initializes new instance of <see cref="LazyObjectContext"/>
        /// </summary>
        /// <param name="connectionString">Connection string</param>
        /// <param name="defaultContainerName">Default EntityContainer name</param>
        protected LazyObjectContext(string connectionString, string defaultContainerName)
            : base(connectionString, defaultContainerName)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="LazyObjectContext"/>
        /// </summary>
        /// <param name="connection">Entity Connection</param>
        /// <param name="defaultContainerName">Default EntityContainer name</param>
        protected LazyObjectContext(EntityConnection connection, string defaultContainerName)
            : base(connection, defaultContainerName)
        {
        }

        /// <summary>
        /// Number of stub objects creating during the lifetime of this <see cref="LazyObjectContext"/>
        /// </summary>
        public int StubCounter { get; set; }

        /// <summary>
        /// Number of lazy load operations performed during the lifetime of this <see cref="LazyObjectContext"/>
        /// </summary>
        public int LazyLoadCounter { get; set; }

        /// <summary>
        /// Occurs after new stub object has been created.
        /// </summary>
        public event EventHandler<StubCreatedEventArgs> StubCreated;

        /// <summary>
        /// Occurs after object has been loaded as a result of accessing a property or navigating a relationship.
        /// </summary>
        public event EventHandler<ObjectLoadedEventArgs> ObjectLoaded;

        internal void RaiseStubCreatedObject(IEntityWithKey stubObject, IEntityWithKey sourceObject, string navigationProperty)
        {
            if (StubCreated != null)
            {
                StubCreated(this, new StubCreatedEventArgs() 
                { 
                    StubObject = stubObject,
                    SourceObject = sourceObject,
                    NavigationProperty = navigationProperty
                });
            }
        }

        internal void RaiseObjectLoaded(IEntityWithKey entityObject, LoadReason loadReason, string propertyName)
        {
            if (ObjectLoaded != null)
            {
                ObjectLoaded(this, new ObjectLoadedEventArgs() 
                { 
                    EntityObject = entityObject, 
                    Reason = loadReason, 
                    PropertyName = propertyName 
                });
            }
        }

        /// <summary>
        /// Resets data of a specified entity object back to uninitialized state.
        /// </summary>
        /// <param name="entity">Entity object</param>
        /// <remarks>This effectively converts a loaded object back to a stub. Object will load itself again on any property access.</remarks>
        public void Reset(ILazyEntityObject entity)
        {
            ObjectStateEntry ose = this.ObjectStateManager.GetObjectStateEntry(entity);
            if (ose.State != EntityState.Unchanged)
                throw new InvalidOperationException("Can only reset unchanged objects.");

            // set the context, in case the object didn't have it - will be needed for lazy loading
            entity.Context = this; 
            entity.ResetData();
        }

        /// <summary>
        /// Resets data of a all unchanged entity objects in the contexts.
        /// </summary>
        /// <seealso cref="Reset"/>
        public void ResetAllUnchangedObjects()
        {
            foreach (ObjectStateEntry ose in this.ObjectStateManager.GetObjectStateEntries(EntityState.Unchanged))
            {
                ILazyEntityObject leo = ose.Entity as ILazyEntityObject;
                if (leo == null)
                    continue;
                // set the context, in case the object didn't have it - will be needed for lazy loading
                leo.Context = this;
                leo.ResetData();
            }
        }
    }
}
