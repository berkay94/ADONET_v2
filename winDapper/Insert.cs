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
using Dapper;


namespace winDapper
{
    public partial class Insert : Form
    {
        SqlConnection con = new SqlConnection("Data Source=10.10.22.199;Initial Catalog=NORTHWND2;User ID=test2;Password=test2");
        public Insert()
        {
            InitializeComponent();
        }

        private void Insert_Load(object sender, EventArgs e)
        {
            var suppliers = con.Query<Suppliers>("Select * From Suppliers");
            comboBox1.DataSource = suppliers;
            comboBox1.DisplayMember = "CompanyName";
            comboBox1.ValueMember = "SupplierID";


            var categories = con.Query<Categories>("Select * From Categories");
            comboBox2.DataSource = categories;
            comboBox2.DisplayMember = "CategoryName";
            comboBox2.ValueMember = "CategoryID";


        }

        private void button1_Click(object sender, EventArgs e)
        {
           




        }

        
    }
}
