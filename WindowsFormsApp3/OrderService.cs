using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    internal class OrderService
    {
       /* /public static List<Order> LoadFromCSV(string Filepath)
        {
            List<Order> orders = new List<Order>();
            if (!File.Exists(Filepath))
                return orders;

            try
            {
                var Lines = File.ReadAllLines(Filepath).Skip(1);

                foreach (string Line in Lines)
                {
                    string[] Parts = Line.Split(',');

                    if (Parts.Length >= 4)
                    {
                        try
                        {
                            int id = int.Parse(Parts[0]);
                            string name = Parts[1];
                            decimal price = decimal.Parse(Parts[2])/100m;
                            int quantity = int.Parse(Parts[3]);
                            decimal subtotal = int.Parse(Parts[4]);

                            orders.Add(item: new Order(id, name, price, quantity, subtotal));
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Error parsing line: {Line}, Error: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error reading CSV file: {ex.Message}");
            }

            return orders;
        }

        public static void SaveToCSV(string Filepath, List<Order> orders)
        {
            using (StreamWriter Writer = new StreamWriter(Filepath))
            {
                // Match your new header exactly
                Writer.WriteLine("ProductID,ProductName,UnitPrice,Quantity,Subtotal");

                foreach (var p in orders)
                {
                    // Converts price back to cents for storage and includes quantity
                    string Line = $"{p.ProductID},{p.ProductName},{p.UnitPrice * 100},{p.Quantity},{p.Subtotal}";
                    Writer.WriteLine(Line);*/

                    
                }
            }