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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            this.AcceptButton = btnReveal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            this.Hide();
            newForm.Show();
        }

        private void btnReveal_Click(object sender, EventArgs e)
        {
            
            if (txtPin.Text == "1234")
            {
                MessageBox.Show("Correct! Password is Coldsh!D&C184");
                Form2 newForm = new Form2();
                this.Hide();
                newForm.Show();
            }
            else
            {
                MessageBox.Show("Incorrect PIN.");
            }
        }
    }
}
