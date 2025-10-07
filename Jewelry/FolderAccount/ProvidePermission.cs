using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jewelry.BLL;
using Jewelry.DTO;

namespace Jewelry.Account
{
    public partial class Provide_Permission : UserControl
    {
        private PermissionBLL permissionBLL = new PermissionBLL();
        public Provide_Permission()
        {
            InitializeComponent();
            LoadPermissions();
        }
        private void LoadPermissions()
        {
            DataTable dt = permissionBLL.GetAccountPermissions();
            dataGridViewPermission.DataSource = dt;

            // Ignore ID column
            dataGridViewPermission.Columns["idAccount"].Visible = false;

            //Set header name
            dataGridViewPermission.Columns["Username"].HeaderText = "Username";
            dataGridViewPermission.Columns["RoleName"].HeaderText = "Role";
            dataGridViewPermission.Columns["Account"].HeaderText = "Account";
            dataGridViewPermission.Columns["Overview"].HeaderText = "Overview";
            dataGridViewPermission.Columns["Product"].HeaderText = "Product";
            dataGridViewPermission.Columns["Customer"].HeaderText = "Customer";
            dataGridViewPermission.Columns["Employee"].HeaderText = "Employee";
            dataGridViewPermission.Columns["Payment"].HeaderText = "Payment";
            dataGridViewPermission.Columns["Invoice"].HeaderText = "Invoice";
            dataGridViewPermission.Columns["Update"].HeaderText = "Update Price";
        }

        private void btnSavePermission_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridViewPermission.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var dto = new AccountPermissionDTO
                        {
                            AccountId = row.Cells["idAccount"].Value.ToString(),
                            Username = row.Cells["Username"].Value.ToString(),
                            RoleName = row.Cells["RoleName"].Value.ToString(),
                            Account = Convert.ToBoolean(row.Cells["Account"].Value),
                            Overview = Convert.ToBoolean(row.Cells["Overview"].Value),
                            Product = Convert.ToBoolean(row.Cells["Product"].Value),
                            Customer = Convert.ToBoolean(row.Cells["Customer"].Value),
                            Employee = Convert.ToBoolean(row.Cells["Employee"].Value),
                            Payment = Convert.ToBoolean(row.Cells["Payment"].Value),
                            Invoice = Convert.ToBoolean(row.Cells["Invoice"].Value),
                            Update = Convert.ToBoolean(row.Cells["Update"].Value)
                        };

                        permissionBLL.UpdatePermissions(dto);
                    }
                }
                MessageBox.Show("Updated susccessfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void btnViewPermission_Click(object sender, EventArgs e)
        {
            
        }

        private void Provide_Permission_Load(object sender, EventArgs e)
        {

        }
    }
}
