namespace WindowsFormsApp3
{
    partial class UC_Home
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTotalProducts = new System.Windows.Forms.Label();
            this.lblInventoryValue = new System.Windows.Forms.Label();
            this.lblLowStock = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTotalProducts
            // 
            this.lblTotalProducts.AutoSize = true;
            this.lblTotalProducts.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblTotalProducts.ForeColor = System.Drawing.Color.White;
            this.lblTotalProducts.Location = new System.Drawing.Point(66, 204);
            this.lblTotalProducts.Name = "lblTotalProducts";
            this.lblTotalProducts.Size = new System.Drawing.Size(105, 16);
            this.lblTotalProducts.TabIndex = 0;
            this.lblTotalProducts.Text = "lblTotalProducts";
            // 
            // lblInventoryValue
            // 
            this.lblInventoryValue.AutoSize = true;
            this.lblInventoryValue.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblInventoryValue.ForeColor = System.Drawing.Color.White;
            this.lblInventoryValue.Location = new System.Drawing.Point(66, 255);
            this.lblInventoryValue.Name = "lblInventoryValue";
            this.lblInventoryValue.Size = new System.Drawing.Size(44, 16);
            this.lblInventoryValue.TabIndex = 1;
            this.lblInventoryValue.Text = "label1";
            // 
            // lblLowStock
            // 
            this.lblLowStock.AutoSize = true;
            this.lblLowStock.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblLowStock.ForeColor = System.Drawing.Color.White;
            this.lblLowStock.Location = new System.Drawing.Point(66, 306);
            this.lblLowStock.Name = "lblLowStock";
            this.lblLowStock.Size = new System.Drawing.Size(44, 16);
            this.lblLowStock.TabIndex = 2;
            this.lblLowStock.Text = "label1";
            // 
            // UC_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.Controls.Add(this.lblLowStock);
            this.Controls.Add(this.lblInventoryValue);
            this.Controls.Add(this.lblTotalProducts);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UC_Home";
            this.Size = new System.Drawing.Size(1031, 620);
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotalProducts;
        private System.Windows.Forms.Label lblInventoryValue;
        private System.Windows.Forms.Label lblLowStock;
    }
}
