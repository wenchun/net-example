using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthwindEFModel;
using System.Data.Objects;
using System.Diagnostics;

namespace LazyNorthwind
{
    class Program
    {
        static void Main()
        {
            using (NorthwindEntities entities = new NorthwindEntities())
            {
                var prod = entities.Products.First();
                prod.SupplierReference.Load();
                var supplier = prod.Supplier;

                prod.OrderDetails.Load();
                foreach (OrderDetail det in prod.OrderDetails)
                {
                    if (!det.OrderReference.IsLoaded)
                        det.OrderReference.Load();
                    Console.WriteLine("{0} {1}", det.Product.ProductName, det.Order.OrderDate);
                }
            }
        }
    }
}
