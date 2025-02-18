using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBWebForm
{
    public partial class Form1 : Form
    {
        ContextDbWinForm _db = new ContextDbWinForm();

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            Combo();

        }

        private void LoadData()
        {
            if (_db.Products.Any() && _db.Categories.Any())
            {
                var result = _db.Products.GroupJoin(_db.Categories, p => p.CategoryId, c => c.Id,
                    (x, products) => new
                    {
                        Id = x.Id,
                        ProductName = x.Name,
                        ProductPrice = x.Price,
                        ProductQuantity = x.Quantity,
                        CategoryName = _db.Categories.Where(a => a.Id == x.CategoryId).Select(a => a.Name).FirstOrDefault()
                    }
                    ).ToList();
                dataGridView1.DataSource = result;
            }
            else
                dataGridView1.DataSource = new List<dynamic> { new { Message = "Boş" } };
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                Name = txtAddProduct.Text,
                Price = Convert.ToInt32(txtAddPrice.Text),
                Quantity = Convert.ToInt32(txtAddQuantity.Text),
                CategoryId = Convert.ToInt32(comboAddCategory.SelectedValue)
            };
            AddProduct(product);
            LoadData();
        }

        private void comboAddCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Combo()
        {
            comboAddCategory.DataSource = _db.Categories.ToList();
            comboAddCategory.ValueMember = "Id";
            comboAddCategory.DisplayMember = "Name";
            comboUpdateCategory.DataSource = _db.Categories.ToList();
            comboUpdateCategory.ValueMember = "Id";
            comboUpdateCategory.DisplayMember = "Name";
        }

        private void AddProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.GridColor = Color.Blue;
            txtUpdateProduct.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtUpdatePrice.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtUpdateQuantity.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void UpdateProduct(Product product)
        {
            var updated = _db.Entry(product);
            updated.State = EntityState.Modified;
            _db.SaveChanges();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                Name = txtUpdateProduct.Text,
                Price = Convert.ToDecimal(txtUpdatePrice.Text),
                Quantity = Convert.ToInt32(txtUpdateQuantity.Text),
                CategoryId = Convert.ToInt32(comboUpdateCategory.SelectedValue)
            };
            UpdateProduct(product);
            LoadData();
        }

        private void DeleteProduct(Product product)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            product = _db.Products.Where(x => x.Id == product.Id).First();
            _db.Products.Remove(product);
            _db.SaveChanges();
            LoadData();
        }
    }
}
