using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jewelry.DAL;
using Jewelry.DTO;
using Jewelry.FolderShowInvoice;

namespace Jewelry
{
    public partial class ShowInvoice: Form
    {
        private string _invoiceId;
        public ShowInvoice(string invoiceId)
        {
            InitializeComponent();
            _invoiceId = invoiceId;
            LoadInvoiceRepurchase();
        }
        private void LoadInvoiceRepurchase()
        {
            try
            {
                // Tạo UserControl InvoiceRepurchase và truyền invoiceId
                InvoiceRepurchase invoiceRepurchase = new InvoiceRepurchase(_invoiceId);

                // Thiết lập kích thước và vị trí
                invoiceRepurchase.Dock = DockStyle.Fill;

                // Thêm vào panel
                pnlshowinvoice.Controls.Clear();
                pnlshowinvoice.Controls.Add(invoiceRepurchase);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading invoice: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowInvoice_Load(object sender, EventArgs e)
        {
            this.Text = $"Invoice Details - {_invoiceId}";
        }
    }
}
