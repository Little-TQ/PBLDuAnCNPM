using Jewelry.BLL;
using Jewelry.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jewelry
{
    public partial class Payment_PreOrder_Invoice : Form
    {

        private InvoiceBLL invoiceBLL = new InvoiceBLL();
        private EmployeeBLL employeeBLL = new EmployeeBLL();
        private CustomerBLL customerBLL = new CustomerBLL();
        public event EventHandler InvoicePrinted;

        private List<OrderItem> _orderItems;
        public Payment_PreOrder_Invoice(List<OrderItem> orderItems)
        {
            InitializeComponent();
            _orderItems = orderItems;
        }
        ////public Payment_PreOrder_Invoice()
        //{
        //    InitializeComponent();

        //}
        private void Payment_PreOrder_Invoice_Load(object sender, EventArgs e)
        {
            LoadOrderSummary();
            LoadPreviewSummary();
            UpdateInvoicePreview();
            CalculateTotals();
        }
        //Load dgv Order Summary
        private void LoadOrderSummary()
        {
            if(_orderItems == null || _orderItems.Count == 0)
            {
                return;
            }
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
            if (_orderItems == null || _orderItems.Count == 0)
            {
                return; 
            }

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
            if (_orderItems == null || !_orderItems.Any()) return;
            decimal subtotal = _orderItems.Sum(i => i.Amount);
            decimal discount = 0;
            decimal deposit = ParseMoney(txtDeposit.Text);
            decimal total = subtotal - discount;
            decimal remaining = total - deposit;

            SubTotal.Text = $"{subtotal:N0} ₫";
            Discount.Text = $"{discount:N0} ₫";
            Total.Text = $"{total:N0} ₫";
            Remaining.Text = $"{remaining:N0} ₫";

            UpdatePreviewSummary();
        }

        
        private void btnPrint_Click(object sender, EventArgs e)
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

                //Check ID Employee
                string empID = employeeBLL.GetEmployeeIDByName(employee);
                if (string.IsNullOrEmpty(empID))
                {
                    MessageBox.Show($"Employee '{employee}' not found in database!",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Check or Add Customer
                string idCustomer = null;
                var existingCustomer = customerBLL.GetCustomerByPhone(phone);

                if (existingCustomer != null)
                {
                    idCustomer = existingCustomer.idCustomer;

                    if (existingCustomer.NameCustomer != customerName || existingCustomer.AddressC != address)
                    {
                        existingCustomer.NameCustomer = customerName;
                        existingCustomer.AddressC = address;
                        customerBLL.UpdateCustomer(existingCustomer);
                    }
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
        private void btnPrint_Paint(object sender, PaintEventArgs e)
        {
            
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

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            string phone = txtPhone.Text.Trim();
            if (string.IsNullOrEmpty(phone)) return;

            var customer = customerBLL.GetCustomerByPhone(phone);

            if (customer != null)
            {

                txtCustomerName.Text = customer.NameCustomer;
                txtAddress.Text = customer.AddressC;

                lblPrevPhone.Text = customer.PhoneNumberC;

                lblPoint.Text = customer.Point.ToString();
                lblMembership.Text = customer.Membership;

            }
            else
            {
                string newID = customerBLL.GenerateCustomerID();

                CustomerDTO newCustomer = new CustomerDTO
                {
                    idCustomer = newID,
                    NameCustomer = txtCustomerName.Text.Trim(),
                    PhoneNumberC = phone,
                    AddressC = txtAddress.Text.Trim(),
                    Point = 0,
                    Membership = "Member"
                };

                bool added = customerBLL.AddCustomer(newCustomer);

                if (added)
                {
                    MessageBox.Show($"New customer added: {newID}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void UpdatePreviewSummary()
        {
            try
            {
                lblPrevSubTotal.Text = SubTotal.Text;
                lblDis.Text = Discount.Text;
                lblTol.Text = Total.Text;
                lblDeposit.Text = $"{txtDeposit.Text} ₫"; // Thêm đơn vị tiền
                lblRemaining.Text = Remaining.Text;
            }
            catch { }
        }
        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            lblPrevAddress.Text = txtAddress.Text.Trim();
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            lblPrevName.Text = txtCustomerName.Text.Trim();
        }

        private void txtEmployee_TextChanged(object sender, EventArgs e)
        {
            lblEm.Text = txtEmployee.Text.Trim();
        }

        private void btnContinueShopping_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private void guna2HtmlLabel18_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel36_Click(object sender, EventArgs e)
        {

        }

        private void txtDeposit_TextChanged(object sender, EventArgs e)
        {
            CalculateTotals();
        }

        private void btnContinueShopping_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMethod.Text = cbPayment.Text;
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dgvOrderSummary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
