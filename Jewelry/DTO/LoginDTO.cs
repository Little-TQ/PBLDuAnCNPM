using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DTO
{
    public class LoginDTO
    {

        public string AccountId { get; set; }
        public string Username { get; set; }
        public string RoleName { get; set; }
        public List<string> Permissions { get; set; }


        public LoginDTO()
        {
            Permissions = new List<string>();
        }
    }
}
