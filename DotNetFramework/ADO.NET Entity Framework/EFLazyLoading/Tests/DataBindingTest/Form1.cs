using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NorthwindEFModel;

using Microsoft.Data.EFLazyLoading;

namespace DataBindingTest
{
    public partial class Form1 : Form
    {
        private NorthwindEntities _entities;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _entities = new NorthwindEntities();
            _entities.StubCreated += _entities_StubCreated;
            _entities.ObjectLoaded += _entities_ObjectLoaded;

            // pre-load first 10 objects (no stubs here)
            _entities.Customers.Take(10).ToArray();

            // load entire collection as stubs 
            // (first 10 will already be fully loaded, because they are tracked in the context)

            customerBindingSource.DataSource = _entities.Customers.AsStubs();
        }

        void _entities_ObjectLoaded(object sender, Microsoft.Data.EFLazyLoading.ObjectLoadedEventArgs args)
        {
            textBox1.AppendText(String.Format("Object loaded: {0} Reason: {1} Property: {2}\r\n", args.EntityObject.ToTraceString(), args.Reason, args.PropertyName));
        }

        void _entities_StubCreated(object sender, Microsoft.Data.EFLazyLoading.StubCreatedEventArgs args)
        {
            textBox1.AppendText(String.Format("Stub created: {0}\r\n", args.StubObject.ToTraceString()));
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            _entities.ResetAllUnchangedObjects();
        }
    }
}
