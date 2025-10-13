using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Jewelry.BLL;
using Jewelry.DTO;

namespace Jewelry.FolderEmployee
{
    public partial class Schedule : UserControl
    {
        private ScheduleBLL scheduleBLL = new ScheduleBLL();
        private bool isEditing = false;
        private DataTable originalData;

        public Schedule()
        {
            InitializeComponent();
            SetupDataGridView();

        }
        //For View
        private void SetupDataGridView()
        {
            dataGridViewSchedule.Columns.Clear();

            // Create columns
            dataGridViewSchedule.Columns.Add("EmployeeID", "ID");
            dataGridViewSchedule.Columns.Add("EmployeeName", "Employee Name");
            dataGridViewSchedule.Columns.Add("Role", "Role");

            // ComboBox Status
            DataGridViewComboBoxColumn statusCol = new DataGridViewComboBoxColumn();
            statusCol.HeaderText = "Status";
            statusCol.Name = "Status";
            statusCol.Items.AddRange("", "Present", "Absent", "On Leave", "Late");
            dataGridViewSchedule.Columns.Add(statusCol);

            // ComboBox Shift
            DataGridViewComboBoxColumn shiftCol = new DataGridViewComboBoxColumn();
            shiftCol.HeaderText = "Shift";
            shiftCol.Name = "Shift";
            shiftCol.Items.AddRange("", "Morning", "Afternoon", "Evening", "Full-time");
            dataGridViewSchedule.Columns.Add(shiftCol);

            // Hide ID
            dataGridViewSchedule.Columns["EmployeeID"].Visible = false;
            // Set EditMode
            dataGridViewSchedule.EditMode = DataGridViewEditMode.EditOnEnter;

        }

        // View Button: Open statistics form
        private void btnViewSchedule_Click(object sender, EventArgs e)
        {
            ScheduleView frm = new ScheduleView();
            frm.ShowDialog();
        }

        // Edit Button: Show employees for attendance
        private void btnEditSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime selectedDate = dtpSchedule.Value;
                LoadEmployeesForAttendance(selectedDate);

                // Enable edit
                SetEditMode(true);
                btnSaveSchedule.Enabled = true;
                btnEditSchedule.Enabled = false;
                isEditing = true;

                MessageBox.Show("Edit mode enabled. Click on Status or Shift cells to edit.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load employees for attendance
        private void LoadEmployeesForAttendance(DateTime workDate)
        {
            originalData = scheduleBLL.GetEmployeesForAttendance(workDate);
            dataGridViewSchedule.Rows.Clear();

            foreach (DataRow row in originalData.Rows)
            {
                int rowIndex = dataGridViewSchedule.Rows.Add(
                    row["idEmployee"],
                    row["NameEmployee"],
                    row["Role"]
                );

                // IMPORTANT: Set values for combobox cells
                var statusCell = (DataGridViewComboBoxCell)dataGridViewSchedule.Rows[rowIndex].Cells["Status"];
                var shiftCell = (DataGridViewComboBoxCell)dataGridViewSchedule.Rows[rowIndex].Cells["Shift"];

                string statusValue = row["Status"].ToString();
                string shiftValue = row["Shift"].ToString();

                // Set values directly
                statusCell.Value = statusValue;
                shiftCell.Value = shiftValue;
            }
            UpdateStatistics();
        }

        // Get only changed data from grid
        private List<ScheduleDTO> GetChangedSchedulesFromGrid()
        {
            var changedSchedules = new List<ScheduleDTO>();

            for (int i = 0; i < dataGridViewSchedule.Rows.Count; i++)
            {
                var row = dataGridViewSchedule.Rows[i];
                if (row.Cells["EmployeeName"].Value != null && !row.IsNewRow)
                {
                    string employeeId = row.Cells["EmployeeID"].Value?.ToString() ?? "";
                    string currentStatus = row.Cells["Status"].Value?.ToString() ?? "";
                    string currentShift = row.Cells["Shift"].Value?.ToString() ?? "";

                     
                    if (string.IsNullOrEmpty(currentStatus))
                        currentStatus = "";
                    if (string.IsNullOrEmpty(currentShift))
                        currentShift = ""; 

                    
                    var schedule = new ScheduleDTO
                    {
                        IdEmployee = employeeId,
                        EmployeeName = row.Cells["EmployeeName"].Value?.ToString() ?? "",
                        Role = row.Cells["Role"].Value?.ToString() ?? "",
                        Status = currentStatus,
                        Shift = currentShift,
                        WorkDate = dtpSchedule.Value
                    };

                    changedSchedules.Add(schedule);
                }
            }

            return changedSchedules;
        }

        // Save Button: Save only changed attendance
        private void btnSaveSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                var changedSchedules = GetChangedSchedulesFromGrid();

                if (changedSchedules.Count == 0)
                {
                    MessageBox.Show("No changes to save!", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Show confirmation dialog
                var result = MessageBox.Show($"Save attendance changes for {changedSchedules.Count} employee?",
                    "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                // Use SaveMultipleAttendance from BLL
                bool success = scheduleBLL.SaveMultipleAttendance(changedSchedules);

                if (success)
                {
                    MessageBox.Show("Attendance saved successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SetEditMode(false);
                    btnSaveSchedule.Enabled = false;
                    btnEditSchedule.Enabled = true;
                    isEditing = false;

                    // Update statistics after saving
                    UpdateStatistics();

                    // Reload data to update originalData
                    LoadEmployeesForAttendance(dtpSchedule.Value);
                }
                else
                {
                    MessageBox.Show("Error saving attendance!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving attendance: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Enable/disable edit mode
        private void SetEditMode(bool enable)
        {
            if (enable)
            {
                // ENABLE edit mode
                dataGridViewSchedule.ReadOnly = false;
                dataGridViewSchedule.Columns["Status"].ReadOnly = false;
                dataGridViewSchedule.Columns["Shift"].ReadOnly = false;

                // Ensure combobox can be clicked
                dataGridViewSchedule.EditMode = DataGridViewEditMode.EditOnEnter;
            }
            else
            {
                // DISABLE edit mode
                dataGridViewSchedule.ReadOnly = true;
                dataGridViewSchedule.Columns["Status"].ReadOnly = true;
                dataGridViewSchedule.Columns["Shift"].ReadOnly = true;
                dataGridViewSchedule.DefaultCellStyle.BackColor = Color.White;
            }

            dataGridViewSchedule.Refresh();
        }

        // Update statistics
        private void UpdateStatistics()
        {
            try
            {
                DateTime selectedDate = dtpSchedule.Value;
                var dt = scheduleBLL.GetDailyStatistics(selectedDate);

                // Nếu dùng Cách 2, chỉ có 1 dòng kết quả
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    int present = row["PresentDays"] == DBNull.Value ? 0 : Convert.ToInt32(row["PresentDays"]);
                    int absent = row["AbsentDays"] == DBNull.Value ? 0 : Convert.ToInt32(row["AbsentDays"]);
                    int onLeave = row["LeaveDays"] == DBNull.Value ? 0 : Convert.ToInt32(row["LeaveDays"]);
                    int late = row["LateCount"] == DBNull.Value ? 0 : Convert.ToInt32(row["LateCount"]);

                    txtPresent.Text = present.ToString();
                    txtAbsent.Text = absent.ToString();
                    txtOnLeave.Text = onLeave.ToString();
                    txtLate.Text = late.ToString();
                }
                else
                {
                    // Không có dữ liệu
                    txtPresent.Text = "0";
                    txtAbsent.Text = "0";
                    txtOnLeave.Text = "0";
                    txtLate.Text = "0";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Statistics error: " + ex.Message);
                txtPresent.Text = "0";
                txtAbsent.Text = "0";
                txtOnLeave.Text = "0";
                txtLate.Text = "0";
            }
        }

        // Update temporary statistics while editing 
        private void UpdateTemporaryStatistics()
        {
            if (!isEditing) return;

            int present = 0, absent = 0, onLeave = 0, late = 0;
            int totalShifts = 0;

            foreach (DataGridViewRow row in dataGridViewSchedule.Rows)
            {
                if (row.Cells["Status"].Value != null && !row.IsNewRow)
                {
                    string status = row.Cells["Status"].Value.ToString();
                    string shift = row.Cells["Shift"].Value?.ToString() ?? "";

                    switch (status)
                    {
                        case "Present": present++; break;
                        case "Absent": absent++; break;
                        case "On Leave": onLeave++; break;
                        case "Late": late++; break;
                    }

                    // Tính số ca cho mỗi nhân viên
                    totalShifts += CalculateShiftsCount(shift);
                }
            }

            txtPresent.Text = present.ToString();
            txtAbsent.Text = absent.ToString();
            txtOnLeave.Text = onLeave.ToString();
            txtLate.Text = late.ToString();
        }

        // Method tính số ca dựa trên loại ca
        private int CalculateShiftsCount(string shiftType)
        {
            if (string.IsNullOrEmpty(shiftType))
                return 0;

            switch (shiftType.ToLower())
            {
                case "full-time":
                    return 3;
                case "morning":
                case "afternoon":
                case "evening":
                    return 1;
                default:
                    return 0;
            }
        }

        // IMPORTANT: Event when cell value changes
        private void dataGridViewSchedule_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isEditing && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dataGridViewSchedule.Columns["Status"].Index ||
                    e.ColumnIndex == dataGridViewSchedule.Columns["Shift"].Index)
                {
                    UpdateTemporaryStatistics();
                }
            }
        }

        private void Schedule_Load(object sender, EventArgs e)
        {

            dtpSchedule.Value = DateTime.Today;
            DateTime selectedDate = dtpSchedule.Value;
            LoadEmployeesForAttendance(selectedDate);
        }

        private void dataGridViewSchedule_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SetEditMode(true);
            btnEditSchedule.Enabled = true;
            isEditing = true;
        }
        private void dtpSchedule_ValueChanged(object sender, EventArgs e)
        {
                DateTime selectedDate = dtpSchedule.Value;
                LoadEmployeesForAttendance(selectedDate);
        }

    }
}