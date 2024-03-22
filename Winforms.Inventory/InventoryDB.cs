using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Vladimir Gvaramadze N01636204
namespace Winforms.Inventory
{
    public static class InventoryDB
    {
        private static readonly string Path = @"C:\Users\GVARA\Desktop\Humber-Semest-2\Application-Dev-using-C#.NET-ITE-5230-IRA\Winforms.Inventory_Vladimir_Gvaramadze\grocery_inventory_items.txt";
        private const string Delimiter = "|";

        public static List<InventoryItem> GetItems()
        {
            List<InventoryItem> items = new List<InventoryItem>();
            try
            {
                using (StreamReader textIn = new StreamReader(new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Read)))
                {
                    string row;
                    while ((row = textIn.ReadLine()) != null)
                    {
                        string[] columns = row.Split('|');


                        if (columns.Length == 3)
                        {
                            InventoryItem item = new InventoryItem
                            {
                                ItemNo = ParseInt(columns[0], "ItemNo"),
                                Description = columns[1],
                                Price = ParseDecimal(columns[2], "Price")
                            };
                            items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading from file: " + ex.Message);
            }
                return items;
        }

        private static int ParseInt(string value, string name)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            else
            {
                throw new Exception("Invalid value for " + name + ": " + value);
            }
        }

        private static decimal ParseDecimal(string value, string name)
        {
            if (decimal.TryParse(value, out decimal result))
            {
                return result;
            }
            else
            {
                throw new Exception("Invalid value for " + name + ": " + value);
            }
        }

        public static void SaveItems(List<InventoryItem> items)
        {
            try
            {
                using (StreamWriter textOut = new StreamWriter(new FileStream(Path, FileMode.Create, FileAccess.Write)))
                {
                    foreach (InventoryItem item in items)
                    {
                        textOut.Write(item.ItemNo + Delimiter);
                        textOut.Write(item.Description + Delimiter);
                        textOut.WriteLine(item.Price);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to file: " + ex.Message);
            }
        }
    }

    public class InventoryItem
    {
        public int ItemNo { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{ItemNo} | {Description} | {Price:C}";
        }
    }
}
