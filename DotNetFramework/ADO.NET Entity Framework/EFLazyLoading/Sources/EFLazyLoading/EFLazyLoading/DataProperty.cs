// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Data.Objects.DataClasses;

namespace Microsoft.Data.EFLazyLoading
{
    /// <summary>
    /// Data property class that accesses simple non-key properties
    /// </summary>
    /// <typeparam name="TParent">Entity class</typeparam>
    /// <typeparam name="TData">Data class</typeparam>
    /// <typeparam name="TProperty">Property type</typeparam>
    public class DataProperty<TParent, TData, TProperty>
        where TData : class, new()
        where TParent : ILazyEntityObject, IEntityWithKey
    {
        private Func<TData, TProperty> _getter;
        private Action<TData, TProperty> _setter;
        private string _propertyName;

        /// <summary>
        /// Initializes new instance of data property.
        /// </summary>
        /// <param name="getter">Function that get a property value from the data object.</param>
        /// <param name="setter">Function that sets the property value in the data object.</param>
        /// <param name="propertyName">Name of the property.</param>
        public DataProperty(Func<TData, TProperty> getter, Action<TData, TProperty> setter, string propertyName)
        {
            _getter = getter;
            _setter = setter;
            _propertyName = propertyName;
        }

        /// <summary>
        /// Set the property to the specified value, initializes data object if necessary.
        /// </summary>
        /// <param name="parent">Entity object</param>
        /// <param name="value">Value to be set</param>
        public void Set(TParent parent, TProperty value)
        {
            TData data = (TData)parent.EnsureDataLoaded(_propertyName, LoadReason.PropertyWrite);
            parent.ReportPropertyChanging(_propertyName);
            _setter(data, value);
            parent.ReportPropertyChanged(_propertyName);
        }

        /// <summary>
        /// Get the current property value, initializes data object if necessary.
        /// </summary>
        /// <param name="parent">Entity object</param>
        /// <returns>Property value.</returns>
        public TProperty Get(TParent parent)
        {
            return _getter((TData)parent.EnsureDataLoaded(_propertyName, LoadReason.PropertyRead));
        }
    }
}
