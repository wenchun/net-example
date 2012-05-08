using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthwindEFModel;
using System.IO;

namespace LazyNorthwind.Tests
{
    /// <summary>
    /// Summary description for QueryTests
    /// </summary>
    [TestClass]
    public class QueryTests
    {
        public QueryTests()
        {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void First()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                context.Customers.First();
            }
        }

        [TestMethod]
        public void SimpleQuery()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                context.Customers.Where(c => c.CompanyName != null).ToArray();
            }
        }

        [TestMethod]
        public void ComplexBusinessLogic()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                foreach (Product p in context.Products.Where(c => c.Supplier.CompanyName == "Exotic Liquids"))
                {
                    decimal maxPrice;

                    switch (p.Category.CategoryName)
                    {
                        case "Beverages":
                            maxPrice = 10m;
                            break;

                        case "Produce":
                            maxPrice = 7.95m;
                            break;

                        case "Seafood":
                            maxPrice = 19.95m;
                            break;

                        default:
                            maxPrice = 0.0m;
                            break;
                    }

                    // if we have too many units in stock and the supplier is from Oregon reduce the price by 10%
                    if (p.UnitsInStock > 3 * p.ReorderLevel
                     && p.UnitPrice < maxPrice
                     && p.Supplier.Address.Region == "OR")
                    {
                        p.UnitPrice *= 0.9m;
                        p.ReorderLevel /= 2;
                    }
                }
            }
        }
    }
}
