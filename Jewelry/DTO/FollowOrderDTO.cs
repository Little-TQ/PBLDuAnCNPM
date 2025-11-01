using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

        namespace Jewelry.DTO
    {
        public class FollowOrderDTO
        {
            public string idFollowOrder { get; set; }
            public string idInvoice { get; set; }
            public string Status { get; set; }
            public DateTime DateOrder { get; set; }
            public DateTime DateDelivery { get; set; }
        }
    }

