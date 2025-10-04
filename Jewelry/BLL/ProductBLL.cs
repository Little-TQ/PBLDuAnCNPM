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
    internal class ProductBLL
    {
        private ProductDAL productDAL = new ProductDAL();

        //Get all products
        public DataTable GetAllProducts()
        {
            return productDAL.GetAllProducts();
        }

        // Get product by ID
        public ProductDTO GetProductByID(string idProduct)
        {
            if (string.IsNullOrWhiteSpace(idProduct))
                throw new Exception("idProduct is not valid");
            return productDAL.GetProductByID(idProduct);
        }
        // Generate new product ID
        public string GenerateProductID(string categoryName, string materialName)
        {
            if (string.IsNullOrWhiteSpace(categoryName) || string.IsNullOrWhiteSpace(materialName))
                throw new Exception("Category and Material cannot be null");
            return productDAL.GenerateProductID(categoryName, materialName);
        }

        //Add new product
        public bool AddNewProduct(ProductDTO product)
        {
            if (string.IsNullOrWhiteSpace(product.idProduct))
                throw new Exception("idProduct cannot be null");
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

            // validate number fields
            if (product.PriceSilver < 0 || product.Wage < 0 || product.Instock < 0 || product.Weight < 0)
                throw new Exception("Numeric fields cannot be negative");

            return productDAL.InsertProduct(product);
        }

        //Edit product
        public bool EditProduct(ProductDTO product)
        {
            if (string.IsNullOrWhiteSpace(product.idProduct))
                throw new Exception("idProduct is not valid");

            return productDAL.UpdateProduct(product);
        }

        //Delete product
        public bool DeleteProduct(string idProduct)
        {
            if (string.IsNullOrWhiteSpace(idProduct))
                throw new Exception("idProduct is not valid");
            return productDAL.DeleteProduct(idProduct);
        }
    }
}

