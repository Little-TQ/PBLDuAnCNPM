using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DTO
{
    internal class CustomerDTO
    {
        public string idCustomer { get; set; }
        public string NameCustomer { get; set; }
        public string PhoneNumberC { get; set; }
        public int Point { get; set; }
        public string Membership { get; set; }
        public string AddressC { get; set; }

        public CustomerDTO() { 
            Point = 0;
            Membership = "Friend";
        }
        public CustomerDTO(string idCustomer, string nameCustomer, string phoneNumberC, string addressC)
        {
            this.idCustomer = idCustomer;
            NameCustomer = nameCustomer;
            PhoneNumberC = phoneNumberC;
            Point = 0;
            Membership = "Friend";
            AddressC = addressC;
        }
    }
}
