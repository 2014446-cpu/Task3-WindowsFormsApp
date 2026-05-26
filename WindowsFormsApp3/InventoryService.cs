using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApp3
{
    internal class InventoryService
    {
        public static List<Product> LoadFromCSV(string filePath)
        {
            List<Product> products = new List<Product>();
            if (!File.Exists(filePath))
                return products;

            try
            {
                var lines = File.ReadAllLines(filePath).Skip(1);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length >= 5)
                    {
                        try
                        {
                            int id = int.Parse(parts[0]);
                            string name = parts[1];
                            string brand = parts[2];
                            decimal price = decimal.Parse(parts[3]) / 100m;
                            int quantity = int.Parse(parts[4]);

                            products.Add(new Product(id, name, brand, price, quantity));
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Error parsing line: {line}, Error: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error reading CSV file: {ex.Message}");
            }

            return products;
        }

        public static void SaveToCSV(string filePath, List<Product> products)
                {
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        // Match your new header exactly
                        writer.WriteLine("ProductID,ProductName,ProductBrand,Price,Quantity");

                        foreach (var p in products)
                        {
                            // Converts price back to cents for storage and includes quantity
                            string line = $"{p.ProductID},{p.ProductName},{p.ProductBrand},{p.ProductPrice * 100},{p.ProductQuantity}";
                            writer.WriteLine(line);


                        }
                    }
                }
            
        
    }
}


