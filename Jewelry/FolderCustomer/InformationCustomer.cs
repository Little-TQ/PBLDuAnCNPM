using Jewelry.BLL;
using Jewelry.DAL;
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
        private DataTable currentCustomer;
        public InformationCustomer() 
        {
            InitializeComponent();
            currentCustomer = new DataTable();
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
                DataTable filtered = view.ToTable(false, "idCustomer", "NameCustomer", "PhoneNumberC", "AddressC", "Point");

                currentCustomer = filtered;
                dgvCustomerInfo.DataSource = currentCustomer;

                dgvCustomerInfo.Columns["idCustomer"].HeaderText = "ID";
                dgvCustomerInfo.Columns["NameCustomer"].HeaderText = "Name";
                dgvCustomerInfo.Columns["PhoneNumberC"].HeaderText = "Phone";
                dgvCustomerInfo.Columns["AddressC"].HeaderText = "Address";
                dgvCustomerInfo.Columns["Point"].HeaderText = "Point";

                dgvCustomerInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvCustomerInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvCustomerInfo.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message);
            }
        }
        private void dgvCustomerInfo_DoubleClick(object sender, EventArgs e)
        {
            if (dgvCustomerInfo.CurrentRow != null && dgvCustomerInfo.CurrentRow.Index >= 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow row = dgvCustomerInfo.CurrentRow;

                // Lấy thông tin khc
                string idCustomer = row.Cells["idCustomer"].Value?.ToString();
                string nameCustomer = row.Cells["NameCustomer"].Value?.ToString();
                string phoneCustomer = row.Cells["PhoneNumberC"].Value?.ToString();
                string addressCustomer = row.Cells["AddressC"].Value?.ToString();
                int point = row.Cells["Point"].Value != null ? (int)row.Cells["Point"].Value : 0;

                // Mở form EditCstomer
                EditInfoCustomer frm = new EditInfoCustomer(idCustomer, nameCustomer, phoneCustomer, addressCustomer, point, true);

                // Hiện form chỉnh sửa
                frm.btnEditCustomer.Visible = true;   // đảm bảo nút Edit hiện
                frm.ShowDialog();

                // Sau khi edit thì reload danh sách nhân viên
                LoadCustomerData();
            }
        }
        private void FilterData()
        {
            if (currentCustomer.Rows.Count == 0) return;

            try
            {
                string search = txtSearchCustomer.Text.Trim().ToLower();

                if (string.IsNullOrEmpty(search))
                {
                    // Hiển thị tất cả dữ liệu
                    dgvCustomerInfo.DataSource = currentCustomer;
                }
                else
                {
                    // Lọc dữ liệu theo nhiều cột
                    var filteredRows = currentCustomer.AsEnumerable()
                        .Where(r =>
                            r.Field<string>("NameCustomer")?.ToLower().Contains(search) == true ||
                            r.Field<string>("idCustomer")?.ToLower().Contains(search) == true ||
                            r.Field<string>("PhoneNumberC")?.ToLower().Contains(search) == true ||
                            r.Field<string>("AddressC")?.ToLower().Contains(search) == true ||
                            r.Field<int>("Point").ToString().Contains(search) == true)
                        .ToArray();

                    if (filteredRows.Length > 0)
                    {
                        DataTable filteredTable = filteredRows.CopyToDataTable();
                        dgvCustomerInfo.DataSource = filteredTable;
                    }
                    else
                    {
                        // Hiển thị table rỗng nếu không tìm thấy
                        dgvCustomerInfo.DataSource = currentCustomer.Clone();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error search: " + ex.Message);
                // Nếu có lỗi, hiển thị lại toàn bộ dữ liệu
                dgvCustomerInfo.DataSource = currentCustomer;
            }
        }
        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }
    }
    
}
