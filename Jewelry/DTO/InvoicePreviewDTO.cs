using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DTO
{
    internal class InvoicePreviewDTO
    {
        public string idInvoice { get; set; }      // Mã hóa đơn (Primary Key)
        public string Type { get; set; }           // Loại hóa đơn (Pre-Order, Sale,...)
        public string LinkInvoice { get; set; }    // Tên file PDF (VD: INV-251101183336.pdf)
    }
}
