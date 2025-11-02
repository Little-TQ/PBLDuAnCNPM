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
        private RepurchaseDetailBLL repurchaseBLL = new RepurchaseDetailBLL();
        public event EventHandler InvoicePrinted;

        private List<RepurchaseItem> _repurchaseItems;
        private string _originalInvoiceId;
        private string currentEmployeeID = null;

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
        }

        // Load dgv Order Summary
        private void LoadOrderSummary()
        {
            dgvRepurchaseSummary.AutoGenerateColumns = false;
            dgvRepurchaseSummary.Columns.Clear();

            dgvRepurchaseSummary.Columns.Add("Material", "Material");
            dgvRepurchaseSummary.Columns.Add("Weight", "Weight");
            dgvRepurchaseSummary.Columns.Add("RepurchasePrice", "Repurchase Price");
            dgvRepurchaseSummary.Columns.Add("Amount", "Amount");

            dgvRepurchaseSummary.AllowUserToAddRows = false;
            dgvRepurchaseSummary.ReadOnly = true;
            dgvRepurchaseSummary.RowTemplate.Height = 35;
            dgvRepurchaseSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (_repurchaseItems != null && _repurchaseItems.Count > 0)
            {
                foreach (var item in _repurchaseItems)
                {
                    dgvRepurchaseSummary.Rows.Add(item.Name, item.Weight, item.RepurchasePrice, item.Amount);
                }
            }

            dgvRepurchaseSummary.Columns["RepurchasePrice"].DefaultCellStyle.Format = "#,##0 ₫";
            dgvRepurchaseSummary.Columns["Amount"].DefaultCellStyle.Format = "#,##0 ₫";
        }

        // Load dgv Preview Summary
        private void LoadPreviewSummary()
        {
            dgvPreview.AutoGenerateColumns = false;
            dgvPreview.Columns.Clear();

            dgvPreview.Columns.Add("Material", "Material");
            dgvPreview.Columns.Add("Weight", "Weight");
            dgvPreview.Columns.Add("RepurchasePrice", "Repurchase Price");
            dgvPreview.Columns.Add("Amount", "Amount");

            dgvPreview.AllowUserToAddRows = false;
            dgvPreview.ReadOnly = true;
            dgvPreview.RowTemplate.Height = 35;
            dgvPreview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (_repurchaseItems != null && _repurchaseItems.Count > 0)
            {
                foreach (var item in _repurchaseItems)
                {
                    dgvPreview.Rows.Add(item.Name, item.Weight, item.RepurchasePrice, item.Amount);
                }
            }

            dgvPreview.Columns["RepurchasePrice"].DefaultCellStyle.Format = "#,##0 ₫";
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

            if (_repurchaseItems != null)
            {
                foreach (var item in _repurchaseItems)
                {
                    subtotal += item.Amount;
                }
            }

            decimal total = subtotal;

            labelSubTotal.Text = $"{subtotal:N0} ₫";
            lblTotalR.Text = $"{total:N0} ₫";

            lblPreSubTotal.Text = $"{subtotal:N0} ₫";
            labelPreviewTotal.Text = $"{total:N0} ₫";
        }

        // Parse money string
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

        // Save PDF
        private string SaveInvoicePreviewAsPDF(string followID)
        {
            try
            {
                string folder = Path.Combine(Application.StartupPath, "InvoicePreviews");
                Directory.CreateDirectory(folder);

                string fileName = $"{followID}.pdf";
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

        // btn Print/Payment
        private void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (_repurchaseItems == null || _repurchaseItems.Count == 0)
                {
                    MessageBox.Show("Please add at least one product before printing.",
                                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string invoiceID = lblInvoiceID.Text.Trim(); // ID hóa đơn chính
                string customerName = txbCusName.Text.Trim();
                string phone = txtPhone.Text.Trim();
                string address = txtAddress.Text.Trim();
                string employee = txtEmployee.Text.Trim();
                string paymentMethod = cbPayment.Text.Trim();

                // Check Employee
                string empID = currentEmployeeID ?? employeeBLL.GetEmployeeIDByName(employee);
                if (string.IsNullOrEmpty(empID))
                {
                    MessageBox.Show("Employee not found in database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check or create Customer
                string idCustomer = null;
                if (!string.IsNullOrEmpty(_originalInvoiceId))
                {
                    var originalInvoice = invoiceBLL.GetInvoiceById(_originalInvoiceId);
                    if (originalInvoice != null)
                    {
                        idCustomer = originalInvoice.idCustomer;
                    }
                }

                if (string.IsNullOrEmpty(idCustomer))
                {
                    var existingCustomer = customerBLL.GetCustomerByPhone(phone);
                    if (existingCustomer != null)
                    {
                        idCustomer = existingCustomer.idCustomer;
                        // Update customer info if changed
                        if (existingCustomer.NameCustomer != customerName || existingCustomer.AddressC != address)
                        {
                            existingCustomer.NameCustomer = customerName;
                            existingCustomer.AddressC = address;
                            customerBLL.UpdateCustomer(existingCustomer);
                        }
                    }
                    else
                    {
                        // Create new customer
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

                string type = "Repurchase";
                string status = "Done";

                decimal subtotal = ParseMoney(labelSubTotal.Text);
                decimal total = subtotal;

                // TẠO HÓA ĐƠN CHÍNH TRONG BẢNG Invoice
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

                //  TẠO DANH SÁCH REPURCHASE DETAILS
                List<RepurchaseDetailDTO> repurchaseDetails = new List<RepurchaseDetailDTO>();
                int detailCounter = 1;

                foreach (var item in _repurchaseItems)
                {
                    repurchaseDetails.Add(new RepurchaseDetailDTO
                    {
                        idRepurchaseDetail = $"{invoiceID}-{detailCounter:D3}", // RP-241101193012-001
                        idInvoice = invoiceID,
                        idMaterial = item.ID, // idMaterial từ RepurchaseItem
                        Weight = Convert.ToDecimal(item.Weight),
                        RepurchasePrice = item.RepurchasePrice,
                        Amount = item.Amount
                    });
                    detailCounter++;
                }

                //  LƯU HÓA ĐƠN CHÍNH VÀ CHI TIẾT MUA LẠI
                bool invoiceSuccess = invoiceBLL.SaveInvoice(invoice, new List<InvoiceDetailDTO>()); 
                bool repurchaseSuccess = repurchaseBLL.SaveRepurchaseDetails(repurchaseDetails);

                if (invoiceSuccess && repurchaseSuccess)
                {
                    customerBLL.UpdateCustomerPointAndMembership(invoice.idCustomer, total);

                    // Save PDF
                    string pdfPath = SaveInvoicePreviewAsPDF(invoiceID);

                    if (!string.IsNullOrEmpty(pdfPath))
                    {
                        var previewBLL = new InvoicePreviewBLL();
                        InvoicePreviewDTO preview = new InvoicePreviewDTO
                        {
                            idInvoice = invoiceID,
                            Type = "Repurchase",
                            LinkInvoice = pdfPath
                        };
                        previewBLL.AddOrUpdatePreview(preview);
                    }

                    DialogResult result = MessageBox.Show(
                                             $"Repurchase Invoice {invoiceID} saved successfully!",
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
                    MessageBox.Show("Failed to save repurchase invoice.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving repurchase invoice: " + ex.Message);
            }
        }

     
        private void txtPhone_Leave(object sender, EventArgs e)
        {
            string phone = txtPhone.Text.Trim();
            if (string.IsNullOrEmpty(phone)) return;

            var customer = customerBLL.GetCustomerByPhone(phone);

            if (customer != null)
            {
                // If customer exists -> fill the form + preview
                txbCusName.Text = customer.NameCustomer;
                txtAddress.Text = customer.AddressC;

                lblPrevName.Text = customer.NameCustomer;
                lblPrevPhone.Text = customer.PhoneNumberC;
                lblPrevAddress.Text = customer.AddressC;
            }
            else
            {
                // Customer doesn't exist -> clear name and address for new customer
                txbCusName.Clear();
                txtAddress.Clear();
                lblPrevName.Text = "";
                lblPrevAddress.Text = "";
                lblPrevPhone.Text = phone;
            }
        }

        // Text changed events for real-time preview update
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