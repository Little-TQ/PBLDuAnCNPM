using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DTO
{
    public class RoleDTO
    {
        public int IdRole { get; set; }
        public string RoleName { get; set; }

        public RoleDTO(int idRole, string rolenane) 
        {
            IdRole = idRole;    
            RoleName = rolenane;
        }
    }
}
