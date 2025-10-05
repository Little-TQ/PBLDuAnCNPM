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

        //Get Data
        public DataTable GetPropertyData(string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
                throw new Exception("Table name is not valid");
            return propertyDAL.GetPropertyData(tableName);
        }
        //Generate ID
        public string GenerateNewPropertyID(string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
                throw new Exception("Table name cannot be empty");

            return propertyDAL.GenerateNewPropertyID(tableName);
        }
        //Add new item
        public bool AddPropertyItem(string tableName, string columnName, string value, string id)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("Value cannot be empty");

            return propertyDAL.AddPropertyItem(tableName, columnName, value, id);
        }
        //Delete item
        public bool DeletePropertyItem(string tableName, string idColumn, string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new Exception("Invalid ID");
            return propertyDAL.DeletePropertyItem(tableName, idColumn, id);
        }
        //Update
        public bool UpdatePropertyItem(string tableName, string idColumn, string id, string nameColumn, string newValue)
        {
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(newValue))
                throw new Exception("Invalid data");
            return propertyDAL.UpdatePropertyItem(tableName, idColumn, id, nameColumn, newValue);
        }
    }
}
