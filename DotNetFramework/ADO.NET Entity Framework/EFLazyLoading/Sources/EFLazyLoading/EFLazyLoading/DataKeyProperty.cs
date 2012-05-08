// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Data.Objects.DataClasses;

namespace Microsoft.Data.EFLazyLoading
{
    /// <summary>
    /// Data property class that accesses key properties
    /// </summary>
    /// <typeparam name="TParent">Entity class</typeparam>
    /// <typeparam name="TData">Data class</typeparam>
    /// <typeparam name="TProperty">Property type</typeparam>
    public class DataKeyProperty<TParent, TData, TProperty>
        where TParent : ILazyEntityObject, IEntityWithKey
        where TData : class, new()
    {
        private Func<TParent, TProperty> _getter;
        private Action<TParent, TProperty> _setter;
        private string _propertyName;

        /// <summary>
        /// Initializes new instance of data property.
        /// </summary>
        /// <param name="getter">Function that get a key property value from the entity object.</param>
        /// <param name="setter">Function that sets the key property value in the entity object.</param>
        /// <param name="propertyName">Name of the property.</param>
        public DataKeyProperty(Func<TParent, TProperty> getter, Action<TParent, TProperty> setter, string propertyName)
        {
            _getter = getter;
            _setter = setter;
            _propertyName = propertyName;
        }

        /// <summary>
        /// Get the current property value.
        /// </summary>
        /// <param name="parent">Entity object</param>
        public TProperty Get(TParent parent)
        {
            return _getter(parent);
        }

        /// <summary>
        /// Sets the key property to the specified value.
        /// </summary>
        /// <param name="parent">Entity object</param>
        /// <param name="value">Value to be set.</param>
        public void Set(TParent parent, TProperty value)
        {
            parent.ReportPropertyChanging(_propertyName);
            _setter(parent, value);
            parent.ReportPropertyChanged(_propertyName);
        }
    }
}
