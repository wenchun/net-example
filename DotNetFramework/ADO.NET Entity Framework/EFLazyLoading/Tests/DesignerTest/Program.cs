using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthwindEFModel;

using Microsoft.Data.EFLazyLoading;

namespace DesignerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (NorthwindEFEntities entities = new NorthwindEFEntities())
            {
                foreach (Categories cat in entities.Categories.AsStubs())
                {
                    Console.WriteLine("{0} - {1} products", cat.CategoryName, cat.Products.Count);
                }
            }
        }
    }
}
