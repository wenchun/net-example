// Copyright (c) Microsoft Corporation.  All rights reserved.

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Diagnostics;
using System.Text;

namespace Microsoft.Data.EFLazyLoading
{
    /// <summary>
    /// Represents a collection of entity objects with lazy loading.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity</typeparam>
    public class LazyEntityCollection<TEntity> : ICollection<TEntity>, IListSource
        where TEntity : class, ILazyEntityObject, IEntityWithRelationships, IEntityWithKey, new()
    {
        private EntityCollection<TEntity> _wrapped;
        private bool _isAttached;

        /// <summary>
        /// Creates a new instance of LazyEntityCollection
        /// </summary>
        public LazyEntityCollection()
        {
            _wrapped = new EntityCollection<TEntity>();
            _isAttached = false;
        }

        internal LazyEntityCollection(EntityCollection<TEntity> wrapped, bool isAttached)
        {
            _wrapped = wrapped;
            _isAttached = isAttached;
        }

        /// <summary>
        /// Wrapped EntityCollection object.
        /// </summary>
        [Browsable(false)]
        public EntityCollection<TEntity> Wrapped
        {
            get { return _wrapped; }
        }

        #region IListSource

        bool IListSource.ContainsListCollection
        {
            get
            {
                EnsureLoaded();
                return ((IListSource)_wrapped).ContainsListCollection;
            }
        }

        IList IListSource.GetList()
        {
            EnsureLoaded();
            return ((IListSource)_wrapped).GetList();
        }

        #endregion

        private void EnsureLoaded()
        {
            if (!_isAttached)
                return;
            if (!_wrapped.IsLoaded)
            {
                _wrapped.Load();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            EnsureLoaded();
            return _wrapped.GetEnumerator();
        }

		/// <summary>Returns an <see cref="T:System.Collections.IEnumerator" /> that iterates through the set of values cached by the collection.</summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> that iterates through the set of values cached by the collection.</returns>
        public IEnumerator<TEntity> GetEnumerator()
        {
            EnsureLoaded();
            return _wrapped.GetEnumerator();
        }

        /// <summary>
        /// Removes all entities from the collection.
        /// </summary>
        public void Clear()
        {
            EnsureLoaded();
            _wrapped.Clear();
        }

	    /// <summary>Determines whether a specific object is in the collection.</summary>
        /// <returns>true if entity is found in the collection; otherwise, false.</returns>
        /// <param name="item">The object to locate in the collection.</param>
        public bool Contains(TEntity item)
        {
            EnsureLoaded();
            return _wrapped.Contains(item);
        }

	    /// <summary>
        /// Copies the entire collection to an array, starting at the specified index of the target array.
        /// </summary>
		/// <param name="array">The array to copy to.</param>
        /// <param name="arrayIndex">The zero-based index in the array at which copying begins.</param>
        public void CopyTo(TEntity[] array, int arrayIndex)
        {
            EnsureLoaded();
            _wrapped.CopyTo(array, arrayIndex);
        }

	    /// <summary>
        /// Gets the number of elements contained in the collection.
        /// </summary>
        /// <returns>
        /// The number of elements contained in the collection.
        /// </returns>
        public int Count
        {
            get
            {
                EnsureLoaded();
                return _wrapped.Count;
            }
        }

	    /// <summary>
        /// Gets a value indicating whether the collection is read-only.
        /// </summary>
        /// <returns>Always returns false.</returns>
        public bool IsReadOnly
        {
            get { return _wrapped.IsReadOnly; }
        }

	    /// <summary>Removes an entity from the collection.</summary>
		/// <returns>true if item was successfully removed; otherwise, false. </returns>
        /// <param name="item">The object to remove from the collection.</param>
        public bool Remove(TEntity item)
        {
            EnsureLoaded();
            return _wrapped.Remove(item);
        }

        /// <summary>
        /// Determines whether collection has already been loaded.
        /// </summary>
        public bool IsLoaded
        {
            get { return _wrapped.IsLoaded; }
        }

		/// <summary>Gets the name of the relationship in which this collection is participating.</summary>
        /// <returns>The name of the relationship in which this collection is participating. The relationship name is not namespace qualified. </returns>
        public string RelationshipName
        {
            get { return _wrapped.RelationshipName; }
        }

		/// <summary>Gets the name of the relationship source role used to generate this collection.</summary>
		/// <returns>The name of the relationship source role used to generate this collection.</returns>
        public string SourceRoleName
        {
            get { return _wrapped.SourceRoleName; }
        }

		/// <summary>Gets the name of the relationship target role used to generate this collection.</summary>
		/// <returns>The name of the relationship target role used to generate this collection.</returns>
        public string TargetRoleName
        {
            get { return _wrapped.TargetRoleName; }
        }

        /// <summary>
        /// Adds an entity object into the collection.
        /// </summary>
        /// <param name="item">The object to add to the collection.</param>
        public void Add(TEntity item)
        {
            EnsureLoaded();
            _wrapped.Add(item);
        }

        /// <summary>Loads related entities into the local collection.</summary>
        /// <param name="entities">Related entities.</param>
        public void Attach(IEnumerable<TEntity> entities)
        {
            EnsureLoaded();
            _wrapped.Attach(entities);
        }

        /// <summary>
        /// Returns an object query that can be used to load objects in the collection.
        /// </summary>
        /// <returns>ObjectQuery</returns>
        public ObjectQuery<TEntity> CreateSourceQuery()
        {
            return _wrapped.CreateSourceQuery();
        }

		/// <summary>
        /// Loads the related entity objects into the local collection.
        /// </summary>
        public void Load()
        {
            _wrapped.Load();
        }

        /// <summary>
        /// Loads the related entity objects into the local collection using the specified merge option.
        /// </summary>
        /// <param name="mergeOption">Merge option.</param>
        public void Load(MergeOption mergeOption)
        {
            _wrapped.Load(mergeOption);
        }

        /// <summary>
        /// Initializes collection by populating it with stubs instead of fully materialized
        /// objects.
        /// </summary>
        /// <returns>Collection instance.</returns>
        public LazyEntityCollection<TEntity> LoadStubs()
        {
            if (!IsLoaded)
                _wrapped.Attach(CreateSourceQuery().AsStubs());
            return this;
        }
    }
}
