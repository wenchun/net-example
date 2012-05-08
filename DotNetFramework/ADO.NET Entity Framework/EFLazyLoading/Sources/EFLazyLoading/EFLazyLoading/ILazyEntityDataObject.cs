// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

namespace Microsoft.Data.EFLazyLoading
{
    /// <summary>
    /// Interface implemented by all data objects.
    /// </summary>
    public interface ILazyEntityDataObject
    {
        /// <summary>
        /// Creates a deep copy of a data object.
        /// </summary>
        /// <returns>An object that is a copy of a data object.</returns>
        ILazyEntityDataObject Copy();
    }
}
