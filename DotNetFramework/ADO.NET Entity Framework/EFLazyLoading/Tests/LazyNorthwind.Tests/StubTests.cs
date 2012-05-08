using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthwindEFModel;
using Microsoft.Data.EFLazyLoading;

namespace LazyNorthwind.Tests
{
    /// <summary>
    /// Summary description for StubTests
    /// </summary>
    [TestClass]
    public class StubTests
    {
        public StubTests()
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
        public void SimpleStubs()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                Assert.AreEqual(0, context.StubCounter);
                Assert.AreEqual(0, context.LazyLoadCounter);

                // loading an object does not count as lazy loading, does not create stubs
                var prod = context.Products.First();
                Assert.AreEqual(0, context.StubCounter);
                Assert.AreEqual(0, context.LazyLoadCounter);

                // referencing an object creates a new stub
                var cat = prod.Category;
                Assert.AreEqual(1, context.StubCounter);
                Assert.AreEqual(0, context.LazyLoadCounter);

                // dereferecing stub causes a load
                var name = cat.CategoryName;
                Assert.AreEqual(1, context.StubCounter);
                Assert.AreEqual(1, context.LazyLoadCounter);
            }
        }

        [TestMethod]
        public void StubIdentity()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                Category cat = null;
                int counter = 0;

                // no matter how we get to the object, we always get the same stub object
                foreach (var p in context.Products.Where(c => c.Category.CategoryName == "Beverages"))
                {
                    if (cat == null)
                        cat = p.Category;
                    else
                        Assert.AreSame(cat, p.Category);
                    counter++;

                }
                Assert.IsTrue(counter > 1);
                Assert.AreEqual(1, context.StubCounter);
                Assert.AreEqual(0, context.LazyLoadCounter);
            }
        }

        [TestMethod]
        public void StubIdentity2()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                Category cat = null;
                int counter = 0;

                // no matter how we get to the object, we always get the same stub object
                foreach (var p in context.Products.Where(c => c.Category.CategoryName == "Beverages"))
                {
                    if (cat == null)
                    {
                        cat = p.Category;
                        var n = cat.CategoryName;
                    }
                    else
                        Assert.AreSame(cat, p.Category);
                    counter++;

                }
                Assert.IsTrue(counter > 1);
                Assert.AreEqual(1, context.StubCounter);
                Assert.AreEqual(1, context.LazyLoadCounter);
            }
        }

        [TestMethod]
        public void NullStubs()
        {
            // change Chai's product's category to null
            using (NorthwindEntities context = new NorthwindEntities())
            {
                context.Products.First(c => c.ProductID == 1).Category = null;
                // no stub was created
                Assert.AreEqual(0, context.StubCounter);
                context.SaveChanges();
            }

            try
            {
                // assert that it is null
                using (NorthwindEntities context = new NorthwindEntities())
                {
                    Assert.AreSame(null, context.Products.First(c => c.ProductID == 1).Category);
                    Assert.AreEqual(0, context.StubCounter);
                }
            }
            finally
            {
                // reset it back to default category
                using (NorthwindEntities context = new NorthwindEntities())
                {
                    context.Products.First(c => c.ProductID == 1).Category = context.Categories.First(c=>c.CategoryID == 1);
                    context.SaveChanges();
                }
            }
        }

        [TestMethod]
        public void StubQuery()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                foreach (Product p in context.Products.AsStubs())
                {
                    Console.WriteLine(p);
                }
                var t1 = context.Territories.OrderBy(c=>c.TerritoryID).First();
                var t2 = context.Territories.OrderBy(c=>c.TerritoryID).AsStubs().First();
                Assert.AreSame(t1, t2);
                var t3 = context.Territories.OrderByDescending(c=>c.TerritoryID).AsStubs().First();
                var t4 = context.Territories.OrderByDescending(c=>c.TerritoryID).First();
                Console.WriteLine("t3: {0} t4: {1}", t3.TerritoryID, t4.TerritoryID);
                Assert.AreSame(t3, t4);
                Assert.AreNotSame(t1, t3);
            }
        }

        [TestMethod]
        public void StubQuery2()
        {
            List<string> keyStrings = new List<string>();

            using (NorthwindEntities context = new NorthwindEntities())
            {
                foreach (Product p in context.Products.OrderByDescending(c=>c.ProductName).Where(c=>c.ProductID < 10))
                {
                    keyStrings.Add(p.ToTraceString());
                }
            }

            int counter = 0;

            using (NorthwindEntities context = new NorthwindEntities())
            {
                foreach (Product p in context.Products.OrderByDescending(c => c.ProductName).AsStubs(c => c.ProductID < 10))
                {
                    Assert.AreEqual(keyStrings[counter++], p.ToTraceString());
                }
            }
        }

        [TestMethod]
        public void StubQuery3()
        {
            List<string> keyStrings = new List<string>();

            using (NorthwindEntities context = new NorthwindEntities())
            {
                foreach (Product p in context.Products.OrderByDescending(c => c.ProductName).Where(c => c.ProductID < 10).AsStubs())
                {
                    keyStrings.Add(p.ToTraceString());
                }
            }

            int counter = 0;

            // retrieve the same stubs again, this time type information comes from object type cache

            using (NorthwindEntities context = new NorthwindEntities())
            {
                foreach (Product p in context.Products.OrderByDescending(c => c.ProductName).Where(c => c.ProductID < 10).AsStubs())
                {
                    Assert.AreEqual(keyStrings[counter++], p.ToTraceString());
                }
            }
        }

        [TestMethod]
        public void StubQuery4()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                var prod = context.Products.GetStub(c=>c.ProductID == 2);
                Assert.AreEqual(0, context.LazyLoadCounter);
                Assert.AreEqual(1, context.StubCounter);
                Assert.AreEqual("NorthwindEntities.Products[ProductID=2]", prod.ToTraceString());
            }
        }

        [TestMethod]
        public void StubQuery5()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                var prod = context.Products.Where(c => c.ProductID == 2).GetStub();
                Assert.AreEqual(0, context.LazyLoadCounter);
                Assert.AreEqual(1, context.StubCounter);
                Assert.AreEqual("NorthwindEntities.Products[ProductID=2]", prod.ToTraceString());
            }
        }
    }
}
