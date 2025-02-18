using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOWinform
{
    public partial class Form1 : Form
    {
        ContextADO db = new ContextADO();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            dataGridView1.DataSource = db.GetAll();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                Name = txtAddName.Text,
                Price = Convert.ToDecimal(txtAddPrice.Text),
                Quantity = Convert.ToInt32(txtAddQuantity.Text)
            };
            db.AddProduct(product);
            LoadData();
        }
        private void SelectColumn()
        {
            txtUpdateName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtUpdatePrice.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtUpdateQuantity.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectColumn();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                Name = txtUpdateName.Text,
                Price = Convert.ToDecimal(txtUpdatePrice.Text),
                Quantity = Convert.ToInt32(txtUpdateQuantity.Text)
            };
            db.UpdateProduct(product);
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            db.DeleteProduct(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            LoadData();
        }
    }
}
