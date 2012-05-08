// Copyright (c) Microsoft Corporation.  All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthwindEFModel;
using System.Data;
using System.Data.Metadata.Edm;

using Microsoft.Data.EFLazyLoading;
using System.Data.Common;

namespace LazyNorthwind
{
    class Program
    {
        static void Main()
        {
            using (NorthwindEntities entities = new NorthwindEntities())
            {
                // set up some events so that we are notified whenever new stubs are created and 
                // whenever lazy loading happens
                entities.StubCreated += entities_OnStubCreated;
                entities.ObjectLoaded += entities_OnObjectLoaded;

                // regular, fully loaded entity
                var prod = entities.Products.First();

                var cat = prod.Category; // no load from the database here - just stub 

                // we load it on demand
                Console.WriteLine("name: {0}", cat.CategoryName);

                // once it is loaded we can access all properties
                Console.WriteLine("desc: {0}", cat.Description);

                // iterate through details
                foreach (OrderDetail det in prod.OrderDetails.LoadStubs())
                {
                    // order can be Order or InternationalOrder so we'll load it eagerly
                    // because we don't know the concrete type
                    var order = det.Order;

                    // next time (even in a different ObjectContext) we'll use cached type information
                    // so there's no server roundtrip
                    Console.WriteLine("{0} {1}", det.Product.ProductName, order.OrderDate);
                }

                var stubs = entities.Suppliers.Where(c => c.Products.Any(d=>d.Category.CategoryID == cat.CategoryID)).AsStubs();
                Console.WriteLine("Suppliers that have {0}", cat.CategoryName);
                foreach (var p in stubs)
                {
                    Console.WriteLine("Shipper {0} - {1} - {2} products", p.CompanyName, p.Phone, p.Products.LoadStubs().Count);
                }

                // single object as a stub
                var singleStub = entities.Suppliers.GetStub(c=>c.SupplierID == 4);
                Console.WriteLine("Stub: {0}", singleStub.Phone);
            }
        }

        static void entities_OnObjectLoaded(object sender, Microsoft.Data.EFLazyLoading.ObjectLoadedEventArgs args)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Object loaded: '{0}'", args.EntityObject.ToTraceString(), args.Reason, args.PropertyName);
            Console.WriteLine("Reason: {1} Property: '{2}'", args.EntityObject.ToTraceString(), args.Reason, args.PropertyName);
            Console.ForegroundColor = oldColor;
        }

        static void entities_OnStubCreated(object sender, Microsoft.Data.EFLazyLoading.StubCreatedEventArgs args)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            if (args.NavigationProperty != null)
            {
                Console.WriteLine("Created stub '{0}' while navigating '{1}' from '{2}'", args.StubObject.ToTraceString(), args.NavigationProperty, args.SourceObject.ToTraceString());
            }
            else
            {
                Console.WriteLine("Created stub '{0}'", args.StubObject.ToTraceString());
            }
            Console.ForegroundColor = oldColor;
        }
    }
}
