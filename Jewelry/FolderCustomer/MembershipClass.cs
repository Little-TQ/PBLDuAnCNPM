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

                dgvMembershipC.DataSource = filtered;

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

                txtDiamond.Text = $"{stats.diamond} Khách Hàng";
                txtGold.Text = $"{stats.gold} Khách Hàng";
                txtSilver.Text = $"{stats.silver} Khách Hàng";
                txtBronze.Text = $"{stats.bronze} Khách Hàng";
                txtTotal.Text = $"{stats.total} Khách Hàng";
                txtTop.Text = stats.topRank;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading statistics: " + ex.Message);
            }
        }
    }
}
