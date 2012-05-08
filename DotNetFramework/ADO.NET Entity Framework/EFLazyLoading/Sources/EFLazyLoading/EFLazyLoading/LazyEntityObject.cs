// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

namespace Microsoft.Data.EFLazyLoading
{
    /// <summary>
    /// Base class for entity objects that support lazy loading.
    /// </summary>
    public abstract class LazyEntityObject : ILazyEntityObject, IEntityWithChangeTracker, IEntityWithKey, IEntityWithRelationships, INotifyPropertyChanged, INotifyPropertyChanging, IEditableObject
    {
        private LazyObjectContext _context;
        private IEntityChangeTracker _changeTracker;
        private RelationshipManager _relationshipManager;
        private EntityKey _entityKey;
        private ILazyEntityDataObject _dataObject;
        private ILazyEntityDataObject _oldDataObject;
        private PropertyChangingEventHandler _propertyChangingEventHandler;
        private PropertyChangedEventHandler _propertyChangedEventHandler;

        #region ILazyEntityObject

        LazyObjectContext ILazyEntityObject.Context
        {
            get { return _context; }
            set { _context = value; }
        }

        void ILazyEntityObject.ReportPropertyChanging(string name)
        {
            if (_changeTracker != null)
                _changeTracker.EntityMemberChanging(name);
            if (_propertyChangingEventHandler != null)
                _propertyChangingEventHandler(this, new PropertyChangingEventArgs(name));
        }

        void ILazyEntityObject.ReportPropertyChanged(string name)
        {
            if (_changeTracker != null)
                _changeTracker.EntityMemberChanged(name);
            if (_propertyChangedEventHandler != null)
                _propertyChangedEventHandler(this, new PropertyChangedEventArgs(name));
        }

        private ILazyEntityDataObject EnsureDataLoaded(string propertyName, LoadReason reason)
        {
            if (_dataObject == null)
            {
                // if the object is a stub, it must have a context attached to it and a key, only then we can load it
                // otherwise it is not a stub (is in the process of being fully loaded or created)
                if (_context != null && _entityKey != null)
                {
                    _dataObject = CreateDataObject();
                    _context.Refresh(RefreshMode.StoreWins, this);
                    _context.RaiseObjectLoaded(this, reason, propertyName);
                    _context.LazyLoadCounter++;
                }
                else
                {
                    _dataObject = CreateDataObject();
                }
            }
            return _dataObject;
        }

        ILazyEntityDataObject ILazyEntityObject.EnsureDataLoaded(string propertyName, LoadReason reason)
        {
            return EnsureDataLoaded(propertyName, reason);
        }

        void ILazyEntityObject.ResetData()
        {
            _dataObject = null;
        }

        bool ILazyEntityObject.IsAttached
        {
            get { return _changeTracker != null; }
        }

        #endregion

        #region IEntityWithChangeTracker

        void IEntityWithChangeTracker.SetChangeTracker(IEntityChangeTracker changeTracker)
        {
            _changeTracker = changeTracker;
        }

        #endregion

        #region IEntityWithKey

        System.Data.EntityKey IEntityWithKey.EntityKey
        {
            get { return _entityKey; }
            set { _entityKey = value; }
        }

        #endregion

        #region IEntityWithRelationships

        RelationshipManager IEntityWithRelationships.RelationshipManager
        {
            get
            {
                if (_relationshipManager == null)
                    _relationshipManager = RelationshipManager.Create(this);
                return _relationshipManager;
            }
        }

        #endregion

        #region INotifyProperty{Changing,Changed}

        event PropertyChangingEventHandler INotifyPropertyChanging.PropertyChanging
        {
            add { _propertyChangingEventHandler += value; }
            remove { _propertyChangingEventHandler -= value; }
        }
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add { _propertyChangedEventHandler += value; }
            remove { _propertyChangedEventHandler -= value; }
        }

        #endregion

        #region IEditableObject

        void IEditableObject.BeginEdit()
        {
            //if (_oldDataObject != null)
            //    throw new InvalidOperationException("Cannot nest IEditableObject.BeginEdit() calls");
            EnsureDataLoaded(null, LoadReason.BeginEdit);
            _oldDataObject = _dataObject.Copy();
        }

        void IEditableObject.CancelEdit()
        {
            if (_oldDataObject == null)
                throw new InvalidOperationException("Calling IEditableObject.CancelEdit() without prior BeginEdit() is not allowed.");

            _dataObject = _oldDataObject;
            _oldDataObject = null;
        }

        void IEditableObject.EndEdit()
        {
            if (_oldDataObject == null)
                throw new InvalidOperationException("Calling IEditableObject.EndEdit() without prior BeginEdit() is not allowed.");
            _oldDataObject = null;
        }

        #endregion

        /// <summary>
        /// Initializes data object. Must be overridden by entity class.
        /// </summary>
        /// <returns>Initialized data object</returns>
        protected internal abstract ILazyEntityDataObject CreateDataObject();
    }
}
