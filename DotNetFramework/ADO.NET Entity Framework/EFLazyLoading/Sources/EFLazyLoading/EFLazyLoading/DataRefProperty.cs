// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Data.Objects.DataClasses;
using System.Data.Objects;

namespace Microsoft.Data.EFLazyLoading
{
    /// <summary>
    /// Data property class that accesses reference (many-to-one or one-to-one) properties
    /// </summary>
    /// <typeparam name="TParent">Entity class</typeparam>
    /// <typeparam name="TData">Data class</typeparam>
    /// <typeparam name="TTarget">Referenced class</typeparam>
    public class DataRefProperty<TParent, TData, TTarget>
        where TData : class, new()
        where TParent : ILazyEntityObject, IEntityWithKey
        where TTarget : class, ILazyEntityObject, IEntityWithRelationships, IEntityWithKey, new()
    {
        private string _assocName;
        private string _relatedEnd;
        private string _propertyName;

        /// <summary>
        /// Initializes new instance of a reference property.
        /// </summary>
        /// <param name="assocName">Fully qualified name of the association</param>
        /// <param name="relatedEnd">Name of the related end.</param>
        /// <param name="propertyName">Name of the navigation property.</param>
        public DataRefProperty(string assocName, string relatedEnd, string propertyName)
        {
            _assocName = assocName;
            _relatedEnd = relatedEnd;
            _propertyName = propertyName;
        }

        /// <summary>
        /// Get the current property value, initializes data object if necessary.
        /// </summary>
        /// <param name="parent">Entity object</param>
        public TTarget Get(TParent parent)
        {
            parent.EnsureDataLoaded(PropertyName, LoadReason.RelationshipNavigation);
            IEntityWithRelationships ewr = (IEntityWithRelationships)parent;
            EntityReference<TTarget> related = ewr.RelationshipManager.GetRelatedReference<TTarget>(_assocName, _relatedEnd);
            if (related.Value != null)
                return related.Value;

            if (related.EntityKey == null)
                return null;

            // try to get the context from the object
            LazyObjectContext contextToUse = parent.Context;

            // if it's not there, use an alternative (but slower) method:
            if (contextToUse == null)
            {
                ObjectQuery<TTarget> sourceQuery = related.CreateSourceQuery();
                contextToUse = sourceQuery.Context as LazyObjectContext;
            }

            // TODO: use something related to MetadataWorkspace, not global
            IObjectTypeCache otc = LazyObjectContext.ObjectTypeCache;
            TTarget stub;

            if (otc.HasSubclasses(typeof(TTarget), contextToUse.MetadataWorkspace))
            {
                Func<object> resultTypeCreator;

                if (!otc.TryGetTypeForKey(related.EntityKey, out resultTypeCreator))
                {
                    // type for object is not known, delegate to ObjectServices to do full load
                    // and resolve the type
                    related.Load();
                    contextToUse.RaiseObjectLoaded(related.Value, LoadReason.UnknownConcreteType, null);
                    otc.SetTypeForKey(related.EntityKey, related.Value.GetType());
                    return related.Value;
                }
                else
                {
                    // create cached type
                    stub = (TTarget)resultTypeCreator();
                }
            }
            else
            {
                // type is not polymorphic
                stub = new TTarget();
            }

            StubHelper.AttachStub(contextToUse, stub, related.EntityKey, parent, this.PropertyName);
            related.Value = stub;

            return stub;
        }

        /// <summary>
        /// Set the property to the specified value, initializes data object if necessary.
        /// </summary>
        /// <param name="parent">Entity object</param>
        /// <param name="value">Value to be set</param>
        public void Set(TParent parent, TTarget value)
        {
            parent.EnsureDataLoaded(PropertyName, LoadReason.RelationshipNavigation);
            IEntityWithRelationships ewr = (IEntityWithRelationships)parent;
            EntityReference<TTarget> related = ewr.RelationshipManager.GetRelatedReference<TTarget>(_assocName, _relatedEnd);
            related.Value = value;
        }

        /// <summary>
        /// Name of the Navigation Property.
        /// </summary>
        public string PropertyName
        {
            get { return _propertyName; }
        }
    }
}

