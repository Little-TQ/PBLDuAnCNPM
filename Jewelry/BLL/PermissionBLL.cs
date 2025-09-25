using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jewelry.DAL;
using Jewelry.DTO;
namespace Jewelry.BLL
{
    public class PermissionBLL
    {

        AccountPermissionDAL permissionDAL = new AccountPermissionDAL();

        public DataTable GetAccountPermissions()
        {
            return permissionDAL.GetAccountPermissions();
        }

        public void UpdatePermissions(AccountPermissionDTO dto)
        {
            permissionDAL.UpdatePermissions(dto);
        }

        public bool CheckPermission(string accountId, string permissionName)
        {
            DataTable dt = permissionDAL.GetAccountPermissions();
            foreach (DataRow row in dt.Rows)
            {
                if (row["idAccount"].ToString() == accountId)
                {
                    return row[permissionName].ToString() == "1";
                }
            }
            return false;
        }
    }
}

