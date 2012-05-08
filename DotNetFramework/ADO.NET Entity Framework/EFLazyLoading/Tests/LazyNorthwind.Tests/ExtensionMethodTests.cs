using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthwindEFModel;
using Microsoft.Data.EFLazyLoading;
using System.Data;

namespace LazyNorthwind.Tests
{
    [TestClass]
    public class ExtensionMethodTests
    {
        public ExtensionMethodTests()
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
        public void ToTraceString1()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                var prod = context.Products.First(c=>c.ProductID == 1);
                Assert.AreEqual("NorthwindEntities.Products[ProductID=1]", prod.ToTraceString());

                var od = context.OrderDetails.First(c=>c.OrderID==10248 && c.ProductID==11);
                Assert.AreEqual("NorthwindEntities.OrderDetails[OrderID=10248,ProductID=11]", od.ToTraceString());
            }
        }

        [TestMethod]
        public void ToTraceString2()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                Product p = null;
                Assert.AreEqual("null", p.ToTraceString());

                OrderDetail od = null;
                Assert.AreEqual("null", od.ToTraceString());

                EntityKey ek = null;
                Assert.AreEqual("", ek.ToTraceString());
            }
        }
    }
}
