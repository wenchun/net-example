// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Microsoft.Data.EFLazyLoading
{
    /// <summary>
    /// Represents the reason why entity object was loaded.
    /// </summary>
    public enum LoadReason
    {
        /// <summary>
        /// Entity was loaded because of property read.
        /// </summary>
        PropertyRead,

        /// <summary>
        /// Entity was loaded because of property write.
        /// </summary>
        PropertyWrite,

        /// <summary>
        /// Entity was loaded because of relationship navigation.
        /// </summary>
        RelationshipNavigation,

        /// <summary>
        /// Entity was eagerly loaded because it was impossible to determine concrete type based on EntityKey.
        /// </summary>
        UnknownConcreteType,

        /// <summary>
        /// Entity is being loaded because of IEditableObject.BeginEdit called on a stub.
        /// </summary>
        BeginEdit,
    }
}
