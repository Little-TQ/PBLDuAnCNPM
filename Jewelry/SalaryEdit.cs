using Jewelry.BLL;
using Jewelry.DTO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Jewelry
{
    public partial class SalaryEdit : Form
    {
        private SalaryDTO currentSalary;
        private SalaryBLL salaryBLL;
        public SalaryDTO UpdatedSalary { get; private set; }
        private bool isEditMode = false;
        private int lateCount = 0;
        private int month, year;

        public SalaryEdit(SalaryDTO salary, int month, int year)
        {
            InitializeComponent();
            currentSalary = salary;
            UpdatedSalary = salary;
            salaryBLL = new SalaryBLL();
            this.month = month;
            this.year = year;

            LoadRolesIntoComboBox();
            LoadLateCount();
            LoadSalaryData();
            SetEditMode(false); // Start in view-only mode
        }

        private void LoadLateCount()
        {
            try
            {
                lateCount = salaryBLL.GetLateCount(currentSalary.EmployeeId, month, year);
                CalculateDeduction();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading late count: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateDeduction()
        {
            // Deduction: 20,000 for each late arrival
            decimal deduction = lateCount * 20000;
            txtDeduction.Text = deduction.ToString("N0");
            UpdatedSalary.Deduction = deduction;
        }

        private void LoadRolesIntoComboBox()
        {
            try
            {
                var roles = salaryBLL.GetRolesWithEmployees();
                foreach (System.Data.DataRow row in roles.Rows)
                {
                    cbxRole.Items.Add(row["RoleName"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading roles: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSalaryData()
        {
            // Display current data (read-only at first)
            txtNameEmployee.Text = currentSalary.EmployeeName;
            cbxRole.Text = currentSalary.Role;
            txtBasicSalary.Text = currentSalary.BasicSalary.ToString("N0");
            txtCommission.Text = currentSalary.Commission.ToString("N0");
            txtAllowance.Text = currentSalary.Allowance.ToString("N0");
            txtDeduction.Text = currentSalary.Deduction.ToString("N0");
        }

        private void SetEditMode(bool editMode)
        {
            isEditMode = editMode;

            // Only allow editing of: Basic Salary, Commission, and Allowance
            txtBasicSalary.ReadOnly = !editMode;
            txtCommission.ReadOnly = !editMode;
            txtAllowance.ReadOnly = !editMode;

            // The rest are always read-only
            txtNameEmployee.ReadOnly = true;
            cbxRole.Enabled = false;
            txtDeduction.ReadOnly = true;

            // Change background color to indicate editable fields
            Color editableColor = editMode ? Color.White : Color.FromArgb(240, 240, 240);
            Color readonlyColor = Color.FromArgb(240, 240, 240);

            txtBasicSalary.BackColor = editableColor;
            txtCommission.BackColor = editableColor;
            txtAllowance.BackColor = editableColor;

            txtNameEmployee.BackColor = readonlyColor;
            cbxRole.BackColor = readonlyColor;
            txtDeduction.BackColor = readonlyColor;

            // Toggle button visibility
            btnEditSalaryEmployee.Visible = !editMode;
            btnCompleteEditSalary.Visible = editMode;
            btnReturnSalaryEdit.Visible = !editMode;
        }

        private decimal ParseDecimal(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return 0;
            text = text.Replace(",", "").Replace(".", "");
            return decimal.TryParse(text, out decimal result) ? result : 0;
        }

        private void btnEditSalaryEmployee_Click(object sender, EventArgs e)
        {
            SetEditMode(true);
            txtBasicSalary.Focus();
            txtBasicSalary.SelectAll();
        }

        private void btnCompleteEditSalary_Click(object sender, EventArgs e)
        {
            if (!isEditMode) return;

            try
            {
                // Validate input
                decimal basicSalary = ParseDecimal(txtBasicSalary.Text);
                decimal commission = ParseDecimal(txtCommission.Text);
                decimal allowance = ParseDecimal(txtAllowance.Text);

                if (basicSalary < 0 || commission < 0 || allowance < 0)
                {
                    MessageBox.Show("Salary values cannot be negative.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Update salary data
                UpdatedSalary.BasicSalary = basicSalary;
                UpdatedSalary.Commission = commission;
                UpdatedSalary.Allowance = allowance;

                // Recalculate total salary
                UpdatedSalary.TotalSalary =
                    UpdatedSalary.BasicSalary +
                    UpdatedSalary.Commission +
                    UpdatedSalary.Allowance -
                    UpdatedSalary.Deduction;

                // Debug log
                Console.WriteLine($"Saving Salary for Employee: {UpdatedSalary.EmployeeId}, " +
                                  $"Basic: {UpdatedSalary.BasicSalary}, " +
                                  $"Commission: {UpdatedSalary.Commission}, " +
                                  $"Allowance: {UpdatedSalary.Allowance}, " +
                                  $"Deduction: {UpdatedSalary.Deduction}");

                // Save to database
                bool success = salaryBLL.UpdateSalary(UpdatedSalary);

                if (success)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    // Debug: Check if employee salary exists
                    var employeeSalary = salaryBLL.GetEmployeeSalary(UpdatedSalary.EmployeeId, month, year);
                    bool employeeExists = employeeSalary.Rows.Count > 0;

                    MessageBox.Show($"Failed to update salary. Employee exists: {employeeExists}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating salary: {ex.Message}\n\nDetails: {ex.InnerException?.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReturnSalaryEdit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
