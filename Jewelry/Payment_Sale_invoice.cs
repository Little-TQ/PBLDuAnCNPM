using Jewelry.BLL;
using Jewelry.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Jewelry
{
    public partial class Payment_Sale_invoice : Form
    {
        private InvoiceBLL invoiceBLL = new InvoiceBLL();
        private EmployeeBLL employeeBLL = new EmployeeBLL();
        private CustomerBLL customerBLL = new CustomerBLL();
        public event EventHandler InvoicePrinted;

        private List<OrderItem> _orderItems;

        public Payment_Sale_invoice(List<OrderItem> orderItems)
        {
            InitializeComponent();
            _orderItems = orderItems;
        }
        public Payment_Sale_invoice()
        {
            InitializeComponent();
        }
        private void Payment_Sale_invoice_Load(object sender, EventArgs e)
        {
            LoadOrderSummary();
            LoadPreviewSummary();
            UpdateInvoicePreview();
            CalculateTotals();
        }
        //Load dgv Order Summary
        private void LoadOrderSummary()
        {
            dgvOrderSummary.AutoGenerateColumns = false;
            dgvOrderSummary.Columns.Clear();

            dgvOrderSummary.Columns.Add("Product", "Product");
            dgvOrderSummary.Columns.Add("Quantity", "Quantity");
            dgvOrderSummary.Columns.Add("Weight", "Weight");
            dgvOrderSummary.Columns.Add("Wage", "Wage");
            dgvOrderSummary.Columns.Add("BasePrice", "Base Price");
            dgvOrderSummary.Columns.Add("Price", "Price");
            dgvOrderSummary.Columns.Add("Amount", "Amount");

            dgvOrderSummary.AllowUserToAddRows = false;
            dgvOrderSummary.ReadOnly = true;
            dgvOrderSummary.RowTemplate.Height = 35;
            dgvOrderSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (var item in _orderItems)
            {
                dgvOrderSummary.Rows.Add(item.Name, item.Quantity, item.Weight,
                                         item.Wage, item.BasePrice, item.Price, item.Amount);
            }

            dgvOrderSummary.Columns["Wage"].DefaultCellStyle.Format =
            dgvOrderSummary.Columns["BasePrice"].DefaultCellStyle.Format =
            dgvOrderSummary.Columns["Price"].DefaultCellStyle.Format =
            dgvOrderSummary.Columns["Amount"].DefaultCellStyle.Format = "#,##0 ₫";
        }
        //Load dgv Preview Summary
        private void LoadPreviewSummary()
        {
            dgvPreview.AutoGenerateColumns = false;
            dgvPreview.Columns.Clear();

            dgvPreview.Columns.Add("Product", "Product");
            dgvPreview.Columns.Add("Quantity", "Quantity");
            dgvPreview.Columns.Add("Weight", "Weight");
            dgvPreview.Columns.Add("Wage", "Wage");
            dgvPreview.Columns.Add("BasePrice", "Base");
            dgvPreview.Columns.Add("Price", "Price");
            dgvPreview.Columns.Add("Amount", "Amount");
                
            dgvPreview.AllowUserToAddRows = false;
            dgvPreview.ReadOnly = true;
            dgvPreview.RowTemplate.Height = 35;
            dgvPreview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (var item in _orderItems)
            {
                dgvPreview.Rows.Add(item.Name, item.Quantity, item.Weight,
                                         item.Wage, item.BasePrice, item.Price, item.Amount);
            }

            dgvPreview.Columns["Wage"].DefaultCellStyle.Format =
            dgvPreview.Columns["BasePrice"].DefaultCellStyle.Format =
            dgvPreview.Columns["Price"].DefaultCellStyle.Format =
            dgvPreview.Columns["Amount"].DefaultCellStyle.Format = "#,##0 ₫";
        }
        //Update Invoice Preview
        private void UpdateInvoicePreview()
        {
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            lblInvoiceID.Text = "INV-" + DateTime.Now.ToString("yyMMddHHmmss");
        }
        //Update totals
        private void CalculateTotals()
        {
            decimal subtotal = 0;
            decimal discount = 0;

            foreach (DataGridViewRow row in dgvOrderSummary.Rows)
            {
                if (!row.IsNewRow && row.Cells["Amount"].Value != null)
                {
                    subtotal += Convert.ToDecimal(row.Cells["Amount"].Value);
                }
            }

            if (decimal.TryParse(Discount.Text, out decimal discountValue))
                discount = discountValue;

            decimal total = subtotal - discount;

            SubTotal.Text = $"{subtotal:N0} ₫";
            Discount.Text = $"{discount:N0} ₫";
            Total.Text = $"{total:N0} ₫";

            lblPreSubTotal.Text = $"{subtotal:N0} ₫";
            lblPrevDiscount.Text = $"{discount:N0} ₫";
            lblPrevTotal.Text = $"{total:N0} ₫";
        }

        //Save PDF
        private string SaveInvoicePreviewAsPDF(string followID)
        {
            try
            {
                string folder = Path.Combine(Application.StartupPath, "InvoicePreviews");
                Directory.CreateDirectory(folder);

                string fileName = $"{followID}.pdf"; // Ví dụ: FO-20251101191523.pdf
                string filePath = Path.Combine(folder, fileName);

                using (Bitmap bmp = new Bitmap(pnlInvoicePreview.Width, pnlInvoicePreview.Height))
                {
                    pnlInvoicePreview.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height));

                    using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 25, 25);
                        iTextSharp.text.pdf.PdfWriter.GetInstance(doc, fs);
                        doc.Open();

                        using (MemoryStream ms = new MemoryStream())
                        {
                            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(ms.ToArray());
                            pdfImage.ScaleToFit(doc.PageSize.Width - 50, doc.PageSize.Height - 50);
                            pdfImage.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                            doc.Add(pdfImage);
                        }

                        doc.Close();
                    }
                }
                return filePath;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving PDF: " + ex.Message);
                return null;
            }
        }
        //btn Print
        private void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (_orderItems == null || _orderItems.Count == 0)
                {
                    MessageBox.Show("Please add at least one product before printing.",
                                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string invoiceID = lblInvoiceID.Text.Trim();
                string customerName = txtCustomerName.Text.Trim();
                string phone = txtPhone.Text.Trim();
                string address = txtAddress.Text.Trim();
                string employee = txtEmployee.Text.Trim();

                //Lấy ID nhân viên
                string empID = currentEmployeeID ?? employeeBLL.GetEmployeeIDByName(employee);
                if (string.IsNullOrEmpty(empID))
                {
                    MessageBox.Show("Employee not found in database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra hoặc thêm khách hàng
                string idCustomer = null;
                var existingCustomer = customerBLL.GetCustomerByPhone(phone);

                if (existingCustomer != null)
                {
                    idCustomer = existingCustomer.idCustomer;
                    // Cập nhật nếu KH có chỉnh sửa
                    if (existingCustomer.NameCustomer != customerName || existingCustomer.AddressC != address)
                    {
                        existingCustomer.NameCustomer = customerName;
                        existingCustomer.AddressC = address;
                        customerBLL.UpdateCustomer(existingCustomer);
                    }
                }
                else
                {
                    // Thêm KH mới
                    idCustomer = customerBLL.GenerateCustomerID();
                    CustomerDTO newCustomer = new CustomerDTO
                    {
                        idCustomer = idCustomer,
                        NameCustomer = customerName,
                        PhoneNumberC = phone,
                        AddressC = address,
                        Point = 0,
                        Membership = "Member"
                    };
                    customerBLL.AddCustomer(newCustomer);
                }

                string type = "Sale";             
                string status = (type == "Pre-Order") ? "In process" : "Done";

                decimal subtotal = ParseMoney(SubTotal.Text);
                decimal discount = ParseMoney(Discount.Text);
                decimal total = subtotal - discount;

                //Create Invoice and Details
                InvoiceDTO invoice = new InvoiceDTO
                {
                    idInvoice = invoiceID,
                    idCustomer = idCustomer,
                    DateTimeCreateInvoice = DateTime.Now,
                    Type = type,
                    Status = status,
                    idEmployee = empID,
                    Total = total
                };

                List<InvoiceDetailDTO> details = _orderItems.Select(i => new InvoiceDetailDTO
                {
                    idInvoice = invoiceID,
                    idProduct = i.ID,
                    Quantity = i.Quantity,
                    Price = i.Price,
                    Amount = i.Amount
                }).ToList();


                //Save Invoice
                bool success = invoiceBLL.SaveInvoice(invoice, details);

                if (success)
                {
                    customerBLL.UpdateCustomerPointAndMembership(invoice.idCustomer, total);
                    //Lưu pdf
                    string pdfPath = SaveInvoicePreviewAsPDF(invoiceID);

                    if (!string.IsNullOrEmpty(pdfPath))
                    {
                        var previewBLL = new InvoicePreviewBLL();
                        InvoicePreviewDTO preview = new InvoicePreviewDTO
                        {
                            idInvoice = invoiceID,
                            Type = "Pre-Order",
                            LinkInvoice = pdfPath  // DAL sẽ tự rút tên file
                        };
                        previewBLL.AddOrUpdatePreview(preview);
                    }

                    DialogResult result = MessageBox.Show(
                                             $"Invoice {invoiceID} saved successfully!",
                                             "Success",
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Information
                                         );

                    if (result == DialogResult.OK)
                    {
                        InvoicePrinted?.Invoke(this, EventArgs.Empty);
                        this.Close();

                    }

                }
                else
                {
                    MessageBox.Show("Failed to save invoice.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error printing invoice: " + ex.Message);
            }
        
         }
        //Parse money string
        private decimal ParseMoney(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return 0;

            input = input.Replace("₫", "")
                         .Replace("đ", "")
                         .Replace(",", "")
                         .Replace(".", "")
                         .Trim();

            return decimal.TryParse(input, out decimal value) ? value : 0;
        }
        //Preferences Customer
        private void txtPhone_Leave(object sender, EventArgs e)
        {
            string phone = txtPhone.Text.Trim();
            if (string.IsNullOrEmpty(phone)) return;

            var customer = customerBLL.GetCustomerByPhone(phone);

            if (customer != null)
            {
                // Nếu KH đã tồn tại -> fill lên form + preview
                txtCustomerName.Text = customer.NameCustomer;
                txtAddress.Text = customer.AddressC;

                lblPrevName.Text = customer.NameCustomer;
                lblPrevPhone.Text = customer.PhoneNumberC;
                lblPrevAddress.Text = customer.AddressC;
                lblPoint.Text = customer.Point.ToString();
                lblMembership.Text = customer.Membership;
            }
            else
            {
                // KH chưa có -> khởi tạo dữ liệu tạm
                lblPrevPhone.Text = phone;
                lblPoint.Text = "0";
                lblMembership.Text = "Member";
            }
        }


        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            lblPrevName.Text = txtCustomerName.Text;
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            lblPrevPhone.Text = txtPhone.Text;
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            lblPrevAddress.Text = txtAddress.Text;
        }
        //Preferences Employee
        private string currentEmployeeID = null;
        private void txtEmployee_Leave(object sender, EventArgs e)
        {
            string empName = txtEmployee.Text.Trim();
            if (string.IsNullOrEmpty(empName))
            {
                currentEmployeeID = null;
                return;
            }

            currentEmployeeID = employeeBLL.GetEmployeeIDByName(empName);

            if (string.IsNullOrEmpty(currentEmployeeID))
            {
                MessageBox.Show($"Employee '{empName}' not found in database!",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                lblPreviewEmployee.Text = txtEmployee.Text;
            }
        }

        
        
        private void cbPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMedthod.Text = cbPayment.Text;
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2HtmlLabel24_Click(object sender, EventArgs e)
        {

        }

        private void btnContinueShopping_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnContinueShopping_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
