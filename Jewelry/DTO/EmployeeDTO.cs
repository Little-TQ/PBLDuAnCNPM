using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DTO
{
    public class EmployeeDTO
    {
        public string IdEmployee { get; set; }
        public string NameEmployee { get; set; }
        public string PhoneEmployee { get; set; }
        public DateTime DateOfBirth {get; set; }
        public string AddressEmployee { get; set; }
        public string RoleName {  get; set; }

        public EmployeeDTO(string id, string name, string phone, DateTime birthday, string address, string rolename)
        {
            IdEmployee = id;
            NameEmployee = name;
            PhoneEmployee = phone;
            DateOfBirth = birthday;
            AddressEmployee = address;
            RoleName = rolename;
        }
    }
}
