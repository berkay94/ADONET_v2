﻿
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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=10.10.22.199;Initial Catalog=NORTHWND2;User ID=test2;Password=test2");



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //var cat = new Categories();
            //cat.CategoryName = "10 ocak";
            //cat.Description = "deneme3";
            //string sql= "INSERT INTO Categories(CategoryName,Description) Values(@CategoryName,@Description)";
            //con.Execute(sql, cat);


            var categories =con.Query<Categories>("Select * From Categories");
            comboBox1.DataSource = categories;
            comboBox1.DisplayMember = "CategoryName";
            comboBox1.ValueMember = "CategoryID";

            



        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var param = new DynamicParameters();
                var id = ((winDapper.Products)(listBox1.SelectedItem)).ProductId;

                var siparis = con.Query<Procedure>("UrunSiparisleri", new { productId = id }, commandType: CommandType.StoredProcedure);
                dataGridView1.DataSource = siparis;
            }
            catch
            {

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               var products = con.Query<Products>("Select ProductId,ProductName From Products Where CategoryId=@categoryId",comboBox1.SelectedItem);
               listBox1.DataSource = products;
               listBox1.DisplayMember = "ProductName";
               listBox1.ValueMember = "ProductId";
            }
            catch 
            {

                
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            var id = dataGridView1.CurrentRow.Cells[1].Value;
            var det = con.Query<OrderDetails>("Select * From [Order Details] Where OrderId=@orderId",new {OrderId=id});
            dataGridView2.DataSource = det;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1_MouseClick(null, null);
        }

        private void ınsertProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Insert form = new Insert();
            form.Show();
               
        }
    }
}
