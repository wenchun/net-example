using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthwindEFModel;
using Microsoft.Data.EFLazyLoading;
using System.ComponentModel;

namespace LazyNorthwind.Tests
{
    [TestClass]
    public class EditableTests
    {
        public EditableTests()
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
        public void EditableTest1()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                var prod = context.Products.GetStub();
                IEditableObject eo = prod as IEditableObject;
                Assert.IsNotNull(eo);
                eo.BeginEdit();
                prod.ProductName = "Foo";
                Assert.AreEqual("Foo", prod.ProductName);
                eo.CancelEdit();
                Assert.AreNotEqual("Foo", prod.ProductName);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EditableTest2()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                var prod = context.Products.GetStub();
                IEditableObject eo = prod as IEditableObject;
                eo.CancelEdit();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EditableTest3()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                var prod = context.Products.GetStub();
                IEditableObject eo = prod as IEditableObject;
                eo.EndEdit();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EditableTest4()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                var prod = context.Products.GetStub();
                IEditableObject eo = prod as IEditableObject;
                eo.BeginEdit();
                eo.EndEdit();
                eo.EndEdit();
            }
        }

        [TestMethod]
        public void EditableTest5()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                var prod = context.Products.GetStub();
                IEditableObject eo = prod as IEditableObject;
                eo.BeginEdit();
                eo.BeginEdit();
                eo.EndEdit();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EditableTest6()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                var prod = context.Products.GetStub();
                IEditableObject eo = prod as IEditableObject;
                eo.BeginEdit();
                eo.BeginEdit();
                eo.EndEdit();
                eo.EndEdit();
            }
        }
    }
}
