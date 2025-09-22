using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DTO
{
    public class AccountDTO
    {
        public string IdAccount { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }


        public AccountDTO(string idAccount, string username, string passwordHash, string roleName, bool isActive)
        {
            IdAccount = idAccount;
            Username = username;
            PasswordHash = passwordHash;
            RoleName = roleName;
            IsActive = isActive;
        }
    }
}
