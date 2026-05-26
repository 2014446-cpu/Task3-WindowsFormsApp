using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            { 
            MessageBox.Show("Please enter both username and password.");
                return;
            }



            string username = "Coldshi184";
            string password = "Coldsh!D&C184";


            if (username == txtUsername.Text && password == txtPassword.Text)
            {
                Form1 newForm = new Form1(); // Create an instance of Form1
                this.Hide(); // Optionally hide the current form
                newForm.Show(); // Show the new form
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.UseSystemPasswordChar = false; // Show password
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true; // Hide password
            }
        }
    }
}
