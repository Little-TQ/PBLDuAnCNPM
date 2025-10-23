using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DTO
{
    public class InvoiceDTO
    {
        public string idInvoice { get; set; }
        public string idCustomer { get; set; }
        public DateTime DateTimeCreateInvoice { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string idEmployee { get; set; }
        public decimal Total { get; set; }
    }

}
