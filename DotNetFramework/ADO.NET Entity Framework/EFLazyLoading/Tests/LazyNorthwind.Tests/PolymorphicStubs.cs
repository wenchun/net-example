using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthwindEFModel;
using Microsoft.Data.EFLazyLoading;

namespace LazyNorthwind.Tests
{
    [TestClass]
    public class PolymorphicStubTests
    {
        public PolymorphicStubTests()
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
        public void PolymorphicStubs1()
        {
            LazyObjectContext.ObjectTypeCache.Clear();

            using (NorthwindEntities context = new NorthwindEntities())
            {
                var prod = context.Products.First(c=>c.ProductID == 1);

                foreach (OrderDetail det in prod.OrderDetails)
                {
                    var order = det.Order; // this may be Order or InternationalOrder
                }
                Assert.AreEqual(true, LazyObjectContext.ObjectTypeCache.HasSubclasses(typeof(Order), context.MetadataWorkspace));
                Assert.AreEqual(false, LazyObjectContext.ObjectTypeCache.HasSubclasses(typeof(Territory), context.MetadataWorkspace));
            }

            // do this again - this time there will be no cache hits
            using (NorthwindEntities context = new NorthwindEntities())
            {
                var prod = context.Products.First(c => c.ProductID == 1);

                foreach (OrderDetail det in prod.OrderDetails)
                {
                    var order = det.Order; // this may be Order or InternationalOrder
                }
                Assert.AreEqual(true, LazyObjectContext.ObjectTypeCache.HasSubclasses(typeof(Order), context.MetadataWorkspace));
                Assert.AreEqual(false, LazyObjectContext.ObjectTypeCache.HasSubclasses(typeof(Territory), context.MetadataWorkspace));
            }
        }
    }
}
