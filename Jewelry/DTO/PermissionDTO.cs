using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DTO
{
    public class PermissionDTO
    {
        public int IdPermission { get; set; }
        public string PermissionName { get; set; }
        public bool IsActive { get; set; }


        public PermissionDTO(int idPermission, string permissionName, bool isActive)
        {
            IdPermission = idPermission;
            PermissionName = permissionName;
            IsActive = isActive;
        }
    }
}
