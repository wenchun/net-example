// Copyright (c) Microsoft Corporation.  All rights reserved.

namespace Microsoft.Data.EFLazyLoading
{
    /// <summary>
    /// Manages <see cref="LazyObjectContext" /> and internal state of entity objects that support lazy loading.
    /// </summary>
    public interface ILazyEntityObject
    {
        /// <summary>
        /// Object context. Only stub objects (or objects that have been stubs) have
        /// it.
        /// </summary>
        LazyObjectContext Context { get; set; }

        /// <summary>
        /// Raises PropertyChanging event.
        /// </summary>
        /// <param name="name">Name of the property</param>
        void ReportPropertyChanging(string name);

        /// <summary>
        /// Raises PropertyChanged event.
        /// </summary>
        /// <param name="name">Name of the property</param>
        void ReportPropertyChanged(string name);

        /// <summary>
        /// Ensures that data object has been loaded.
        /// </summary>
        /// <param name="propertyName">Name of the property or navigation property</param>
        /// <param name="reason">Current action</param>
        /// <returns>Initialized data object</returns>
        ILazyEntityDataObject EnsureDataLoaded(string propertyName, LoadReason reason);

        /// <summary>
        /// Resets data object to not initialized state so that entity will be loaded
        /// on next property access.
        /// </summary>
        void ResetData();

        /// <summary>
        /// Determines whether object is attached to a context 
        /// </summary>
        bool IsAttached { get; }
    }
}
