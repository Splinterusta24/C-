using Dbfirst.Model;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dbfirst
{
    public partial class lblSearch : Form
    {
        NortwindEntities db = new NortwindEntities();
        public lblSearch()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            combo();
            combo2();

        }

        private void LoadData(string search = "")
        {
            var result = from p in db.Products
                         join c in db.Categories on p.CategoryID equals c.CategoryID
                         select new
                         {
                             Id = p.ProductID,
                             Kategorisi = c.CategoryName,
                             ÜrünAdı = p.ProductName,
                             Stok = p.UnitsInStock,
                             Fiyat = p.UnitPrice
                         };
            if (search == "")
                dataGridView1.DataSource = result.ToList();
            else
                dataGridView1.DataSource = result.Where(x => x.ÜrünAdı.Contains(search) || x.Kategorisi.Contains(search)).ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Products product = new Products();
            product.ProductID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            product.ProductName = textBox1.Text;
            product.UnitPrice = Convert.ToDecimal(textBox2.Text);
            product.UnitsInStock = Convert.ToInt16(textBox3.Text);
            product.CategoryID = Convert.ToInt32(comboBox1.SelectedValue);
            AddProduct(product);
            LoadData();
        }
        private void AddProduct(Products product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        private List<Categories> GetCategories()
        {
            var result = db.Categories.ToList();
            return result;
        }

        private void combo()
        {
            comboBox1.DataSource = GetCategories().ToList();
            comboBox1.DisplayMember = "CategoryName";
            comboBox1.ValueMember = "CategoryID";
        }

        private void combo2()
        {
            comboBox2.DataSource = GetCategories().ToList();
            comboBox2.DisplayMember = "CategoryName";
            comboBox2.ValueMember = "CategoryID";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Products product = new Products
            {
                ProductID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                ProductName = textBox4.Text,
                CategoryID = Convert.ToInt32(comboBox2.SelectedValue),
                UnitPrice = Convert.ToDecimal(textBox6.Text),
                UnitsInStock = Convert.ToInt16(textBox5.Text)
            };
            UpdateProduct(product);
            LoadData();
        }

        private void UpdateProduct(Products product)
        {
            var updateProduct = db.Products.Where(x => x.ProductID == product.ProductID).Single();
            updateProduct.ProductName = product.ProductName;
            updateProduct.CategoryID = product.CategoryID;
            updateProduct.UnitPrice = product.UnitPrice;
            updateProduct.UnitsInStock = product.UnitsInStock;

            db.SaveChanges();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(textSearch.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            var productId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            products = db.Products.Where(x => x.ProductID == productId).First();
            Delete(products);
            LoadData();
        }

        private void Delete(Products product)
        {
            db.Products.Remove(product);
            var deletedItems = db.Order_Details.Where(x => x.ProductID == product.ProductID).ToList();
            db.Order_Details.RemoveRange(deletedItems);
            db.SaveChanges();
        }
    }
}
