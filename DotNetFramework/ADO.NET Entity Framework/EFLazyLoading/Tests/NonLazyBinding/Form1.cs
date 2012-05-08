using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NorthwindEFModel;

namespace NonLazyBinding
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private NorthwindEntities _entities;

        private void Form1_Load(object sender, EventArgs e)
        {
            ordersDataGridView.AutoGenerateColumns = true;
            //ordersDataGridView.DataSource = ordersBindingSource;

            _entities = new NorthwindEntities();
            //customerBindingSource.DataSource = new Customer[0];
            customerBindingSource.DataSource = _entities.Customers.Where(c=>false);
            ordersBindingSource.DataSource = customerBindingSource;
            ordersBindingSource.DataMember = "Orders";
        }
    }
}
