using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommandBuilder
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=10.10.22.199;Initial Catalog=NORTHWND2;User ID=test2;Password=test2");

        SqlDataAdapter dap;
        DataSet ds;
        DataTable tbl;
        SqlCommandBuilder cmb;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dap = new SqlDataAdapter("Select*From Customers", con);
            ds = new DataSet();
            dap.Fill(ds);
            cmb = new SqlCommandBuilder(dap);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            dap.Update(ds);
            
        }
    }
}
