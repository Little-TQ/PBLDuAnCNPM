using Jewelry.BLL;
using Jewelry.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jewelry
{
    public partial class Payment_Repurchase_Invoice : Form
    {
        private InvoiceBLL invoiceBLL = new InvoiceBLL();
        private EmployeeBLL employeeBLL = new EmployeeBLL();
        private CustomerBLL customerBLL = new CustomerBLL();
        public event EventHandler InvoicePrinted;

        private List<RepurchaseItem> _repurchaseItems;
        private string _originalInvoiceId;

        public Payment_Repurchase_Invoice(List<RepurchaseItem> repurchaseItems, string originalInvoiceId)
        {
            InitializeComponent();
            _repurchaseItems = repurchaseItems;
            _originalInvoiceId = originalInvoiceId;
        }
        private void Payment_Repurchase_Invoice_Load(object sender, EventArgs e)
        {
            LoadOrderSummary();
            LoadPreviewSummary();
            UpdateInvoicePreview();
            CalculateTotals();
            LoadCustomerInfoFromOriginalInvoice();
        }

        // Load thông tin khách hàng từ hóa đơn gốc
        private void LoadCustomerInfoFromOriginalInvoice()
        {
            if (string.IsNullOrEmpty(_originalInvoiceId))
            {
                return;
            }

            try
            {
                var originalInvoice = invoiceBLL.GetInvoiceById(_originalInvoiceId);
                if (originalInvoice != null && !string.IsNullOrEmpty(originalInvoice.idCustomer))
                {
                    var customer = customerBLL.GetCustomerById(originalInvoice.idCustomer);
                    if (customer != null)
                    {
                        txbCusName.Text = customer.NameCustomer;
                        txtPhone.Text = customer.PhoneNumberC;
                        txtAddress.Text = customer.AddressC;

                        // Cập nhật preview
                        lblPrevName.Text = customer.NameCustomer;
                        lblPrevPhone.Text = customer.PhoneNumberC;
                        lblPrevAddress.Text = customer.AddressC;
                    }
                }
                else
                {
                    MessageBox.Show("Don't find origin invoice and customer");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error load information's customer: {ex.Message}");
            }
        }

        // Load dgv Order Summary
        private void LoadOrderSummary()
        {
            dgvRepurchaseSummary.AutoGenerateColumns = false;
            dgvRepurchaseSummary.Columns.Clear();

            dgvRepurchaseSummary.Columns.Add("Product", "Product");
            dgvRepurchaseSummary.Columns.Add("Quantity", "Quantity");
            dgvRepurchaseSummary.Columns.Add("Weight", "Weight");
            dgvRepurchaseSummary.Columns.Add("Wage", "Wage");
            dgvRepurchaseSummary.Columns.Add("BasePrice", "Base Price");
            dgvRepurchaseSummary.Columns.Add("Price", "Price");
            dgvRepurchaseSummary.Columns.Add("RepurchasePrice", "Repurchase Price");
            dgvRepurchaseSummary.Columns.Add("Amount", "Amount");

            dgvRepurchaseSummary.AllowUserToAddRows = false;
            dgvRepurchaseSummary.ReadOnly = true;
            dgvRepurchaseSummary.RowTemplate.Height = 35;
            dgvRepurchaseSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (_repurchaseItems != null)
            {
                foreach (var item in _repurchaseItems)
                {
                    dgvRepurchaseSummary.Rows.Add(item.Name, item.Quantity, item.Weight,
                                             item.Wage, item.BasePrice, item.Price,
                                             item.RepurchasePrice, item.Amount);
                }
            }

            dgvRepurchaseSummary.Columns["Wage"].DefaultCellStyle.Format =
            dgvRepurchaseSummary.Columns["BasePrice"].DefaultCellStyle.Format =
            dgvRepurchaseSummary.Columns["Price"].DefaultCellStyle.Format =
            dgvRepurchaseSummary.Columns["RepurchasePrice"].DefaultCellStyle.Format =
            dgvRepurchaseSummary.Columns["Amount"].DefaultCellStyle.Format = "#,##0 ₫";
        }

        // Load dgv Preview Summary
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
            dgvPreview.Columns.Add("RepurchasePrice", "Repurchase");
            dgvPreview.Columns.Add("Amount", "Amount");

            dgvPreview.AllowUserToAddRows = false;
            dgvPreview.ReadOnly = true;
            dgvPreview.RowTemplate.Height = 35;
            dgvPreview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (_repurchaseItems != null)
            {
                foreach (var item in _repurchaseItems)
                {
                    dgvPreview.Rows.Add(item.Name, item.Quantity, item.Weight,
                                        item.Wage, item.BasePrice, item.Price,
                                        item.RepurchasePrice, item.Amount);
                }
            }

            dgvPreview.Columns["Wage"].DefaultCellStyle.Format =
            dgvPreview.Columns["BasePrice"].DefaultCellStyle.Format =
            dgvPreview.Columns["Price"].DefaultCellStyle.Format =
            dgvPreview.Columns["RepurchasePrice"].DefaultCellStyle.Format =
            dgvPreview.Columns["Amount"].DefaultCellStyle.Format = "#,##0 ₫";
        }

        // Update Invoice Preview
        private void UpdateInvoicePreview()
        {
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            lblInvoiceID.Text = "RP-" + DateTime.Now.ToString("yyMMddHHmmss");
        }

        // Update totals
        private void CalculateTotals()
        {
            decimal subtotal = 0;
            decimal depreciation = 0;

            if (_repurchaseItems != null)
            {
                foreach (var item in _repurchaseItems)
                {
                    subtotal += item.Amount;
                }
            }

            decimal total = subtotal - depreciation;

            labelSubTotal.Text = $"{subtotal:N0} ₫";
            lblTotalR.Text = $"{total:N0} ₫";

            lblPreSubTotal.Text = $"{subtotal:N0} ₫";
            labelPreviewTotal.Text = $"{total:N0} ₫";
        }

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

        //Save PDF
        private string SaveInvoicePreviewAsPDF(string followID)
        {
            try
            {
                string folder = Path.Combine(Application.StartupPath, "InvoicePreviews");
                Directory.CreateDirectory(folder);

                string fileName = $"{followID}.pdf"; // Ví dụ: FO-20251101191523.pdf
                string filePath = Path.Combine(folder, fileName);

                using (Bitmap bmp = new Bitmap(pnlInvoicePreviewR.Width, pnlInvoicePreviewR.Height))
                {
                    pnlInvoicePreviewR.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height));

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


        private void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (_repurchaseItems == null || _repurchaseItems.Count == 0)
                {
                    MessageBox.Show("Please select at least 1 product before printing",
                                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string invoiceID = lblInvoiceID.Text.Trim();
                string customerName = txbCusName.Text.Trim();
                string phone = txtPhone.Text.Trim();
                string address = txtAddress.Text.Trim();
                string employee = txtEmployee.Text.Trim();

                // Check ID Employee
                string empID = employeeBLL.GetEmployeeIDByName(employee);
                if (string.IsNullOrEmpty(empID))
                {
                    MessageBox.Show($"Search '{employee}' unsuccessful!",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // LẤY THÔNG TIN KHÁCH HÀNG TỪ HÓA ĐƠN GỐC
                string idCustomer = null;
                if (!string.IsNullOrEmpty(_originalInvoiceId))
                {
                    var originalInvoice = invoiceBLL.GetInvoiceById(_originalInvoiceId);
                    if (originalInvoice != null)
                    {
                        idCustomer = originalInvoice.idCustomer;
                    }
                }

                // Nếu không có khách hàng từ hóa đơn gốc, tạo mới từ thông tin nhập
                if (string.IsNullOrEmpty(idCustomer))
                {
                    if (!string.IsNullOrEmpty(phone))
                    {
                        var existingCustomer = customerBLL.GetCustomerByPhone(phone);
                        if (existingCustomer != null)
                        {
                            idCustomer = existingCustomer.idCustomer;
                        }
                        else
                        {
                            idCustomer = customerBLL.GenerateCustomerID();
                            CustomerDTO newCustomer = new CustomerDTO
                            {
                                idCustomer = idCustomer,
                                NameCustomer = customerName,
                                PhoneNumberC = phone,
                                AddressC = address,
                                Point = 0,
                                Membership = "Bronze"
                            };
                            customerBLL.AddCustomer(newCustomer);
                        }
                    }
                }

                string type = "Repurchase";
                string status = "Done";

                decimal subtotal = ParseMoney(labelSubTotal.Text);
                decimal total = subtotal ;

                // Create Invoice and Details
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

                List<InvoiceDetailDTO> details = _repurchaseItems.Select(i => new InvoiceDetailDTO
                {
                    idInvoice = invoiceID,
                    idProduct = i.ID,
                    Quantity = i.Quantity,
                    Price = i.RepurchasePrice,
                    Amount = i.Amount
                }).ToList();

                // Save Invoice
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
                            Type = "Repurchase",
                            LinkInvoice = pdfPath  // DAL sẽ tự rút tên file
                        };
                        previewBLL.AddOrUpdatePreview(preview);
                    }

                    DialogResult result = MessageBox.Show(
                                             $"Repurchase Invoice {invoiceID} saved successful!",
                                             "Successful",
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
                    MessageBox.Show("Error save invoice.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error save invoice: " + ex.Message);
            }
        }
        private void txbCusName_TextChanged(object sender, EventArgs e)
        {
            lblPrevName.Text = txbCusName.Text;
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            lblPrevPhone.Text = txtPhone.Text;
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            lblPrevAddress.Text = txtAddress.Text;
        }

        private void txtEmployee_TextChanged(object sender, EventArgs e)
        {
            lblPreviewEmployee.Text = txtEmployee.Text;
        }
        private void cbPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMethod.Text = cbPayment.Text;
        }
    }
}