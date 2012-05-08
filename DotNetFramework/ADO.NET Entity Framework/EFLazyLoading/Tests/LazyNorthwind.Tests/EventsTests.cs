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
    public class EventTests
    {
        public EventTests()
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
        public void NoEventsFiredOnRegularLoad()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                context.StubCreated += delegate { throw new InvalidOperationException(); };
                context.ObjectLoaded += delegate { throw new InvalidOperationException(); };

                // nothing should be fired - no stubs or lazy loading involved
                var prod = context.Products.First();
            }
        }

        [TestMethod]
        public void StubEvent()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                StubCreatedEventArgs lastSCE = null;

                context.StubCreated += delegate(object sender, StubCreatedEventArgs args) { lastSCE = args; Assert.AreSame(context, sender); };
                context.ObjectLoaded += delegate { throw new InvalidOperationException(); };

                // nothing should be fired - no stubs or lazy loading involved
                var prod = context.Products.First();
                var cat = prod.Category;
                Assert.IsNotNull(lastSCE);
                Assert.AreSame(cat, lastSCE.StubObject);
                Assert.AreSame(prod, lastSCE.SourceObject);
                Assert.AreEqual("Category", lastSCE.NavigationProperty);
            }
        }
        [TestMethod]
        public void LoadedEventOnPropertyAccess()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                StubCreatedEventArgs lastSCE = null;
                ObjectLoadedEventArgs lastOLE = null;

                context.StubCreated += delegate(object sender, StubCreatedEventArgs args) { lastSCE = args; Assert.AreSame(context, sender); };
                context.ObjectLoaded += delegate(object sender, ObjectLoadedEventArgs args) { lastOLE = args; Assert.AreSame(context, sender); };

                // nothing should be fired - no stubs or lazy loading involved
                var prod = context.Products.First();
                var cat = prod.Category;
                Assert.IsNotNull(lastSCE);
                Assert.AreSame(cat, lastSCE.StubObject);
                Assert.AreSame(prod, lastSCE.SourceObject);
                Assert.AreEqual("Category", lastSCE.NavigationProperty);
                Assert.IsNull(lastOLE);
                var name = cat.CategoryName;
                // make sure that the event has fired
                Assert.IsNotNull(lastOLE);
                Assert.AreSame(cat, lastOLE.EntityObject);
                Assert.AreEqual("CategoryName", lastOLE.PropertyName);
                Assert.AreEqual(LoadReason.PropertyRead, lastOLE.Reason);
            }
        }

        [TestMethod]
        public void LoadedEventOnRelationshipNavigation1()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                StubCreatedEventArgs lastSCE = null;
                ObjectLoadedEventArgs lastOLE = null;

                context.StubCreated += delegate(object sender, StubCreatedEventArgs args) { lastSCE = args; Assert.AreSame(context, sender); };
                context.ObjectLoaded += delegate(object sender, ObjectLoadedEventArgs args) { lastOLE = args; Assert.AreSame(context, sender); };

                // one stub should have been created, but not loaded
                var stub = context.Suppliers.Take(1).AsStubs().First();
                Assert.AreEqual(1, context.StubCounter);
                Assert.AreEqual(0, context.LazyLoadCounter);
                Assert.IsNull(lastOLE);
                Assert.IsNotNull(lastSCE);
                Assert.AreSame(stub, lastSCE.StubObject);
                Assert.IsNull(lastSCE.SourceObject);
                Assert.IsNull(lastSCE.NavigationProperty);

                // navigate relationship from a stub object
                // this causes ObjectLoaded with LoadReason.RelationshipNavigation

                var related = stub.Products;

                Assert.IsNotNull(lastOLE);
                Assert.AreSame(stub, lastOLE.EntityObject);
                Assert.AreEqual("Products", lastOLE.PropertyName);
                Assert.AreEqual(LoadReason.RelationshipNavigation, lastOLE.Reason);
            }
        }

        [TestMethod]
        public void LoadedEventOnRelationshipNavigation3()
        {
            LazyObjectContext.ObjectTypeCache.Clear();

            using (NorthwindEntities context = new NorthwindEntities())
            {
                StubCreatedEventArgs lastSCE = null;
                List<ObjectLoadedEventArgs> lastOLEs = new List<ObjectLoadedEventArgs>();

                context.StubCreated += delegate(object sender, StubCreatedEventArgs args) { lastSCE = args; Assert.AreSame(context, sender); };
                context.ObjectLoaded += delegate(object sender, ObjectLoadedEventArgs args) { lastOLEs.Add(args); Assert.AreSame(context, sender); };

                var stub = context.OrderDetails.Take(1).AsStubs().First();
                // one stub should have been created, but not loaded
                Assert.AreEqual(1, context.StubCounter);
                Assert.AreEqual(0, context.LazyLoadCounter);

                Assert.AreEqual(0, lastOLEs.Count);
                Assert.IsNotNull(lastSCE);
                Assert.AreSame(stub, lastSCE.StubObject);
                Assert.IsNull(lastSCE.SourceObject);
                Assert.IsNull(lastSCE.NavigationProperty);

                // navigate relationship from a stub object
                // this causes ObjectLoaded with LoadReason.RelationshipNavigation

                var related = stub.Order;

                // 2 events - first one is LoadReason.RelationshipNavigation
                // second one is LoadReason.UnknownConcreteType

                Assert.AreEqual(2, lastOLEs.Count);
                Assert.AreSame(stub, lastOLEs[0].EntityObject);
                Assert.AreEqual("Order", lastOLEs[0].PropertyName);
                Assert.AreEqual(LoadReason.RelationshipNavigation, lastOLEs[0].Reason);

                Assert.AreSame(related, lastOLEs[1].EntityObject);
                Assert.AreEqual(null, lastOLEs[1].PropertyName);
                Assert.AreEqual(LoadReason.UnknownConcreteType, lastOLEs[1].Reason);
            }
        }
    }
}
