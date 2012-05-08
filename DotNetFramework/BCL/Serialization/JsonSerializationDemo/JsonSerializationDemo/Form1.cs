using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace JsonSerializationDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSerialize_Click(object sender, EventArgs e)
        {
            Order order = new Order(1, DateTime.Now, true);
            order.Items.Add(new OrderItem(new Product("腳踏車", 3000), 2));
            order.Items.Add(new OrderItem(new Product("滑鼠墊", 35.6), 10));

            string jsonStr = JsonHelper.Serialize<Order>(order);
            txtJsonStr.Text = jsonStr;
        }

        private void btnDeserialize_Click(object sender, EventArgs e)
        {
            Order order = JsonHelper.Deserialize<Order>(txtJsonStr.Text);
            txtJsonStr.AppendText("\r\n\r\n反序列化結果:");
            txtJsonStr.AppendText("\r\nOrderID: " + order.ID.ToString());
            txtJsonStr.AppendText("\r\nOrderDate: " + order.OrderDate.ToString("yyyy/MM/dd HH:mm:ss"));
            txtJsonStr.AppendText("\r\nUseCoupon: " + order.UseCoupon.ToString());

            foreach (OrderItem item in order.Items)
            {
                txtJsonStr.AppendText("\r\n==========================");
                txtJsonStr.AppendText("\r\nProduct name: " + item.Product.Name);
                txtJsonStr.AppendText("\r\nPrice: " + item.Product.Price.ToString());
                txtJsonStr.AppendText("\r\nCount: " + item.Count.ToString());                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PersonList p = new PersonList();
            string jsonStr = JsonHelper.Serialize<PersonList>(p);
            txtJsonStr.Text = jsonStr;
        }
    }

    [Serializable]
    [DataContract]
    public class Person
    {
        [DataMember(Name="Name")]
        private string m_Name;

        public Person()
        {
            m_Name = "aaa";
        }

    }

    [Serializable]
    [DataContract]
    public class PersonList
    {
        private List<Person> m_Persons;

        public PersonList()
        {
            m_Persons = new List<Person>();
            m_Persons.Add(new Person());
        }

        [DataMember]
        public List<Person> Persons
        {
            get { return m_Persons; }
        }
    }
}
