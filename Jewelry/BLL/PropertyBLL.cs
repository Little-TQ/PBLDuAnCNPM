using Jewelry.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.BLL
{
    internal class PropertyBLL
    {
        private PropertyDAL propertyDAL = new PropertyDAL();

        public DataTable GetPropertyData(string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
                throw new Exception("Table name is not valid");
            return propertyDAL.GetPropertyData(tableName);
        }
    }
}
