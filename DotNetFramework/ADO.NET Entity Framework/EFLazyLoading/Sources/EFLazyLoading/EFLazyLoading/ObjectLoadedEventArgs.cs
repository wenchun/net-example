// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Objects.DataClasses;

namespace Microsoft.Data.EFLazyLoading
{
    /// <summary>
    /// Provides data for <see cref="LazyObjectContext.ObjectLoaded"/> event.
    /// </summary>
    public class ObjectLoadedEventArgs : EventArgs
    {
        /// <summary>
        /// Object that was loaded
        /// </summary>
        public IEntityWithKey EntityObject { get; set; }

        /// <summary>
        /// Reason the object was loaded.
        /// </summary>
        public LoadReason Reason { get; set; }

        /// <summary>
        /// Property or Navigation Property that triggered object load
        /// (can be null when object is loaded for a reason other than
        /// RelationshipNavigation or PropertyAccess)
        /// </summary>
        public string PropertyName { get; set; }
    }
}
