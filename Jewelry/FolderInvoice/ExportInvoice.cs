using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Jewelry.BLL;
using Jewelry.DTO;

namespace Jewelry.FolderImportInvoice
{
    public partial class ExportInvoice : UserControl
    {
        private InvoiceBLL invoiceBLL = new InvoiceBLL();
        private string pngFolderPath = Path.Combine(Application.StartupPath, "InvoicePreviews");

        public ExportInvoice()
        {
            InitializeComponent();
    
        }
        private void txtSearchExportInvoice_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchExportInvoice.Text))
            {
            }
        }

    }
}