using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DTO
{
    class RolePermissionDTO
    {
        public int idRole { get; }
        public int idPermission { get; }

        public RolePermissionDTO(RoleDTO role, PermissionDTO permission)
        {
            idRole = role.IdRole;
            idPermission = permission.IdPermission;
        }

    }
}
