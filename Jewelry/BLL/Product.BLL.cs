using Jewelry.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jewelry.DTO;

namespace Jewelry.BLL
{
    public class Product
    {
        private ProductDAL productDAL = new ProductDAL();
        public DataTable GetAllProducs()
        {
            return productDAL.GetAllProducts();
        }
        //Add a new product to the database
        public bool AddNewProduct(ProductDTO product)
        {
            if (string.IsNullOrWhiteSpace(product.NameProduct))
                throw new Exception("Name Product cannot be null");

            if (string.IsNullOrWhiteSpace(product.idMaterial))
                throw new Exception("Material cannot be null");

            if (string.IsNullOrWhiteSpace(product.idCategory))
                throw new Exception("Category cannot be null");

            if (string.IsNullOrWhiteSpace(product.idColor))
                throw new Exception("Color cannot be null");

            if (string.IsNullOrWhiteSpace(product.Gender))
                throw new Exception("Gender cannot be null");

            if (string.IsNullOrWhiteSpace(product.Photo))
                throw new Exception("Photo cannot be null");

            return productDAL.InsertProduct(product);
        }
        //Edit a product in the database
        public bool EditProduct(ProductDTO product)
        {
            if (string.IsNullOrWhiteSpace(product.idProduct))
                throw new Exception("idProduct is not valid");

            return productDAL.UpdateProduct(product);
        }
        //Delete a product from the database
        public bool DeleteProduct(string idProduct)
        {
            if (string.IsNullOrWhiteSpace(idProduct))
                throw new Exception("idProduct is not valid");
            return productDAL.DeleteProduct(idProduct);
        }
    }
}
