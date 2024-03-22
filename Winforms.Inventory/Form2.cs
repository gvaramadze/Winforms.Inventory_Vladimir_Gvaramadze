using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Vladimir Gvaramadze N01636204
namespace Winforms.Inventory
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtItem_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                InventoryItem newItem = new InventoryItem
                {
                    ItemNo = ParseInt(txtItem.Text, "ItemNo"),
                    Description = txtDescription.Text,
                    Price = ParseDecimal(txtPrice.Text, "Price")
                };

                List<InventoryItem> existingItems = InventoryDB.GetItems();

                existingItems.Add(newItem);

                InventoryDB.SaveItems(existingItems);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

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
    }
}
