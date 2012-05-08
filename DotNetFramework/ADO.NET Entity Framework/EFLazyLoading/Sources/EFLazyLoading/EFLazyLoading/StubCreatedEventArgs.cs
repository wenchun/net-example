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
    /// Provides data for <see cref="LazyObjectContext.StubCreated"/> event.
    /// </summary>
    public class StubCreatedEventArgs : EventArgs
    {
        /// <summary>
        /// Stub object that was just creted.
        /// </summary>
        public IEntityWithKey StubObject { get; set; }

        /// <summary>
        /// Source object that caused this stub to be created
        /// (when navigating a relationship). Can be null if the 
        /// stub was created for a reason other than property navigation.
        /// </summary>
        public IEntityWithKey SourceObject { get; set; }

        /// <summary>
        /// Name of the navigation property that caused
        /// this stub to be created. Null if the 
        /// stub was created for a reason other than property navigation.
        /// </summary>
        public string NavigationProperty { get; set; }
    }
}
