using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;
using Jewelry.DAL;
using Jewelry.DTO;

namespace Jewelry.BLL
{
    public class AccountBLL
    {
        AccountDAL accountDAL = new AccountDAL();

        // Get all accounts (with role name)
        public DataTable GetAllAccounts()
        {
            return accountDAL.GetAllAccounts();
        }

        // Get all roles
        public DataTable GetAllRoles()
        {
            return accountDAL.GetAllRoles();
        }

        // Generate new account ID
        public string GenerateNewAccountId()
        {
            return accountDAL.GenerateNewAccountId();
        }
        public void CheckAccount(AccountDTO account, bool isUpdate = false)
        {
            // Validate input (giữ nguyên)
            if (string.IsNullOrWhiteSpace(account.IdAccount))
                throw new Exception("Account ID cannot be empty.");

            if (string.IsNullOrWhiteSpace(account.Username))
                throw new Exception("Username cannot be empty.");

            if (string.IsNullOrWhiteSpace(account.PasswordHash))
                throw new Exception("Password cannot be empty.");

            if (account.PasswordHash.Length < 6)
                throw new Exception("Password must be at least 6 characters.");

            if (string.IsNullOrWhiteSpace(account.RoleName))
                throw new Exception("Role is invalid.");

            // Kiểm tra trùng username 
            DataTable existingAccounts = accountDAL.GetAllAccounts();
            foreach (DataRow row in existingAccounts.Rows)
            {
                string existingUsername = row["Username"].ToString();
                string existingId = row["idAccount"].ToString();

                // Nếu là update, bỏ qua chính tài khoản đang được update
                if (isUpdate && existingId.Equals(account.IdAccount, StringComparison.OrdinalIgnoreCase))
                    continue;

                if (existingUsername.Equals(account.Username, StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("Username already exists.");
                }
            }
        }

        public bool AddAccount(AccountDTO account)
        {
            CheckAccount(account, false); // false = không phải update
            return accountDAL.InsertAccount(account);
        }

        public bool UpdateAccount(AccountDTO account)
        {
            CheckAccount(account, true); // true = đang update
            return accountDAL.UpdateAccount(account);
        }
        public bool DeleteAccount(string accountId)
        {
            if (string.IsNullOrWhiteSpace(accountId))
                throw new Exception("Account ID cannot be empty.");

            return accountDAL.DeleteAccount(accountId);
        }

        // Kiểm tra đăng nhập
        public Tuple<bool, string, string, List<string>> CheckLogin(string username, string password, string selectedRole)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return Tuple.Create(false, "", "", new List<string>());

            DataRow account = accountDAL.CheckLogin(username, password);

            if (account != null)
            {
                string accountId = account["idAccount"].ToString();
                string dbRoleName = account["RoleName"].ToString().Trim();
                string inputRole = selectedRole.Trim();

                // Kiểm tra role có khớp không
                if (!dbRoleName.Equals(inputRole, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"Vai trò không khớp! Tài khoản thuộc vai trò: {dbRoleName}");
                    return Tuple.Create(false, "", "", new List<string>());
                }

                List<string> permissions = accountDAL.GetAccountPermissions(accountId);

                return Tuple.Create(true, accountId, dbRoleName, permissions);
            }
            else
            {
                MessageBox.Show("Không tìm thấy tài khoản với username và password này!");
            }

            return Tuple.Create(false, "", "", new List<string>());
        }

    }
}
