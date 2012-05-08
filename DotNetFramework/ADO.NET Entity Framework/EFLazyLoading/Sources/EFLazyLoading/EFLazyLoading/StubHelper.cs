// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Objects.DataClasses;

namespace Microsoft.Data.EFLazyLoading
{
    internal static class StubHelper
    {
        internal static void AttachStub<T>(LazyObjectContext context, T stub, EntityKey entityKey)
            where T : IEntityWithKey, ILazyEntityObject
        {
            AttachStub<T>(context, stub, entityKey, null, null);
        }

        internal static void AttachStub<T>(LazyObjectContext context, T stub, EntityKey entityKey, IEntityWithKey sourceObject, string navigationProperty) 
            where T : IEntityWithKey, ILazyEntityObject
        {
            context.StubCounter++;

            stub.EntityKey = entityKey;
            foreach (EntityKeyMember ekm in entityKey.EntityKeyValues)
            {
                typeof(T).GetProperty(ekm.Key).SetValue(stub, ekm.Value, null);
            }

            context.Attach(stub);
            stub.Context = context;
            context.RaiseStubCreatedObject(stub, sourceObject, navigationProperty);
        }
    }
}
