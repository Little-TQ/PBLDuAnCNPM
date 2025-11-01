using Jewelry.DAL;
using Jewelry.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.BLL
{
    internal class CustomerBLL
    {
        private CustomerDAL customerDAL = new CustomerDAL();

        //Get all customers
        public DataTable GetAllCustomers()
        {
            return customerDAL.GetAllCustomers();
        }
        //Generate ID
        public string GenerateCustomerID()
{
    return customerDAL.GenerateCustomerID();
}
        //Add new Customer
        public bool AddCustomer(CustomerDTO c)
        {
            if (string.IsNullOrWhiteSpace(c.idCustomer))
                throw new Exception("Customer ID cannot be empty.");
            if (string.IsNullOrWhiteSpace(c.PhoneNumberC))
                throw new Exception("Customer phonenumber cannot be empty.");
            if (string.IsNullOrWhiteSpace(c.NameCustomer))
                throw new Exception("Customer name cannot be empty.");
            if (string.IsNullOrWhiteSpace(c.AddressC))
                throw new Exception("Customer address cannot be empty.");

            return customerDAL.AddCustomer(c);
        }
        //Update Customer
        public bool UpdateCustomer(CustomerDTO c)
        {
            if (string.IsNullOrWhiteSpace(c.idCustomer))
                throw new Exception("Customer ID is invalid.");
            return customerDAL.UpdateCustomer(c);
        }
        // Thêm vào CustomerBLL class
        public CustomerDTO GetCustomerById(string customerId)
        {
            return new CustomerDAL().GetCustomerById(customerId);
        }
        //Statistics
        public (int diamond, int gold, int silver, int bronze, int total, string topRank) GetCustomerRankStatistics()
        {
            return customerDAL.GetCustomerRankStatistics();
        }
        //get customer by phone
        public CustomerDTO GetCustomerByPhone(string phone)
        {
            return customerDAL.GetCustomerByPhone(phone);
        }
 
        //update customer point and membership
        public bool UpdateCustomerPointAndMembership(string idCustomer, decimal total)
        {
            if (string.IsNullOrEmpty(idCustomer))
                throw new Exception("Customer ID is invalid.");
            return customerDAL.UpdateCustomerPointAndMembership(idCustomer, total);
        }


    }
}
