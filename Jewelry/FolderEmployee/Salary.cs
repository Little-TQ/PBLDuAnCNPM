using Jewelry.BLL;
using Jewelry.DTO;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Jewelry.FolderEmployee
{
    public partial class Salary : UserControl
    {
        private SalaryBLL salaryBLL;
        private DataTable currentSalaries;

        public Salary()
        {
            InitializeComponent();
            salaryBLL = new SalaryBLL();
            currentSalaries = new DataTable();
        }

        private void Salary_Load(object sender, EventArgs e)
        {
            SetupDatePicker();
            LoadRoles();
            LoadSalaryData();
            SetupDataGridView();
        }

        private void SetupDatePicker()
        {
            dtpSalaryView.Format = DateTimePickerFormat.Custom;
            dtpSalaryView.CustomFormat = "MM/yyyy";
            dtpSalaryView.ShowUpDown = true;
            dtpSalaryView.Value = DateTime.Now;

            dtpSalaryView.KeyUp += DtpSalaryView_KeyUp;
            dtpSalaryView.MouseUp += DtpSalaryView_MouseUp;
        }

        private void DtpSalaryView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                LoadSalaryData();
        }

        private void DtpSalaryView_MouseUp(object sender, MouseEventArgs e)
        {
            LoadSalaryData();
        }

        private void SetupDataGridView()
        {
            dgvSalaryView.AutoGenerateColumns = false;
            dgvSalaryView.Columns.Clear();

            dgvSalaryView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "EmployeeName",
                HeaderText = "Employee Name",
                DataPropertyName = "EmployeeName",
                Width = 150
            });

            dgvSalaryView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Role",
                HeaderText = "Role",
                DataPropertyName = "Role",
                Width = 120
            });

            dgvSalaryView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "TotalWorkingDays",
                HeaderText = "Work Days",
                DataPropertyName = "TotalWorkingDays",
                Width = 80
            });

            dgvSalaryView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "LateCount",
                HeaderText = "Late Count",
                DataPropertyName = "LateCount",
                Width = 80
            });

            dgvSalaryView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "BasicSalary",
                HeaderText = "Basic Salary",
                DataPropertyName = "BasicSalary",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "N0" }
            });

            dgvSalaryView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Commission",
                HeaderText = "Commission",
                DataPropertyName = "Commission",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "N0" }
            });

            dgvSalaryView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Allowance",
                HeaderText = "Allowance",
                DataPropertyName = "Allowance",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "N0" }
            });

            dgvSalaryView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Deduction",
                HeaderText = "Deduction",
                DataPropertyName = "Deduction",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "N0" }
            });

            dgvSalaryView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "TotalSalary",
                HeaderText = "Total Salary",
                DataPropertyName = "TotalSalary",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "N0", ForeColor = Color.Green }
            });

            dgvSalaryView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "idEmployee",
                HeaderText = "Employee ID",
                DataPropertyName = "idEmployee",
                Visible = false
            });

            dgvSalaryView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "HasSalary",
                HeaderText = "Has Salary",
                DataPropertyName = "HasSalary",
                Visible = false
            });
        }

        private void DisplayData(DataTable data)
        {
            dgvSalaryView.DataSource = data;

            foreach (DataGridViewRow row in dgvSalaryView.Rows)
            {
                bool hasSalary = Convert.ToBoolean(row.Cells["HasSalary"].Value ?? false);
                if (!hasSalary)
                {
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                    row.DefaultCellStyle.ForeColor = Color.Gray;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void LoadRoles()
        {
            try
            {
                cbxRole.Items.Clear();
                cbxRole.Items.Add("All");

                DataTable roles = salaryBLL.GetRolesWithEmployees();

                foreach (DataRow row in roles.Rows)
                {
                    cbxRole.Items.Add(row["RoleName"].ToString());
                }

                cbxRole.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading roles: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSalaryData()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                int month = dtpSalaryView.Value.Month;
                int year = dtpSalaryView.Value.Year;
                string role = (cbxRole.SelectedIndex > 0) ? cbxRole.SelectedItem.ToString() : "";

                Console.WriteLine($"Loading salary for {month}/{year}, Role: {role}");

                currentSalaries = salaryBLL.GetSalaries(month, year, role);

                if (currentSalaries.Rows.Count == 0)
                {
                    MessageBox.Show($"No salary data for {month}/{year}", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DisplayData(currentSalaries);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading salary data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void dtpSalaryView_ValueChanged(object sender, EventArgs e)
        {
            LoadSalaryData();
        }

        private void cbxRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSalaryData();
        }

        private void txtSearchSalaryEmployee_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void txtSearchSalaryEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                FilterData();
        }

        private void FilterData()
        {
            if (currentSalaries.Rows.Count == 0) return;

            try
            {
                string search = txtSearchSalaryEmployee.Text.Trim().ToLower();

                if (string.IsNullOrEmpty(search))
                {
                    dgvSalaryView.DataSource = currentSalaries;
                }
                else
                {
                    var filtered = currentSalaries.AsEnumerable()
                        .Where(r => r.Field<string>("EmployeeName").ToLower().Contains(search))
                        .CopyToDataTable();

                    dgvSalaryView.DataSource = filtered;
                }
            }
            catch
            {
                var empty = currentSalaries.Clone();
                dgvSalaryView.DataSource = empty;
            }
        }

        private void btnEditSalaryEmployee_Click(object sender, EventArgs e)
        {
            if (dgvSalaryView.CurrentRow == null || dgvSalaryView.CurrentRow.Index < 0)
            {
                MessageBox.Show("Please select an employee to edit.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                DataGridViewRow row = dgvSalaryView.CurrentRow;

                string empId = row.Cells["idEmployee"].Value?.ToString() ?? "";
                string name = row.Cells["EmployeeName"].Value?.ToString() ?? "";
                string role = row.Cells["Role"].Value?.ToString() ?? "";

                decimal basic = SafeToDecimal(row.Cells["BasicSalary"].Value);
                decimal commission = SafeToDecimal(row.Cells["Commission"].Value);
                decimal allowance = SafeToDecimal(row.Cells["Allowance"].Value);
                decimal deduction = SafeToDecimal(row.Cells["Deduction"].Value);
                decimal total = SafeToDecimal(row.Cells["TotalSalary"].Value);

                if (string.IsNullOrEmpty(empId))
                {
                    MessageBox.Show("Cannot get employee info.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var dto = new SalaryDTO
                {
                    EmployeeId = empId,
                    EmployeeName = name,
                    Role = role,
                    BasicSalary = basic,
                    Commission = commission,
                    Allowance = allowance,
                    Deduction = deduction,
                    TotalSalary = total
                };

                int month = dtpSalaryView.Value.Month;
                int year = dtpSalaryView.Value.Year;

                using (SalaryEdit editForm = new SalaryEdit(dto, month, year))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadSalaryData();
                        MessageBox.Show("Salary updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening edit form: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal SafeToDecimal(object value)
        {
            if (value == null || value == DBNull.Value)
                return 0;

            try { return Convert.ToDecimal(value); }
            catch { return 0; }
        }

        private void dgvSalaryView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnEditSalaryEmployee_Click(sender, e);
        }

        private void btnViewSalary_Click(object sender, EventArgs e)
        {
            LoadSalaryData();
        }
    }
}
