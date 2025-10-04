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

namespace Jewelry.FolderProduct
{
    public partial class Property : UserControl
    {
        private PropertyBLL propertyBLL = new PropertyBLL();
        public Property()
        {
            InitializeComponent();
        }

        private void Property_Load(object sender, EventArgs e)
        {
            cbChoice.SelectedIndex = 0; // mặc định Category
            LoadPropertyData();
        }

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
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cbChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPropertyData();
        }
    }
}
