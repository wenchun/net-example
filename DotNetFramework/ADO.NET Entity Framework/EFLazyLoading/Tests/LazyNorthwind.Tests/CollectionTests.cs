using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthwindEFModel;
using System.Data.Objects;

namespace LazyNorthwind.Tests
{
    [TestClass]
    public class CollectionTests
    {
        public CollectionTests()
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
        public void NonLoadingMethods()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                // methods/properties that don't cause collection to load
                var p = context.Products.First(c => c.ProductID == 1).OrderDetails;

                Assert.IsFalse(p.IsLoaded);
                var ro = p.IsReadOnly;
                p.CreateSourceQuery().ToTraceString();
                var rn = p.RelationshipName;
                var srn = p.SourceRoleName;
                var trn = p.TargetRoleName;
                Assert.IsFalse(p.Wrapped.IsLoaded);
                Assert.IsFalse(p.IsLoaded);
            }
        }

        [TestMethod]
        public void AddTest()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                var p = context.Products.First(c => c.ProductID == 1).OrderDetails;
                Assert.IsFalse(p.IsLoaded);
                p.Add(new OrderDetail());
                Assert.IsTrue(p.IsLoaded);
            }
        }

        [TestMethod]
        public void RemoveTest()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                var p = context.Products.First(c => c.ProductID == 1).OrderDetails;
                Assert.IsFalse(p.IsLoaded);
                p.Remove(p.First());
                Assert.IsTrue(p.IsLoaded);
            }
        }

        [TestMethod]
        public void CountTest()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                var p = context.Products.First(c => c.ProductID == 1).OrderDetails;
                Assert.IsFalse(p.IsLoaded);
                Assert.IsTrue(p.Count > 0);
                Assert.IsTrue(p.IsLoaded);
            }
        }

        [TestMethod]
        public void ContainsTest()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                var p = context.Products.First(c => c.ProductID == 1).OrderDetails;
                Assert.IsFalse(p.IsLoaded);
                Assert.IsFalse(p.Contains(new OrderDetail()));
                Assert.IsTrue(p.IsLoaded);
            }
        }

        [TestMethod]
        public void ClearTest()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                var p = context.Products.First(c => c.ProductID == 1).OrderDetails;
                Assert.IsFalse(p.IsLoaded);
                p.Clear();
                Assert.IsTrue(p.IsLoaded);
                Assert.AreEqual(0, p.Count);
            }
        }

        [TestMethod]
        public void LoadTest()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                var p = context.Products.First(c => c.ProductID == 1).OrderDetails;
                Assert.IsFalse(p.IsLoaded);
                p.Load();
                Assert.IsTrue(p.IsLoaded);
            }
        }

        [TestMethod]
        public void LoadTest2()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                var p = context.Products.First(c => c.ProductID == 1).OrderDetails;
                Assert.IsFalse(p.IsLoaded);
                p.Load(MergeOption.AppendOnly);
                Assert.IsTrue(p.IsLoaded);
            }
        }

        [TestMethod]
        public void EnumeratorTest()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                var p = context.Products.First(c => c.ProductID == 1).OrderDetails;
                Assert.IsFalse(p.IsLoaded);
                foreach (var od in p)
                {
                }
                Assert.IsTrue(p.IsLoaded);
            }
        }

        [TestMethod]
        public void LoadStubsTests()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                var p = context.Products.First(c => c.ProductID == 1).OrderDetails;
                Assert.AreEqual(0, context.StubCounter);
                Assert.AreEqual(0, context.LazyLoadCounter);
                Assert.IsFalse(p.IsLoaded);
                p.LoadStubs();
                Assert.AreEqual(p.Count, context.StubCounter);
                Assert.AreEqual(0, context.LazyLoadCounter);
                foreach (var k in p)
                {
                }
                Assert.AreEqual(p.Count, context.StubCounter);
                Assert.AreEqual(0, context.LazyLoadCounter);
                foreach (var k in p)
                {
                    var n = k.Discount;
                }
                Assert.AreEqual(p.Count, context.StubCounter);
                Assert.AreEqual(p.Count, context.LazyLoadCounter);
            }
        }
    }
}
