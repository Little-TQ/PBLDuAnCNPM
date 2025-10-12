using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Jewelry.BLL;

namespace Jewelry
{
    public partial class ScheduleView : Form
    {
        private ScheduleBLL scheduleBLL = new ScheduleBLL();
        private DataTable originalData;

        public ScheduleView()
        {
            InitializeComponent();
            LoadData();
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            try
            {
                if (originalData != null)
                {
                    // Get roles list from data
                    var roles = originalData.AsEnumerable()
                        .Select(row => row.Field<string>("Role"))
                        .Distinct()
                        .Where(role => !string.IsNullOrEmpty(role))
                        .ToList();

                    // Add "All" item to the beginning of the list
                    roles.Insert(0, "All");

                    cbxRole.DataSource = roles;
                    cbxRole.SelectedIndex = 0; // Select "All" by default
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading roles: " + ex.Message);
            }
        }

        private void LoadData()
        {
            try
            {
                DateTime selectedDate = dtpScheduleView.Value;
                originalData = scheduleBLL.GetMonthlyStatistics(selectedDate);
                ApplyFilters(); // Apply filters after loading data
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilters()
        {
            if (originalData == null) return;

            var filteredData = originalData.AsEnumerable();

            // Filter by employee name
            if (!string.IsNullOrEmpty(txtSearchScheduleView.Text))
            {
                string searchText = txtSearchScheduleView.Text.Trim().ToLower();
                filteredData = filteredData.Where(row =>
                {
                    var employeeName = row.Field<string>("EmployeeName");
                    return employeeName != null && employeeName.ToLower().Contains(searchText);
                });
            }

            // Filter by role
            if (cbxRole.SelectedItem != null && cbxRole.SelectedItem.ToString() != "All")
            {
                string selectedRole = cbxRole.SelectedItem.ToString();
                filteredData = filteredData.Where(row =>
                {
                    var role = row.Field<string>("Role");
                    return role == selectedRole;
                });
            }

            // Display filtered data
            if (filteredData.Any())
            {
                dgvScheduleView.DataSource = filteredData.CopyToDataTable();
            }
            else
            {
                // If no results, display empty DataTable with same structure
                dgvScheduleView.DataSource = originalData.Clone();
            }

            FormatGridView();
        }

        private void FormatGridView()
        {
            if (dgvScheduleView.Columns.Count > 0)
            {
                dgvScheduleView.Columns["EmployeeName"].HeaderText = "Name";
                dgvScheduleView.Columns["Role"].HeaderText = "Role";
                dgvScheduleView.Columns["PresentDays"].HeaderText = "Present Days";
                dgvScheduleView.Columns["LateCount"].HeaderText = "Late Count";
                dgvScheduleView.Columns["AbsentDays"].HeaderText = "Absent Days";
                dgvScheduleView.Columns["LeaveDays"].HeaderText = "Leave Days";
                dgvScheduleView.Columns["TotalShifts"].HeaderText = "Total Shifts";
                dgvScheduleView.Columns["TotalWorkingDays"].HeaderText = "Total Working Days";
            }
        }

        // Event when selecting role
        private void cbxRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        // Event when changing date
        private void dtpScheduleView_ValueChanged(object sender, EventArgs e)
        {
            LoadData(); // Reload data when month changes
        }

        // Event when pressing Enter in search box
        private void txtSearchScheduleView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ApplyFilters();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // Event when text changes (real-time search)
        private void txtSearchScheduleView_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ScheduleView_Load(object sender, EventArgs e)
        {
            LoadData();
            dtpScheduleView.Value = DateTime.Now;
        }

        private void btnReturnSchedule_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}