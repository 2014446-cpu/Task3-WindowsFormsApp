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
        private int maxAttempts = 5; // Maximum allowed invalid attempts
        private int failedAttempts = 0;       // Counter for failed attempts
        private const int LockoutSeconds = 60; // Lockout duration in seconds
        private Timer lockoutTimer;
        private int remainingSeconds;
        public Form4()
        {
            InitializeComponent();
            this.AcceptButton = btnReveal;

            // Create and configure the lockout timer
            lockoutTimer = new Timer();
            lockoutTimer.Interval = 1000; // 1 second
            lockoutTimer.Tick += tmrLockout_Tick;
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
                failedAttempts = 0;
                MessageBox.Show("Correct! Password is Coldsh!D&C184");
                Form2 newForm = new Form2();
                this.Hide();
                newForm.Show();
            }
            else
            {
                failedAttempts++;
                MessageBox.Show($"Invalid attempt {failedAttempts} of {maxAttempts}. Please try again."); ;
            }
            if (failedAttempts >= maxAttempts)
            {
                StartLockout();
            }
        }

        private void tmrLockout_Tick(object sender, EventArgs e)
        {
            remainingSeconds--;
            btnReveal.Text = $"Locked ({remainingSeconds}s)";

            if (remainingSeconds <= 0)
            {
                lockoutTimer.Stop();
                btnReveal.Enabled = true;
                btnReveal.Text = "Login";
                failedAttempts = 0; // Reset attempts after lockout
            }
        }
        private void StartLockout()
        {
            btnReveal.Enabled = false; // Disable login button
            txtPin.Enabled = false; // Disable PIN input
            remainingSeconds = LockoutSeconds;
            lockoutTimer.Start();
            MessageBox.Show($"Too many failed attempts. Try again in {LockoutSeconds} seconds.");
        }
    }
}
