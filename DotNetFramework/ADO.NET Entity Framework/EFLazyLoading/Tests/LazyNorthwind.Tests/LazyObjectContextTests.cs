using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthwindEFModel;
using System.Data.Objects;
using System.Data.EntityClient;

using Microsoft.Data.EFLazyLoading;

namespace LazyNorthwind.Tests
{
    [TestClass]
    public class LazyObjectContextTests
    {
        public LazyObjectContextTests()
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
        public void ContextTest1()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                context.Products.ToTraceString(); // do something that triggers metadata loading
            }
        }

        [TestMethod]
        public void ContextTest2()
        {
            using (EntityConnection ec = new EntityConnection("name=NorthwindEntities"))
            {
                using (NorthwindEntities context = new NorthwindEntities(ec))
                {
                    context.Products.ToTraceString(); // do something that triggers metadata loading
                }
            }
        }

        [TestMethod]
        public void ContextTest3()
        {
            using (NorthwindEntities context = new NorthwindEntities("name=NorthwindEntities"))
            {
                context.Products.ToTraceString(); // do something that triggers metadata loading
            }
        }

        [TestMethod]
        public void ResetTest1()
        {
            using (NorthwindEntities context = new NorthwindEntities("name=NorthwindEntities"))
            {
                var product = context.Products.First();
                var n = product.ProductName;
                Assert.AreEqual(context.LazyLoadCounter, 0);
                Assert.AreEqual(context.StubCounter, 0);
                context.Reset(product);
                Assert.AreEqual(context.LazyLoadCounter, 0);
                Assert.AreEqual(context.StubCounter, 0);
                var n2 = product.ProductName;
                Assert.AreEqual(context.LazyLoadCounter, 1);
                Assert.AreEqual(context.StubCounter, 0);
            }
        }

        [TestMethod]
        public void ResetTest2()
        {
            using (NorthwindEntities context = new NorthwindEntities("name=NorthwindEntities"))
            {
                var territory = context.Territories.Take(1).GetStub();
                Assert.AreEqual(context.LazyLoadCounter, 0);
                Assert.AreEqual(context.StubCounter, 1);
                var n = territory.TerritoryDescription;
                Assert.AreEqual(context.LazyLoadCounter, 1);
                Assert.AreEqual(context.StubCounter, 1);
                context.Reset(territory);
                Assert.AreEqual(context.LazyLoadCounter, 1);
                Assert.AreEqual(context.StubCounter, 1);
                var n2 = territory.TerritoryDescription;
                Assert.AreEqual(context.LazyLoadCounter, 2);
                Assert.AreEqual(context.StubCounter, 1);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ResetTest3()
        {
            using (NorthwindEntities context = new NorthwindEntities("name=NorthwindEntities"))
            {
                var territory = context.Territories.Take(1).GetStub();
                territory.TerritoryDescription = "Foo";
                Assert.AreEqual(context.LazyLoadCounter, 1);
                Assert.AreEqual(context.StubCounter, 1);
                context.Reset(territory); // InvalidOperationException
            }
        }

        [TestMethod]
        public void ResetTest4()
        {
            using (NorthwindEntities context = new NorthwindEntities("name=NorthwindEntities"))
            {
                var territories = context.Territories.AsStubs();
                Assert.AreEqual(context.LazyLoadCounter, 0);
                Assert.AreEqual(territories.Count(), context.StubCounter);
                foreach (var k in territories)
                {
                    var n = k.TerritoryDescription;
                }
                Assert.AreEqual(territories.Count(), context.LazyLoadCounter);
                Assert.AreEqual(territories.Count(), context.StubCounter);
                context.ResetAllUnchangedObjects();
                foreach (var k in territories)
                {
                    var n = k.TerritoryDescription;
                }
                Assert.AreEqual(2 * territories.Count(), context.LazyLoadCounter);
                Assert.AreEqual(territories.Count(), context.StubCounter);
            }
        }
    }
}
