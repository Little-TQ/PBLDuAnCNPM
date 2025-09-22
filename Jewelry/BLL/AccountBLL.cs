using System;
using System.Data;
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

        // Business logic for adding an account
        public bool AddAccount(AccountDTO account)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(account.Username))
                throw new Exception("Username cannot be empty.");

            if (string.IsNullOrWhiteSpace(account.PasswordHash))
                throw new Exception("Password cannot be empty.");

            if (account.PasswordHash.Length < 4)
                throw new Exception("Password must be at least 4 characters.");

            if (string.IsNullOrWhiteSpace(account.RoleName))
                throw new Exception("Role is invalid.");

            // Check for duplicate username
            DataTable existingAccounts = accountDAL.GetAllAccounts();
            foreach (DataRow row in existingAccounts.Rows)
            {
                if (row["Username"].ToString().Equals(account.Username, StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("Username already exists.");
                }
            }

            // If all valid, call DAL to insert
            return accountDAL.InsertAccount(account);
        }
    }
}
