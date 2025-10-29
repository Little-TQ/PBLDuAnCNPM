using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DTO
{
    public class RepurchaseItem
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Weight { get; set; }
        public decimal Wage { get; set; }
        public decimal BasePrice { get; set; }
        public decimal Price { get; set; }
        public decimal RepurchasePrice { get; set; }
        public decimal Amount { get; set; }
    }
}
