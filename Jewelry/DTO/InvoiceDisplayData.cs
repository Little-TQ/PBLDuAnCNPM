using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DTO
{
    public class InvoiceDisplayData
    {
        public string InvoiceId { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime CreateDate { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string EmployeeName { get; set; }
        public decimal Total { get; set; }
        public List<RepurchaseItem> Items { get; set; }
        public string PaymentMethod { get; set; }
        public decimal SubTotal { get; set; }
    }
}
