using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Jewelry.BLL;
using Jewelry.DTO;

namespace Jewelry.FolderShowInvoice
{
    public partial class InvoiceRepurchase : UserControl
    {
        private InvoiceBLL invoiceBLL = new InvoiceBLL();
        private CustomerBLL customerBLL = new CustomerBLL();
        private EmployeeBLL employeeBLL = new EmployeeBLL();
        private string _invoiceId;

        public InvoiceRepurchase(string invoiceId)
        {
            InitializeComponent();
            _invoiceId = invoiceId;
            LoadInvoiceData();
        }

        public InvoiceRepurchase()
        {
            InitializeComponent();
        }

        private void LoadInvoiceData()
        {
            try
            {
                if (string.IsNullOrEmpty(_invoiceId))
                    return;

                // Lấy thông tin hóa đơn từ database
                var invoice = invoiceBLL.GetInvoiceById(_invoiceId);
                var details = invoiceBLL.GetInvoiceDetails(_invoiceId);

                if (invoice != null)
                {
                    DisplayInvoiceData(invoice, details);
                }
                else
                {
                    MessageBox.Show("Invoice not found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading invoice data: {ex.Message}");
            }
        }

        private void DisplayInvoiceData(InvoiceDTO invoice, DataTable details)
        {
            try
            {
                // Hiển thị thông tin hóa đơn cơ bản - GIỐNG PREVIEW
                if (Controls.Find("lblInvoiceID", true).FirstOrDefault() is Label lblInvoiceID)
                    lblInvoiceID.Text = invoice.idInvoice;

                if (Controls.Find("lblDate", true).FirstOrDefault() is Label lblDate)
                    lblDate.Text = invoice.DateTimeCreateInvoice.ToString("dd/MM/yyyy HH:mm");

                // Hiển thị thông tin khách hàng - GIỐNG PREVIEW
                var customer = customerBLL.GetCustomerById(invoice.idCustomer);
                if (customer != null)
                {
                    if (Controls.Find("lblPrevName", true).FirstOrDefault() is Label lblPrevName)
                        lblPrevName.Text = customer.NameCustomer;

                    if (Controls.Find("lblPrevPhone", true).FirstOrDefault() is Label lblPrevPhone)
                        lblPrevPhone.Text = customer.PhoneNumberC;

                    if (Controls.Find("lblPrevAddress", true).FirstOrDefault() is Label lblPrevAddress)
                        lblPrevAddress.Text = customer.AddressC;
                }

                // Hiển thị thông tin nhân viên - GIỐNG PREVIEW
                if (Controls.Find("lblPreviewEmployee", true).FirstOrDefault() is Label lblPreviewEmployee)
                {
                    // Sử dụng hàm có sẵn trong BLL để lấy tên nhân viên từ ID
                    string employeeName = employeeBLL.GetEmployeeIDByName(invoice.idEmployee);
                    lblPreviewEmployee.Text = employeeName ?? "N/A";
                }

                // Hiển thị chi tiết sản phẩm trong DataGridView - GIỐNG PREVIEW
                if (Controls.Find("dgvPreview", true).FirstOrDefault() is DataGridView dgvPreview)
                {
                    // Tạo các cột giống như trong LoadPreviewSummary()
                    dgvPreview.AutoGenerateColumns = false;
                    dgvPreview.Columns.Clear();

                    dgvPreview.Columns.Add("Product", "Product");
                    dgvPreview.Columns.Add("Quantity", "Quantity");
                    dgvPreview.Columns.Add("Weight", "Weight");
                    dgvPreview.Columns.Add("Wage", "Wage");
                    dgvPreview.Columns.Add("BasePrice", "Base");
                    dgvPreview.Columns.Add("Price", "Price");
                    dgvPreview.Columns.Add("RepurchasePrice", "Repurchase");
                    dgvPreview.Columns.Add("Amount", "Amount");

                    dgvPreview.AllowUserToAddRows = false;
                    dgvPreview.ReadOnly = true;
                    dgvPreview.RowTemplate.Height = 35;
                    dgvPreview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Thêm dữ liệu từ details DataTable
                    foreach (DataRow row in details.Rows)
                    {
                        dgvPreview.Rows.Add(
                            row["ProductName"]?.ToString() ?? "",
                            row["Quantity"]?.ToString() ?? "",
                            row["Weight"]?.ToString() ?? "",
                            row["Wage"]?.ToString() ?? "",
                            row["BasePrice"]?.ToString() ?? "",
                            row["Price"]?.ToString() ?? "",
                            row["Price"]?.ToString() ?? "", // RepurchasePrice (dùng Price tạm thời)
                            row["Amount"]?.ToString() ?? ""
                        );
                    }

                    // Định dạng các cột tiền tệ - GIỐNG PREVIEW
                    dgvPreview.Columns["Wage"].DefaultCellStyle.Format =
                    dgvPreview.Columns["BasePrice"].DefaultCellStyle.Format =
                    dgvPreview.Columns["Price"].DefaultCellStyle.Format =
                    dgvPreview.Columns["RepurchasePrice"].DefaultCellStyle.Format =
                    dgvPreview.Columns["Amount"].DefaultCellStyle.Format = "#,##0 ₫";
                }

                // Tính toán và hiển thị tổng tiền - GIỐNG PREVIEW
                decimal subtotal = 0;
                if (details != null && details.Rows.Count > 0)
                {
                    foreach (DataRow row in details.Rows)
                    {
                        if (row["Amount"] != DBNull.Value)
                            subtotal += Convert.ToDecimal(row["Amount"]);
                    }
                }

                if (Controls.Find("lblPreSubTotal", true).FirstOrDefault() is Label lblPreSubTotal)
                    lblPreSubTotal.Text = $"{subtotal:N0} ₫";

                if (Controls.Find("labelPreviewTotal", true).FirstOrDefault() is Label labelPreviewTotal)
                    labelPreviewTotal.Text = $"{invoice.Total:N0} ₫";

                // Hiển thị phương thức thanh toán - GIỐNG PREVIEW
                if (Controls.Find("lblMethod", true).FirstOrDefault() is Label lblMethod)
                {
                    // Có thể lấy từ database hoặc set mặc định
                    lblMethod.Text = "Cash"; // Hoặc lấy từ thông tin hóa đơn nếu có
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying invoice data: {ex.Message}");
            }
        }
    }
}