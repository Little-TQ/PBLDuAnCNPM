using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DTO
{
    public class RepurchaseDetailDTO
    {
        public string idRepurchaseDetail { get; set; }
        public string idInvoice { get; set; }
        public string idMaterial { get; set; }
        public decimal Weight { get; set; }
        public decimal RepurchasePrice { get; set; }
        public decimal Amount { get; set; }
    }
}
