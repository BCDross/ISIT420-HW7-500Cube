using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISIT420_HW7_500Cube_WinForm
{
    public partial class Form1 : Form
    {
        DataSet formDataSet = new DataSet();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CubeData myCube = new CubeData();
            try
            {
                formDataSet = myCube.GetQueryOne();
            }
            catch (Exception ex)
            {
                label1.Text = "Something went wrong! " + ex.Message;
            }
            label1.Text = "CD sales count by Album and Sales Person ordered by price point descending.";
            dataGridView1.DataSource = formDataSet;
            dataGridView1.DataMember = "CubeData1";
            dataGridView1.AutoResizeColumns();
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CubeData myCube = new CubeData();
            try
            {
                formDataSet = myCube.GetQueryTwo();
            }
            catch (Exception ex)
            {
                label1.Text = "Something went wrong! " + ex.Message;
            }
            label1.Text = "Sales Person sales count by price point.";
            dataGridView1.DataSource = formDataSet;
            dataGridView1.DataMember = "CubeData2";
            dataGridView1.AutoResizeColumns();
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CubeData myCube = new CubeData();
            try
            {
                formDataSet = myCube.GetQueryThree();
            }
            catch (Exception ex)
            {
                label1.Text = "Something went wrong! " + ex.Message;
            }
            label1.Text = "Employee count and total sale orders by store.";
            dataGridView1.DataSource = formDataSet;
            dataGridView1.DataMember = "CubeData3";
            dataGridView1.AutoResizeColumns();
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
        }
    }
}
