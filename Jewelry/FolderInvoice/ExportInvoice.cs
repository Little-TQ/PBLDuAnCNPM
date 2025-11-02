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

namespace Jewelry.FolderImportInvoice
{
    public partial class ExportInvoice: UserControl
    {
        private InvoiceBLL invoiceBLL = new InvoiceBLL();
        public ExportInvoice()
        {
            InitializeComponent();
        }

        private void ExportInvoice_Load(object sender, EventArgs e)
        {
            LoadInvoiceData();
        }
        // Load invoice data into DataGridView
        private void LoadInvoiceData()
        {
            try
            {
                DataTable dt = invoiceBLL.GetAllInvoicesWithPreview();
                dgvInvoice.DataSource = dt;
                dgvInvoice.ClearSelection();

                dgvInvoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvInvoice.Columns["idInvoice"].HeaderText = "Invoice ID";
                dgvInvoice.Columns["CustomerName"].HeaderText = "Customer";
                dgvInvoice.Columns["EmployeeName"].HeaderText = "Employee";
                dgvInvoice.Columns["DateTimeCreateInvoice"].HeaderText = "Date Created";
                dgvInvoice.Columns["Total"].HeaderText = "Total (VND)";
                dgvInvoice.Columns["LinkInvoice"].HeaderText = "Invoice File";

                dgvInvoice.Columns["Total"].DefaultCellStyle.Format = "N0";
                dgvInvoice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvInvoice.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading invoices: " + ex.Message);
            }
        }
        //btn View
        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgvInvoice.CurrentRow == null) return;

            string pdfFile = dgvInvoice.CurrentRow.Cells["Invoice File"].Value?.ToString();

            string fullPath = System.IO.Path.Combine(Application.StartupPath, "InvoicePreviews", pdfFile);

            if (System.IO.File.Exists(fullPath))
            {
                WebBrowser browser = new WebBrowser();
                browser.Dock = DockStyle.Fill;
                browser.Navigate(fullPath);

                details.Controls.Clear();
                details.Controls.Add(browser);
            }
            else
            {
                MessageBox.Show("PDF not found!");
            }
        }
        private void LoadInvoiceList(string keyword = "")
        {
            DataTable dt = invoiceBLL.SearchInvoices(keyword);
            dgvInvoice.DataSource = dt;

            dgvInvoice.ClearSelection();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            LoadInvoiceList(keyword);
        }

        private void dgvInvoice_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvInvoice.Columns[e.ColumnIndex].Name == "Total (VND)" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal val))
                {
                    e.Value = val.ToString("N0") + " ₫";
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
