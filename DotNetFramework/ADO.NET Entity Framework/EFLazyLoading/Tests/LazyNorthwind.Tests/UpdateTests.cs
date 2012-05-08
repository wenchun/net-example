using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthwindEFModel;
using System.IO;

namespace LazyNorthwind.Tests
{
    [TestClass]
    public class UpdateTests
    {
        public UpdateTests()
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
        public void Update1()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                foreach (var emp in context.Products)
                {
                    if (emp.UnitPrice > 1000000)
                        emp.UnitPrice /= 64;
                    else
                        emp.UnitPrice *= 2;
                }
                Assert.AreEqual(0, context.StubCounter);
                Assert.AreEqual(0, context.LazyLoadCounter);

                context.SaveChanges();
                // make sure no lazy loading happened during SaveChanges (and no new stubs were created)
                Assert.AreEqual(0, context.StubCounter);
                Assert.AreEqual(0, context.LazyLoadCounter);
            }
        }

        [TestMethod]
        public void Update2()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                foreach (var prod in context.Products)
                {
                    if (prod.UnitPrice > 1000000)
                        prod.UnitPrice /= 64;
                    else
                        prod.UnitPrice *= 2;
                    var supp = prod.Supplier; // create stub
                }
                var stubCounter1 = context.StubCounter;
                Assert.IsTrue(stubCounter1 > 0);
                Assert.AreEqual(0, context.LazyLoadCounter);

                context.SaveChanges();
                // make sure no lazy loading happened during SaveChanges (and no new stubs were created)
                Assert.AreEqual(stubCounter1, context.StubCounter);
                Assert.AreEqual(0, context.LazyLoadCounter);
            }
        }

    }
}
