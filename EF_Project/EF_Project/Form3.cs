using EF_Project.Entity;
using EF_Project.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_Project
{
    public partial class Form3 : Form
    {
        ProMarketEntities context = new ProMarketEntities();
        public Form3()
        {
            InitializeComponent();
            nudUnitPrice.Minimum = 1;
            nudUnitPrice.DecimalPlaces = 2;
            nudStock.Minimum = 1;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridViewProducts.DataSource = context.Products.ToList();
            comboBoxCategories.Items.AddRange(context.Categories.ToArray());
            dataGridViewProducts.Columns["Category"].Visible = false;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            Category choosedCategory = (Category)comboBoxCategories.SelectedItem;
            string newProductName = txtProductName.Text;
            decimal newUnitPrice = nudUnitPrice.Value;
            int newProductStock = (int)nudStock.Value;
            if (newProductName != null || newProductName != "")
            {
                Product newProduct = new Product()
                {
                    Name = newProductName,
                    CategoryID = choosedCategory.CategoryID,
                    UnitPrice = newUnitPrice,
                    UnitsInStock = newProductStock
                };
                context.Products.Add(newProduct);
                context.SaveChanges();
                dataGridViewProducts.DataSource = context.Products.ToList();
            }
            else
            {
                MessageBox.Show("Missing value! Please enter all values..");
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count > 0)
            {
                Product updatedProduct = (Product)dataGridViewProducts.SelectedRows[0].DataBoundItem;
                context.Products.Attach(updatedProduct);
                context.Entry(updatedProduct).State = EntityState.Modified;
                context.SaveChanges();
            }
            else
            {
                MessageBox.Show("You need to select the entire row you want to update!");
            }

        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Do you want to delete the selected item(s)?", "Delete Product", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in dataGridViewProducts.SelectedRows)
                    {
                        context.Products.Remove((Product)item.DataBoundItem);
                    }
                    context.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine("You have not made any selections for the delete!");
            }
            dataGridViewProducts.DataSource = context.Products.ToList();
        }

        private void btnBackToCategoryPanel_Click(object sender, EventArgs e)
        {
            Form2 categoryForm = new Form2();
            categoryForm.Show();
            this.Hide();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
