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

namespace Jewelry.FolderCustomer
{
    public partial class InformationCustomer: UserControl
    {
        private CustomerBLL customerBLL = new CustomerBLL();
        public InformationCustomer()
        {
            InitializeComponent();
        }

        private void InformationCustomer_Load(object sender, EventArgs e)
        {
            LoadCustomerData();
        }
        private void LoadCustomerData()
        {
            try
            {
                DataTable dt = customerBLL.GetAllCustomers();

               
                DataView view = new DataView(dt);
                DataTable filtered = view.ToTable(false, "idCustomer", "NameCustomer", "PhoneNumberC", "AddressC");

                dgvCustomerInfo.DataSource = filtered;

                dgvCustomerInfo.Columns["idCustomer"].HeaderText = "ID";
                dgvCustomerInfo.Columns["NameCustomer"].HeaderText = "Name";
                dgvCustomerInfo.Columns["PhoneNumberC"].HeaderText = "Phone";
                dgvCustomerInfo.Columns["AddressC"].HeaderText = "Address";

                dgvCustomerInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvCustomerInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvCustomerInfo.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message);
            }
        }
    }
    
}
