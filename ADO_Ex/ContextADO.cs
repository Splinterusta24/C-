using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOWinform
{
    public class ContextADO
    {
        SqlConnection sql = new SqlConnection(@"Server=DESKTOP-TMKMPDJ\SQLEXPRESS;Database=ADOWinform;Trusted_Connection=True;");
        public List<Product> GetAll()
        {
            SqlCommand cmd = new SqlCommand(@"Select * from Product", sql);
            List<Product> list = new List<Product>();
            if (sql.State == ConnectionState.Closed)
                sql.Open();
            var result = cmd.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(result);
            foreach (DataRow item in data.Rows)
            {
                Product product = new Product
                {
                    Name = item["Name"].ToString(),
                };
                list.Add(product);
            }
            while (data.Rows.Count != 0)
            {
                
            }
            sql.Close();
            return list;
        }
        public void AddProduct(Product product)
        {
            SqlCommand cmd = new SqlCommand(@"INSERT Product(Name,Price,Quantity) VALUES(@name,@price,@quantity)", sql);
            if (sql.State == ConnectionState.Closed)
                sql.Open();
            cmd.Parameters.AddWithValue("name", product.Name);
            cmd.Parameters.AddWithValue("price", product.Price);
            cmd.Parameters.AddWithValue("quantity", product.Quantity);
            cmd.ExecuteNonQuery();
            sql.Close();
        }
        public void UpdateProduct(Product product)
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE Product SET Name = @name, Price = @price, Quantity = @quantity where Id = @id", sql);
            if (sql.State == ConnectionState.Closed)
                sql.Open();
            cmd.Parameters.AddWithValue("name", product.Name);
            cmd.Parameters.AddWithValue("id", product.Id);
            cmd.Parameters.AddWithValue("price", product.Price);
            cmd.Parameters.AddWithValue("quantity", product.Quantity);
            cmd.ExecuteNonQuery();
            sql.Close();
        }
        public void DeleteProduct(int id)
        {
            SqlCommand cmd = new SqlCommand(@"Delete from Product where Id = @id", sql);
            if (sql.State == ConnectionState.Closed)
                sql.Open();
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
            sql.Close();
        }


    }
}
