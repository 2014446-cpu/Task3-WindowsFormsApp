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
        private int maxAttempts = 5; // Maximum allowed invalid attempts
        private int failedAttempts = 0;       // Counter for failed attempts
        private const int LockoutSeconds = 60; // Lockout duration in seconds
        private Timer lockoutTimer;
        private int remainingSeconds;
        public Form2()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;

            // Initialize lockout timer
            lockoutTimer = new Timer();
            lockoutTimer.Interval = 1000; // 1 second
            lockoutTimer.Tick += tmrLockout_Tick;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter both username and password.");
            }


            string username = "Coldshi184";
            string password = "Coldsh!D&C184";


            if (username == txtUsername.Text && password == txtPassword.Text)
            {
                Form1 newForm = new Form1(); // Create an instance of Form1
                this.Hide(); // Optionally hide the current form
                newForm.Show(); // Show the new form
                failedAttempts = 0; // Reset failed attempts on successful login
            }
            else
            {
                failedAttempts++;
            }


            if (failedAttempts >= maxAttempts)
            {

                StartLockout();
            }
            else
            {
                MessageBox.Show($"Invalid attempt {failedAttempts} of {maxAttempts}. Please try again.");
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

        private void btnForgot_Click(object sender, EventArgs e)
        {
            Form4 newForm = new Form4();
            this.Hide();
            newForm.Show();
        }

        private void tmrLockout_Tick(object sender, EventArgs e)
        {
            remainingSeconds--;

            if (remainingSeconds <= 0)
            {
                lockoutTimer.Stop();
                btnLogin.Enabled = true;
                txtPassword.Enabled = true;
                txtUsername.Enabled = true;
                failedAttempts = 0; // Reset attempts
                MessageBox.Show("You can try logging in again.", "Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void StartLockout()
        {
            btnLogin.Enabled = false;
            txtPassword.Enabled = false;
            txtUsername.Enabled = false;
            remainingSeconds = LockoutSeconds;
            MessageBox.Show($"Too many failed attempts. Please wait {LockoutSeconds} seconds.", "Locked Out", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            lockoutTimer.Start();
        }
    }
}
