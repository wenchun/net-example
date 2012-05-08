// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Objects;
using System.Data.Metadata.Edm;
using System.Data.Objects.DataClasses;
using System.Linq.Expressions;

#pragma warning disable 649

namespace Microsoft.Data.EFLazyLoading
{
    /// <summary>
    /// Provides extension methods
    /// </summary>
    public static class ExtensionMethods
    {
        internal abstract class TheTupleBase
        {
            public abstract EntityKey ToEntityKey(EntitySet set);
        }

        internal sealed class TheTuple<T1, T2, T3, T4, T5, T6> : TheTupleBase
        {
            public T1 V0;
            public T1 V1;
            public T2 V2;
            public T3 V3;
            public T4 V4;
            public T5 V5;

            public override EntityKey ToEntityKey(EntitySet set)
            {
                var keys = set.ElementType.KeyMembers;
                EntityKeyMember[] keyMembers = new EntityKeyMember[keys.Count];
                if (keyMembers.Length > 0) keyMembers[0] = new EntityKeyMember(keys[0].Name, V0);
                if (keyMembers.Length > 1) keyMembers[1] = new EntityKeyMember(keys[1].Name, V1);
                if (keyMembers.Length > 2) keyMembers[2] = new EntityKeyMember(keys[2].Name, V2);
                if (keyMembers.Length > 3) keyMembers[3] = new EntityKeyMember(keys[3].Name, V3);
                if (keyMembers.Length > 4) keyMembers[4] = new EntityKeyMember(keys[4].Name, V4);
                if (keyMembers.Length > 5) keyMembers[5] = new EntityKeyMember(keys[5].Name, V5);

                EntityKey key = new EntityKey(set.EntityContainer.Name + "." + set.Name, keyMembers);
                return key;
            }
        }

        /// <summary>
        /// Returns a text representation of an entity object suitable for tracing.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string ToTraceString(this IEntityWithKey entity)
        {
            if (entity != null && entity.EntityKey != null)
                return entity.EntityKey.ToTraceString();
            else
                return "null";
        }

        /// <summary>
        /// Returns a text representation of EntityKey suitable for tracing.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string ToTraceString(this EntityKey key)
        {
            if (key == null)
                return "";
            StringBuilder sb = new StringBuilder();
            sb.Append(key.EntityContainerName);
            sb.Append(".");
            sb.Append(key.EntitySetName);
            sb.Append("[");
            for (int i = 0; i < key.EntityKeyValues.Length; ++i)
            {
                if (i > 0)
                    sb.Append(",");
                sb.AppendFormat("{0}={1}", key.EntityKeyValues[i].Key, key.EntityKeyValues[i].Value);
            }
            sb.Append("]");
            return sb.ToString();
        }

        private static bool IsKindOf(this EntityType entityType, EntityType otherEntityType)
        {
            if (entityType == otherEntityType)
                return true;
            if (entityType.BaseType != null)
                return IsKindOf((EntityType)entityType.BaseType, otherEntityType);
            else
                return false;
        }

        private static EntitySet GetEntitySet(Type t, MetadataWorkspace workspace, string defaultContainerName)
        {
            // TODO - optimize

            EdmEntityTypeAttribute eeta = (EdmEntityTypeAttribute)Attribute.GetCustomAttribute(t, typeof(EdmEntityTypeAttribute));

            string qualifiedName = eeta.NamespaceName + "." + eeta.Name;
            EntityType et = workspace.GetItem<EntityType>(qualifiedName, DataSpace.CSpace);

            EntityContainer ec = workspace.GetEntityContainer(defaultContainerName, DataSpace.CSpace);
            EntitySet foundSet = null;

            foreach (EntitySet set in ec.BaseEntitySets.OfType<EntitySet>())
            {
                if (et.IsKindOf(set.ElementType))
                {
                    if (foundSet == null)
                    {
                        foundSet = set;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            return foundSet;
        }

        /// <summary>
        /// Returns a sequence of EntityKeys for a given query.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="query">Query</param>
        /// <returns>A sequence of <see cref="EntityKey"/> objects.</returns>
        public static IEnumerable<EntityKey> SelectKeys<T>(this ObjectQuery<T> query)
        {
            EntitySet set = GetEntitySet(typeof(T), query.Context.MetadataWorkspace, query.Context.DefaultContainerName);
            if (set == null)
            {
                throw new NotSupportedException("Multiple EntitySets per type are not supported.");
                
                // the following works sometimes (for textual ObjectQuery<T> queries),
                // but it destroys ordering and does not work on top of a LINQ query
                //
                //foreach (DbDataRecord record in query.Select("REF(it)"))
                //{
                //    yield return ((EntityKey)record.GetValue(0));
                //}
            }
            else
            {
                EntityType setElementType = set.ElementType;
                var keys = setElementType.KeyMembers;
                Type[] genericTypeArgs = new Type[6];
                for (int i = 0; i < keys.Count; ++i)
                {
                    genericTypeArgs[i] = ((PrimitiveType)set.ElementType.KeyMembers[i].TypeUsage.EdmType).ClrEquivalentType;
                }
                for (int i = keys.Count; i < genericTypeArgs.Length; ++i)
                {
                    genericTypeArgs[i] = typeof(int);
                }
                Type tupleType = typeof(TheTuple<,,,,,>).MakeGenericType(genericTypeArgs);
                ParameterExpression lambdaParameter = Expression.Parameter(typeof(T), "c");
                MemberBinding[] memberBindings = new MemberBinding[keys.Count];
                for (int i = 0; i < keys.Count; ++i)
                {
                    memberBindings[i] = Expression.Bind(tupleType.GetField("V" + i), Expression.Property(lambdaParameter, keys[i].Name));
                }

                MemberInitExpression mie = Expression.MemberInit(Expression.New(tupleType), memberBindings);
                Expression<Func<T, TheTupleBase>> lambda = Expression.Lambda<Func<T, TheTupleBase>>(mie, lambdaParameter);
                foreach (TheTupleBase ttb in query.Select(lambda))
                {
                    yield return ttb.ToEntityKey(set);
                }
            }
        }

        /// <summary>
        /// Returns the results of a query as a sequence of stubs.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="lhs">Query</param>
        /// <returns>A sequence of stub objects.</returns>
        /// <remarks>The query is rewritten so that only primary keys are retrieved from a database</remarks>
        public static IEnumerable<T> AsStubs<T>(this IQueryable<T> lhs) where T : class, ILazyEntityObject, IEntityWithKey
        {
            return lhs.AsStubs(null);
        }

        /// <summary>
        /// Returns the results of a filtered query as stubs.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="lhs">Query</param>
        /// <param name="whereClause">Additional condition to apply to the query</param>
        /// <returns>A sequence of stub objects.</returns>
        /// <remarks>The query is rewritten so that only primary keys are retrieved from a database</remarks>
        public static IEnumerable<T> AsStubs<T>(this IQueryable<T> lhs, Expression<Func<T,bool>> whereClause) where T : class, ILazyEntityObject, IEntityWithKey
        {
            ObjectQuery<T> oqt = lhs as ObjectQuery<T>;
            if (oqt == null)
                throw new ArgumentException("GetStubs() is only supported on ObjectQuery<T>");

            LazyObjectContext context = oqt.Context as LazyObjectContext;
            if (context == null)
                throw new ArgumentException("GetStubs() in only supported in LazyObjectContext");

            IObjectTypeCache otc = LazyObjectContext.ObjectTypeCache;

            List<T> result = new List<T>();
            bool polymorphic = otc.HasSubclasses(typeof(T), context.MetadataWorkspace);

            if (whereClause != null)
                oqt = (ObjectQuery<T>)oqt.Where(whereClause);

            foreach (EntityKey key in oqt.SelectKeys())
            {
                T entity;
                ObjectStateEntry ose;

                if (context.ObjectStateManager.TryGetObjectStateEntry(key, out ose) && ose.Entity != null)
                {
                    // object alread in the context - just get it
                    entity = (T)ose.Entity;
                }
                else
                {
                    // if the type is polymorphic, we must know the concrete type to create
                    if (polymorphic)
                    {
                        Func<object> typeCreator;

                        // ask the cache, if it's not cached
                        // we re-run the original query with full materialization
                        // and add concrete types to the cache

                        if (!otc.TryGetTypeForKey(key, out typeCreator))
                        {
                            T[] originalResults = oqt.ToArray();
                            foreach (T res in originalResults)
                            {
                                context.RaiseObjectLoaded(res, LoadReason.UnknownConcreteType, null);
                                otc.SetTypeForKey(res.EntityKey, res.GetType());
                            }
                            return originalResults;
                        }
                        else
                        {
                            // we know the concrete type
                            entity = (T)typeCreator();
                        }
                    }
                    else
                    {
                        // type is not polymorphic - go ahead and create it
                        entity = Activator.CreateInstance<T>();
                    }

                    StubHelper.AttachStub<T>(context, entity, key);
                }
                result.Add(entity);
            }

            return result;
        }

        /// <summary>
        /// Returns the first result of a query as a stub.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="query">Query</param>
        /// <returns>A stub object that represents first query result</returns>
        /// <remarks>The query is rewritten so that only primar key is retrieved from a database</remarks>
        public static T GetStub<T>(this IQueryable<T> query) where T : class, ILazyEntityObject, IEntityWithKey, new()
        {
            return query.AsStubs().First();
        }

        /// <summary>
        /// Returns the first result of a filtered query as a stub.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="query">Query</param>
        /// <param name="whereClause">Additional condition to apply to the query</param>
        /// <returns>A stub object that represents first query result</returns>
        /// <remarks>The query is rewritten so that only primar key is retrieved from a database</remarks>
        public static T GetStub<T>(this IQueryable<T> query, Expression<Func<T, bool>> whereClause) where T : class, ILazyEntityObject, IEntityWithKey, new()
        {
            return query.AsStubs(whereClause).First();
        }
    }
}
