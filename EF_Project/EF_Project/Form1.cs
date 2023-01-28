using EF_Project.Entity;
using EF_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_Project
{
    public partial class Form1 : Form
    {
        ProMarketEntities context = new ProMarketEntities();
        public Form1()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User foundedUser = context.Users.Where(x => x.Username == "admin").First();
            if (foundedUser.Username== txtUsername.Text.Trim().ToLower())
            {
                SHA256 hash = SHA256.Create();
                string password = txtPassword.Text.Trim();
                password = string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(c=>c.ToString()));
                if (foundedUser.Password==password)
                {
                    MessageBox.Show("Login successful..");
                    Form2 addCategoryForm = new Form2();
                    addCategoryForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid password! Please enter the correct password..");
                    txtUsername.Clear();
                    txtPassword.Clear();
                }
            }
            else
            {
                MessageBox.Show("Invalid username! Please try again..");
                txtUsername.Clear();
                txtPassword.Clear();
            }
        }
    }
}
