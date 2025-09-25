using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DTO
{
   public class AccountPermissionDTO
    {
        public string AccountId { get; set; }
        public string Username { get; set; }
        public string RoleName { get; set; }
        public bool Account { get; set; }
        public bool Overview { get; set; }
        public bool Product { get; set; }
        public bool Customer { get; set; }
        public bool Employee { get; set; }
        public bool Payment { get; set; }
        public bool Invoice { get; set; }
        public bool Update { get; set; }
    }
}
