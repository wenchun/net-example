// Copyright (c) Microsoft Corporation.  All rights reserved.

using System.Data.Objects.DataClasses;

namespace Microsoft.Data.EFLazyLoading
{
    /// <summary>
    /// Data property class that accesses collection properties
    /// </summary>
    /// <typeparam name="TParent">Entity class</typeparam>
    /// <typeparam name="TData">Data class</typeparam>
    /// <typeparam name="TTarget">Referenced class (collection item type)</typeparam>
    public class DataCollectionProperty<TParent, TData, TTarget>
        where TData : class, new()
        where TParent : ILazyEntityObject, IEntityWithKey
        where TTarget : class, ILazyEntityObject, IEntityWithRelationships, IEntityWithKey, new()
    {
        private string _assocName;
        private string _relatedEnd;
        private string _propertyName;

        /// <summary>
        /// Initializes new instance of a collection property.
        /// </summary>
        /// <param name="assocName">Fully qualified name of the association</param>
        /// <param name="relatedEnd">Name of the related end.</param>
        /// <param name="propertyName">Name of the navigation property.</param>
        public DataCollectionProperty(string assocName, string relatedEnd, string propertyName)
        {
            _assocName = assocName;
            _relatedEnd = relatedEnd;
            _propertyName = propertyName;
        }

        /// <summary>
        /// Get the related collection and wraps it with LazyEntityCollection object, initializes data object if necessary.
        /// </summary>
        /// <param name="parent">Entity object</param>
        public LazyEntityCollection<TTarget> Get(TParent parent)
        {
            parent.EnsureDataLoaded(PropertyName, LoadReason.RelationshipNavigation);
            IEntityWithRelationships ewr = (IEntityWithRelationships)parent;
            EntityCollection<TTarget> related = ewr.RelationshipManager.GetRelatedCollection<TTarget>(_assocName, _relatedEnd);
            return new LazyEntityCollection<TTarget>(related, parent.IsAttached);
        }

        /// <summary>
        /// Set the property to the specified value, initializes data object if necessary.
        /// </summary>
        /// <param name="parent">Entity object</param>
        /// <param name="value">Value to be set</param>
        public void Set(TParent parent, LazyEntityCollection<TTarget> value)
        {
            parent.EnsureDataLoaded(PropertyName, LoadReason.RelationshipNavigation);
            IEntityWithRelationships ewr = (IEntityWithRelationships)parent;
            ewr.RelationshipManager.InitializeRelatedCollection<TTarget>(_assocName, _relatedEnd, value.Wrapped);
        }

        /// <summary>
        /// Property name
        /// </summary>
        public string PropertyName
        {
            get { return _propertyName; }
        }
    }
}
