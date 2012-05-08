// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Data;
using System.Data.Metadata.Edm;

namespace Microsoft.Data.EFLazyLoading
{
    /// <summary>
    /// Provides mapping between Entity Keys and concrete CLR types
    /// </summary>
    public interface IObjectTypeCache
    {
        /// <summary>
        /// Clears object type cache.
        /// </summary>
        void Clear();

        /// <summary>
        /// Returns a function that creates a concrete type corresponding
        /// to a given EntityKey
        /// </summary>
        /// <param name="key">Entity Key</param>
        /// <param name="concreteTypeCreator">Function to create concrete type that corresponds to the key.</param>
        /// <returns>true if the function is known, false otherwise</returns>
        bool TryGetTypeForKey(EntityKey key, out Func<object> concreteTypeCreator);

        /// <summary>
        /// Adds the mapping from entity key to its concrete type to the cache.
        /// </summary>
        /// <param name="key">Entity key</param>
        /// <param name="concreteType">Concrete type</param>
        void SetTypeForKey(EntityKey key, Type concreteType);

        /// <summary>
        /// Determines whether given type has derived classes in the defined
        /// metadata workspace.
        /// </summary>
        /// <param name="baseType">Base CLR type</param>
        /// <param name="workspace">Metadata workspace</param>
        /// <returns>True if the type is known to have subclasses</returns>
        bool HasSubclasses(Type baseType, MetadataWorkspace workspace);
    }
}
