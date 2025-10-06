using Jewelry.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jewelry.FolderProduct
{
    public partial class Property : UserControl
    {
        private PropertyBLL propertyBLL = new PropertyBLL();
        private string selectedID = "";
        public Property()
        {
            InitializeComponent();
        }

        private void Property_Load(object sender, EventArgs e)
        {
            cbChoice.SelectedIndex = 0; // mặc định Category
            LoadPropertyData();
        }

        //Load Data
        private void LoadPropertyData()
        {
            string selectedTable = cbChoice.SelectedItem.ToString();
            DataTable dt = propertyBLL.GetPropertyData(selectedTable);

            dgvProperty.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                string id = "";
                string name = "";

                switch (selectedTable)
                {
                    case "Category":
                        id = row["idCategory"].ToString();
                        name = row["NameCategory"].ToString();
                        break;
                    case "Material":
                        id = row["idMaterial"].ToString();
                        name = row["NameMaterial"].ToString();
                        break;
                    case "Color":
                        id = row["idColor"].ToString();
                        name = row["NameColor"].ToString();
                        break;
                    case "Collection":
                        id = row["idCollection"].ToString();
                        name = row["NameCollection"].ToString();
                        break;
                    case "Gender":
                        id = row["idGender"].ToString();
                        name = row["NameGender"].ToString();
                        break;
                }

                dgvProperty.Rows.Add(id, name);
            }
            dgvProperty.ClearSelection();
            dgvProperty.RowTemplate.Height = 35;
        }
        private void LoadPropertyData(string tableName)
        {
            try
            {
                DataTable dt = propertyBLL.GetPropertyData(tableName);
                dgvProperty.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Exit 
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cbChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPropertyData();
        }
        //Btn Add New
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            if (cbChoice.SelectedItem == null)
            {
                MessageBox.Show("Please select a property type first.");
                return;
            }

            string tableName = cbChoice.SelectedItem.ToString();

            Product_AddProperty editForm = new Product_AddProperty(tableName);

            editForm.OnItemAdded += (newID, newName) =>
            {
                AddRowToDgv(newID, newName);
            };

            editForm.ShowDialog();
        }
        private void AddRowToDgv(string id, string name)
        {
            int index = dgvProperty.Rows.Add(); 
            dgvProperty.Rows[index].Cells[0].Value = id;
            dgvProperty.Rows[index].Cells[1].Value = name;
        }

        private void dgvProperty_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>= 0)
            {
                selectedID = dgvProperty.Rows[e.RowIndex].Cells[0].Value?.ToString();
            }
        }
       

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedID))
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }
            string tableName = cbChoice.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(tableName))
            {
                MessageBox.Show("Please select a property type first.");
                return;
            }
            string idColumn = "";
            switch (tableName.ToLower())
            {
                case "category": idColumn = "idCategory"; break;
                case "material": idColumn = "idMaterial"; break;
                case "color": idColumn = "idColor"; break;
                case "collection": idColumn = "idCollection"; break;
                default:
                    MessageBox.Show("Invalid property type.");
                    return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                PropertyBLL propertyBLL = new PropertyBLL();
                bool result = propertyBLL.DeletePropertyItem(tableName, idColumn, selectedID);

                if (result)
                {
                    MessageBox.Show("Deleted successfully!");
                    // Xóa dòng khỏi dgv
                    foreach (DataGridViewRow row in dgvProperty.Rows)
                    {
                        if (row.Cells[0].Value?.ToString() == selectedID)
                        {
                            dgvProperty.Rows.Remove(row);
                            break;
                        }
                    }
                    selectedID = "";
                }
                else
                {
                    MessageBox.Show("Delete failed!");
                }
            }
        }
    }
}
