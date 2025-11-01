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
        private FollowOrderBLL followOrderBLL = new FollowOrderBLL();
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

                //Tạo bản ghi FollowOrder (PreOrder)
                string type = "Pre-Order";
                string status = "In Progress";
                decimal subtotal = ParseMoney(SubTotal.Text);
                decimal discount = ParseMoney(Discount.Text);
                decimal total = subtotal - discount;

                FollowOrderBLL followBLL = new FollowOrderBLL();
                string followID = followBLL.GenerateFollowOrderID();

                FollowOrderDTO followOrder = new FollowOrderDTO
                {
                    idFollowOrder = followID,
                    idInvoice = null,
                    Status = status,
                    DateOrder = DateTime.Now,
                    DateDelivery = deliveryDate.Value
                };

                bool followSaved = followBLL.AddFollowOrder(followOrder);

                if (followSaved)
                {
                    //Cập nhật điểm KH dựa theo tổng
                    customerBLL.UpdateCustomerPointAndMembership(idCustomer, total);

                    MessageBox.Show($"Pre-Order created successfully!\nOrder ID: {followID}",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    InvoicePrinted?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to create Follow Order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                lblEm.Text = txtEmployee.Text;
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
