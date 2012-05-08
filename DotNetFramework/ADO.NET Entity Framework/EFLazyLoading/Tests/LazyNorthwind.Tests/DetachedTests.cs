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
    /// Summary description for DetachedTests
    /// </summary>
    [TestClass]
    public class DetachedTests
    {
        public DetachedTests()
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
        public void DetachedObjectSimplePropertyWrite()
        {
            Customer c1 = new Customer();
            c1.ContactName = "Foo, Bar";
            c1.ContactTitle = "Subtitle";
            Assert.AreEqual("Foo, Bar", c1.ContactName);
            Assert.AreEqual("Subtitle", c1.ContactTitle);

            using (NorthwindEntities context = new NorthwindEntities())
            {
                context.AddObject("Customers", c1);
                var k = c1.Phone;
                Assert.AreEqual("Foo, Bar", c1.ContactName);
                Assert.AreEqual("Subtitle", c1.ContactTitle);
                Assert.AreEqual(0, context.StubCounter);
                Assert.AreEqual(0, context.LazyLoadCounter);
            }
        }

        [TestMethod]
        public void DetachedObjectSimplePropertyRead()
        {
            Customer c1 = new Customer();
            var c = c1.ContactName;
            Assert.IsNull(c);
            using (NorthwindEntities context = new NorthwindEntities())
            {
                context.AddObject("Customers", c1);
                Assert.IsNull(c1.Phone);
                Assert.AreEqual(null, c1.ContactName);
                Assert.AreEqual(null, c1.ContactTitle);

                c1.ContactName = "Foo";
                Assert.AreEqual("Foo", c1.ContactName);
                Assert.AreEqual(0, context.StubCounter);
                Assert.AreEqual(0, context.LazyLoadCounter);
            }
        }

        [TestMethod]
        public void DetachedObjectComplexPropertyWrite()
        {
            Customer c1 = new Customer();
            c1.Address.City = "Seattle";
            c1.Address.Region = "WA";
            Assert.AreEqual(c1.Address.City, "Seattle");
            Assert.AreEqual(c1.Address.Region, "WA");
            using (NorthwindEntities context = new NorthwindEntities())
            {
                context.AddObject("Customers", c1);
                Assert.AreEqual(c1.Address.City, "Seattle");
                Assert.AreEqual(c1.Address.Region, "WA");
                Assert.IsNull(c1.Address.Country);
                Assert.AreEqual(0, context.StubCounter);
                Assert.AreEqual(0, context.LazyLoadCounter);
            }
        }

        [TestMethod]
        public void DetachedObjectComplexPropertyRead()
        {
            Customer c1 = new Customer();
            Assert.IsNull(c1.Address.City);
            using (NorthwindEntities context = new NorthwindEntities())
            {
                context.AddObject("Customers", c1);
                Assert.IsNull(c1.Address.City);
                Assert.IsNull(c1.Address.Country);
                Assert.AreEqual(0, context.StubCounter);
                Assert.AreEqual(0, context.LazyLoadCounter);
            }
        }

        [TestMethod]
        public void DetachedObjectRefPropertyWrite()
        {
            Order o1 = new Order();
            var c = new Customer();
            o1.Customer = c;
            Assert.AreSame(o1.Customer, c);
            using (NorthwindEntities context = new NorthwindEntities())
            {
                context.AddObject("Orders", o1);
                Assert.AreSame(o1.Customer, c);
                Assert.AreEqual(0, context.StubCounter);
                Assert.AreEqual(0, context.LazyLoadCounter);
            }
        }

        [TestMethod]
        public void DetachedObjectRefPropertyRead()
        {
            Order o1 = new Order();
            var k = o1.Customer;
            Assert.IsNull(k);
        }

        [TestMethod]
        public void DetachedObjectCollectionProperty()
        {
            Customer c1 = new Customer();
            Order o1 = new Order();
            Order o2 = new Order();
            Order o3 = new Order();
            c1.Orders.Add(o1);
            c1.Orders.Add(o2);
            c1.Orders.Add(o3);
            c1.Orders.Remove(o3);
            Assert.AreSame(o1.Customer, c1);
            Assert.AreSame(o2.Customer, c1);
            Assert.IsNull(o3.Customer);
            using (NorthwindEntities context = new NorthwindEntities())
            {
                context.AddObject("Orders", o1);
                Assert.AreSame(o1.Customer, c1);
                Assert.AreSame(o2.Customer, c1);
                Assert.IsNull(o3.Customer);
            }
        }
    }
}
