// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data;
using System.Data.Objects;
using System.Data.Metadata.Edm;
using System.Collections.ObjectModel;
using System.Threading;

namespace Microsoft.Data.EFLazyLoading
{
    internal class ObjectTypeCacheImpl : IObjectTypeCache
    {
        private static ReaderWriterLockSlim _rwlock = new ReaderWriterLockSlim();
        private static ReaderWriterLockSlim _rwlock2 = new ReaderWriterLockSlim();

        private Dictionary<Type, bool> _isPolymorphicCache = new Dictionary<Type, bool>();
        private Dictionary<EntityKey, Func<object>> _concreteTypeCache = new Dictionary<EntityKey, Func<object>>();
        private Dictionary<Type, Func<object>> _typeCreatorCache = new Dictionary<Type, Func<object>>();

        public bool TryGetTypeForKey(EntityKey key, out Func<object> concreteTypeCreator)
        {
            _rwlock.EnterReadLock();
            try
            {
                return _concreteTypeCache.TryGetValue(key, out concreteTypeCreator);
            }
            finally
            {
                _rwlock.ExitReadLock();
            }
        }

        public void SetTypeForKey(EntityKey key, Type concreteType)
        {
            _rwlock.EnterWriteLock();
            Func<object> concreteTypeCreator;

            if (!_typeCreatorCache.TryGetValue(concreteType, out concreteTypeCreator))
            {
                concreteTypeCreator = (Func<object>)Expression.Lambda(typeof(Func<object>), Expression.New(concreteType)).Compile();
                _typeCreatorCache[concreteType] = concreteTypeCreator;
            }
            _concreteTypeCache[key] = concreteTypeCreator;
            _rwlock.ExitWriteLock();
        }

        /// <summary>
        /// Determine whether baseType has derived classes.
        /// </summary>
        /// <param name="baseType"></param>
        /// <param name="workspace"></param>
        /// <returns></returns>
        public bool HasSubclasses(Type baseType, MetadataWorkspace workspace)
        {
            _rwlock2.EnterReadLock();
            bool isPolymorphic;

            if (!_isPolymorphicCache.TryGetValue(baseType, out isPolymorphic))
            {
                _rwlock2.ExitReadLock();
                ObjectItemCollection oic = (ObjectItemCollection)workspace.GetItemCollection(DataSpace.OSpace);

                ReadOnlyCollection<EntityType> ospaceTypes = oic.GetItems<EntityType>();
                isPolymorphic = false;
                foreach (var ost in ospaceTypes)
                {
                    Type clrOspaceType = oic.GetClrType(ost);
                    if (clrOspaceType != baseType && baseType.IsAssignableFrom(clrOspaceType))
                    {
                        isPolymorphic = true;
                        break;
                    }
                }
                _rwlock2.EnterWriteLock();
                _isPolymorphicCache[baseType] = isPolymorphic;
                _rwlock2.ExitWriteLock();
                return isPolymorphic;
            }
            else
            {
                _rwlock2.ExitReadLock();
                return isPolymorphic;
            }
        }

        public void Clear()
        {
            _rwlock.EnterWriteLock();
            _rwlock2.EnterWriteLock();
            _isPolymorphicCache.Clear();
            _concreteTypeCache.Clear();
            _typeCreatorCache.Clear();
            _rwlock2.ExitWriteLock();
            _rwlock.ExitWriteLock();

        }
    }
}
