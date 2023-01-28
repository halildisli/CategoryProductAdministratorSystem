using EF_Project.Entity;
using EF_Project.Models;
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

namespace EF_Project
{
    public partial class Form2 : Form
    {
        ProMarketEntities context { get; set; }
        public Form2()
        {
            InitializeComponent();
            context = new ProMarketEntities();

        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            context.Categories.Add(new Category() { Name = txtCategoryName.Text, Description = txtDescription.Text });
            context.SaveChanges();
            //listBoxCategories.DataSource = context.Categories.ToList(); //--> Listbox olursa ToString() methodlarını override etme gerekir.
            dataGridViewCategories.DataSource = context.Categories.ToList();
            txtCategoryName.Clear();
            txtDescription.Clear();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //listBoxCategories.DataSource = context.Categories.ToList(); //--> Listbox olursa ToString() methodlarını override etme gerekir.
            dataGridViewCategories.DataSource = context.Categories.ToList();
            dataGridViewCategories.Columns["Products"].Visible = false;

        }

        private void btnGoProductsPanel_Click(object sender, EventArgs e)
        {
            Form3 productsForm = new Form3();
            productsForm.Show();
            this.Hide();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewCategories.SelectedRows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure for update(s)?", "Update Category", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridViewCategories.SelectedRows)
                    {
                        context.Categories.Attach((Category)row.DataBoundItem);
                        context.Entry((Category)row.DataBoundItem).State = EntityState.Modified;
                    }
                    context.SaveChanges();
                }
                dataGridViewCategories.DataSource = context.Categories.ToList();
            }
            else
            {
                MessageBox.Show("You have not made any selections for the update!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCategories.SelectedRows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure for delete(s)?", "Delete Category", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridViewCategories.SelectedRows)
                    {
                        context.Categories.Remove((Category)row.DataBoundItem);
                    }
                    context.SaveChanges();
                }
                dataGridViewCategories.DataSource = context.Categories.ToList();
            }
            else
            {
                Console.WriteLine("You have not made any selections for the delete!");
            }
        }
    }
}
