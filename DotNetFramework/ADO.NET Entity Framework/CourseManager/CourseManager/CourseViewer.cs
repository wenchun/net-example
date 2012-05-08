using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

namespace CourseManager
{
	public partial class CourseViewer : Form
	{
		private SchoolEntities schoolContext;

		public CourseViewer()
		{
			InitializeComponent();
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void CourseViewer_Load(object sender, EventArgs e)
		{
		}

		private void loadDataButton_Click(object sender, EventArgs e)
		{
			schoolContext = new SchoolEntities();

			ObjectQuery<Department> departments = schoolContext.Department.OrderBy("it.Name");
			try
			{
				textBox1.Text = departments.ToTraceString();
				dataGridView1.DataSource = departments;
				courseGridView.DataSource = departments.First().Course;
				departmentList.DataSource = departments;
				departmentList.DisplayMember = "Name";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

		private void departmentList_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				Department department = (Department)departmentList.SelectedItem;
				courseGridView.DataSource = department.Course;
				courseGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

	}
}
