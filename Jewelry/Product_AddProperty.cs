using Jewelry.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using Jewelry.BLL;

namespace Jewelry
{
    public partial class Product_AddProperty : Form
    {
        private PropertyBLL propertyBLL = new PropertyBLL();
        private string currentTable;
        public Product_AddProperty(string tableName)
        {
            InitializeComponent();
            currentTable = tableName;
        }

        private void Product_AddProperty_Load(object sender, EventArgs e)
        {

        }
        public event Action<string, string> OnItemAdded;
        //Btn OK
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Please enter a name.");
                    return;
                }
                string newID = propertyBLL.GenerateNewPropertyID(currentTable);

               
                string columnName = "";
                switch (currentTable.ToLower())
                {
                    case "category": columnName = "nameCategory"; break;
                    case "material": columnName = "nameMaterial"; break;
                    case "color": columnName = "nameColor"; break;
                    case "collection": columnName = "nameCollection"; break;
                    default:
                        MessageBox.Show("Invalid property type.");
                        return;
                }

                bool result = propertyBLL.AddPropertyItem(currentTable, columnName, name, newID);

                if (result)
                {
                    MessageBox.Show("Added successfully!");
                  
                    OnItemAdded?.Invoke(newID, name);

                    txtName.Clear();
                }
                else
                {
                    MessageBox.Show("Failed to add item!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
