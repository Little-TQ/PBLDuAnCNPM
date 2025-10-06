using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jewelry.BLL;
using Jewelry.DTO;

namespace Jewelry
{
    public partial class EditInfoCustomer: Form
    {
        private bool isEditMode = false;
        public EditInfoCustomer()
        {
            InitializeComponent();
            btnEditCustomer.Click += btnEditCustomer_Click;
        }
        public EditInfoCustomer(string idCustomer, string nameCustomer, string phoneCustomer, string addressCustomer, bool isReadOnly) : this()
        {
            txtIDCustomer.Text = idCustomer;
            txtCustomerName.Text = nameCustomer;
            txtCustomerPhone.Text = phoneCustomer;
            txtCustomerAddress.Text = addressCustomer;
            SetReadOnly(isReadOnly);
        }
        public EditInfoCustomer(string idCustomer, string nameCustomer, string phoneCustomer, string addressCustomer, int point, bool isReadOnly) : this()
        {
            txtIDCustomer.Text = idCustomer;
            txtCustomerName.Text = nameCustomer;
            txtCustomerPhone.Text = phoneCustomer;
            txtCustomerAddress.Text = addressCustomer;
            txtCustomerPoint.Text = "0";
            SetReadOnly(isReadOnly);
        }
        private void SetReadOnly(bool isReadOnly)
        {
            txtIDCustomer.ReadOnly = isReadOnly;
            txtCustomerName.ReadOnly = isReadOnly ;
            txtCustomerPhone.ReadOnly = isReadOnly ;
            txtCustomerAddress.ReadOnly = isReadOnly ;
            txtCustomerPoint.ReadOnly = isReadOnly ;
            btnCompleteEditC.Enabled = !isReadOnly;
        }
        private void btnExitEditCustomer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReturnExitEditCustomer_Click(object sender, EventArgs e)
        {
            Customer frm = new Customer();
            this.Hide();
            frm.ShowDialog();
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            isEditMode = true;
            SetReadOnly(false);
            txtIDCustomer.ReadOnly = true;
            txtCustomerName.ReadOnly = true ;
            txtCustomerPoint.ReadOnly = true ;
        }

        private void btnCompleteEditC_Click(object sender, EventArgs e)
        {
            try
            {
                string idCustomer = txtIDCustomer.Text;
                string nameCustomer = txtCustomerName.Text.Trim();
                string phoneCustomer = txtCustomerPhone.Text;
                string addressCustomer = txtCustomerAddress.Text.Trim();
                if (!int.TryParse(txtCustomerPoint.Text, out int point))
                {
                    MessageBox.Show("Điểm khách hàng không hợp lệ!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CustomerBLL customerBLL = new CustomerBLL();
                bool success;

                if (isEditMode && !string.IsNullOrEmpty(idCustomer))
                {
                    // Update
                    CustomerDTO updatedCustomer = new CustomerDTO(idCustomer, nameCustomer, phoneCustomer, addressCustomer, point);
                    success = customerBLL.UpdateCustomer(updatedCustomer);
                    MessageBox.Show("Employee success updated!");

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
