using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace WindowsFormsApp3
{
    public partial class UC_Inventory : UserControl
    {
        private BindingList<Product> _inventoryList = new BindingList<Product>();
        private BindingSource _bindingSource = new BindingSource();
        string filePath = "product.csv";
        public UC_Inventory()
        {
            InitializeComponent();
            _bindingSource.DataSource = _inventoryList;
            dgvInventory.AutoGenerateColumns = false;
            dgvInventory.DataSource = _bindingSource;
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            LoadDataFromCSV();

        }

        private void LoadDataFromCSV()
        {
            var tempData = InventoryService.LoadFromCSV(filePath);
            _inventoryList.Clear();

            foreach (var item in tempData)
            {
                _inventoryList.Add(item);
            }

            dgvInventory.DataSource = _inventoryList;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;
            int newId = _inventoryList.Count + 1000;
            string name = txtName.Text;
            string brand = txtBrand.Text;
            decimal price = decimal.Parse(txtPrice.Text);
            int quantity = int.Parse(txtQuantity.Text);

            Product newProduct = new Product(newId, name, brand, price, quantity);
            _inventoryList.Add(newProduct);

            // 4. Refresh the grid to show the new item
            _bindingSource.ResetBindings(false);


            // 5. Clear fields for the next entry
            ClearFields();
        }

        private bool ValidateInputs()
        {
            // Check if Name contains invalid special characters like #, $, @
            // This regex allows only letters, numbers, and spaces
            if (!Regex.IsMatch(txtName.Text, @"^[a-zA-Z0-9 ]+$"))
            {
                MessageBox.Show("Product Name contains invalid characters.");
                return false;
            }


            // Check if Price is a positive decimal
            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Please enter a valid positive price.");
                return false;
            }

            // Check if Quantity is a positive integer
            if (!int.TryParse(txtQuantity.Text, out int qty) || qty < 0)
            {
                MessageBox.Show("Please enter a valid positive quantity.");
                return false;
            }

            return true;
        }
        private void ClearFields()
        {
            txtID.Clear();
            txtName.Clear();
            txtBrand.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // 1. Check if a Product ID is present to identify the record
            if (!int.TryParse(txtID.Text, out int idToUpdate))
            {
                MessageBox.Show("Please select a product from the grid to update by entering product ID.");
                return;
            }

            // 2. Find the product in the BindingList using the ID
            var productToUpdate = _inventoryList.FirstOrDefault(p => p.ProductID == idToUpdate);

            if (productToUpdate != null)
            {
                // 3. Validate the new inputs before applying changes
                if (ValidateInputs())
                {
                    // 4. Update the object properties (excluding ProductID)
                    productToUpdate.ProductName = txtName.Text;
                    productToUpdate.ProductBrand = txtBrand.Text;
                    productToUpdate.ProductPrice = decimal.Parse(txtPrice.Text);
                    productToUpdate.ProductQuantity = int.Parse(txtQuantity.Text);

                    // 5. Refresh the grid to show the updated data
                    _bindingSource.ResetBindings(false);
                    dgvInventory.Refresh();

                    // 6. Clear input fields
                    ClearFields();
                    MessageBox.Show("Product updated successfully in the list.");
                }
            }
            else
            {
                MessageBox.Show("Product ID not found in inventory.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string searchTerm = txtDelete.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                MessageBox.Show("Please enter a valid Product ID or Name to delete.");
                return;
            }

            // Find the product in the BindingList
            // This checks if the ID matches OR if the Name matches (ignoring case)
            Product productToDelete = _inventoryList.FirstOrDefault(p =>
                p.ProductID.ToString() == searchTerm ||
                p.ProductName.Equals(searchTerm, StringComparison.OrdinalIgnoreCase));

            if (productToDelete != null)
            {
                // Confirm deletion with the user
                DialogResult result = MessageBox.Show($"Are you sure you want to delete {productToDelete.ProductName}?",
                    $"Confirm Delete", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // Remove from the BindingList (the grid will update automatically)
                    _inventoryList.Remove(productToDelete);



                    txtDelete.Clear();
                    MessageBox.Show("Product deleted successfully.");
                }
            }
            else
            {
                MessageBox.Show("No product found matching that ID or Name.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                dgvInventory.EndEdit();
                _bindingSource.EndEdit();

                // Convert BindingList to List
                List<Product> listToSave = _inventoryList.ToList();


                // Save to CSV file
                InventoryService.SaveToCSV(filePath, listToSave);

                // Reload from CSV to refresh grid with saved data
                LoadDataFromCSV();

                MessageBox.Show("Changes saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBrand.Clear();
            txtID.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
        }

        private void txtDelete_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvInventory.SelectedRows.Count > 0) // make sure user select at least 1 row 
            {
                string ID = dgvInventory.SelectedRows[0].Cells[0].Value + string.Empty;
                string Remove = dgvInventory.SelectedRows[0].Cells[0].Value + string.Empty;
                string Name = dgvInventory.SelectedRows[0].Cells[1].Value + string.Empty;
                string Price = dgvInventory.SelectedRows[0].Cells[3].Value + string.Empty;
                string Brand = dgvInventory.SelectedRows[0].Cells[2].Value + string.Empty;
                string BrandName = dgvInventory.SelectedRows[0].Cells[4].Value + string.Empty;

                txtID.Text = ID;
                txtName.Text = Name;
                txtPrice.Text = Price;
                txtBrand.Text = Brand;
                txtQuantity.Text = BrandName;
                txtDelete.Text = Remove;

            }
        }

       private void UC_Inventory_Leave(object sender, EventArgs e)
            {
                try
                {
                    dgvInventory.EndEdit();
                    _bindingSource.EndEdit();

                    List<Product> listToSave = _inventoryList.ToList();
                    InventoryService.SaveToCSV(filePath, listToSave);

                    // Optional: You can remove the MessageBox here so it doesn't pop up every time
                    // MessageBox.Show("Changes auto-saved.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error auto-saving: " + ex.Message);
                }
            }
        }
    }