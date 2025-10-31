using Jewelry.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jewelry.FolderCustomer
{
    public partial class MembershipClass: UserControl
    {
        private CustomerBLL customerBLL = new CustomerBLL();
        private DataTable currentCustomer;
        public MembershipClass()
        {
            InitializeComponent();
        }

        private void MembershipClass_Load(object sender, EventArgs e)
        {
            LoadMembershipData();
            LoadRankStatisticsFromDB();
        }
        //Load Data
        private void LoadMembershipData()
        {
            try
            {
                
                DataTable dt = customerBLL.GetAllCustomers();

                DataView view = new DataView(dt);
                DataTable filtered = view.ToTable(false, "NameCustomer", "PhoneNumberC", "Point","Membership");

                currentCustomer = filtered;
                dgvMembershipC.DataSource = currentCustomer;

                dgvMembershipC.Columns["NameCustomer"].HeaderText = "Customer";
                dgvMembershipC.Columns["PhoneNumberC"].HeaderText = "PhoneNumber";
                dgvMembershipC.Columns["Point"].HeaderText = "Point";
                dgvMembershipC.Columns["Membership"].HeaderText = "Rank";

                dgvMembershipC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvMembershipC.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvMembershipC.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading membership data: " + ex.Message);
            }
        }
        //Load Statistics
        private void LoadRankStatisticsFromDB()
        {
            try
            {
                var stats = customerBLL.GetCustomerRankStatistics();

                txtDiamond.Text = $"{stats.diamond} Customers";
                txtGold.Text = $"{stats.gold} Customers";
                txtSilver.Text = $"{stats.silver} Customers";
                txtBronze.Text = $"{stats.bronze} Customers";
                txtTotal.Text = $"{stats.total} Customers";
                txtTop.Text = stats.topRank;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading statistics: " + ex.Message);
            }
        }
        private void FilterData()
        {
            if (currentCustomer.Rows.Count == 0) return;

            try
            {
                string search = txtSearchMembershipC.Text.Trim().ToLower();

                if (string.IsNullOrEmpty(search))
                {
                    // Hiển thị tất cả dữ liệu
                    dgvMembershipC.DataSource = currentCustomer;
                }
                else
                {
                    // Lọc dữ liệu theo nhiều cột
                    var filteredRows = currentCustomer.AsEnumerable()
                        .Where(r =>
                            r.Field<string>("NameCustomer")?.ToLower().Contains(search) == true ||
                            r.Field<string>("PhoneNumberC")?.ToLower().Contains(search) == true ||
                            r.Field<int>("Point").ToString().Contains(search) == true)
                        .ToArray();

                    if (filteredRows.Length > 0)
                    {
                        DataTable filteredTable = filteredRows.CopyToDataTable();
                        dgvMembershipC.DataSource = filteredTable;
                    }
                    else
                    {
                        // Hiển thị table rỗng nếu không tìm thấy
                        dgvMembershipC.DataSource = currentCustomer.Clone();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error search: " + ex.Message);
                // Nếu có lỗi, hiển thị lại toàn bộ dữ liệu
                dgvMembershipC.DataSource = currentCustomer;
            }
        }
        private void txtSearchMembershipC_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }
    }
}
