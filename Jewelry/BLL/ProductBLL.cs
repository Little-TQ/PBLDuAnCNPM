using Jewelry.DAL;
using Jewelry.DTO;
using System;
using System.Data;

namespace Jewelry.BLL
{
    internal class ProductBLL
    {
        private ProductDAL productDAL = new ProductDAL();

        //Get all Products
        public DataTable GetAllProducts()
        {
            return productDAL.GetAllProducts();
        }

        // Get Product by ID
        public ProductDTO GetProductByID(string idProduct)
        {
            if (string.IsNullOrWhiteSpace(idProduct))
                throw new Exception("idProduct is not valid.");

            return productDAL.GetProductByID(idProduct);
        }

        //Generate ID
        public string GenerateProductID(string categoryName, string materialName)
        {
            if (string.IsNullOrWhiteSpace(categoryName) || string.IsNullOrWhiteSpace(materialName))
                throw new Exception("Category and Material cannot be null.");

            return productDAL.GenerateProductID(categoryName, materialName);
        }

        //Add new 
        public bool AddNewProduct(ProductDTO product)
        {
            // Validate
            if (product == null)
                throw new Exception("Product data is null.");

            if (string.IsNullOrWhiteSpace(product.idProduct))
                throw new Exception("Product ID cannot be null.");

            if (string.IsNullOrWhiteSpace(product.NameProduct))
                throw new Exception("Product name cannot be empty.");

            if (string.IsNullOrWhiteSpace(product.idCategory))
                throw new Exception("Category cannot be empty.");

            if (string.IsNullOrWhiteSpace(product.idMaterial))
                throw new Exception("Material cannot be empty.");

            if (string.IsNullOrWhiteSpace(product.idColor))
                throw new Exception("Color cannot be empty.");

            if (string.IsNullOrWhiteSpace(product.Gender))
                throw new Exception("Gender cannot be empty.");

            if (string.IsNullOrWhiteSpace(product.Photo))
                throw new Exception("Photo path cannot be null.");

            // Validate
            if ((product.PriceSilver.HasValue && product.PriceSilver < 0) ||
                (product.Wage.HasValue && product.Wage < 0) ||
                product.Instock < 0 ||
                (product.Weight.HasValue && product.Weight < 0))
            {
                throw new Exception("Numeric fields cannot be negative.");
            }

            return productDAL.InsertProduct(product);
        }

        //Update
        public bool EditProduct(ProductDTO product)
        {
            if (product == null)
                throw new Exception("Product data is null.");

            if (string.IsNullOrWhiteSpace(product.idProduct))
                throw new Exception("Product ID is not valid.");

            if (string.IsNullOrWhiteSpace(product.Photo))
                product.Photo = "Product Photo\\NoImage.png";

            // Validate cơ bản
            if (string.IsNullOrWhiteSpace(product.NameProduct))
                throw new Exception("Product name cannot be empty.");

            return productDAL.UpdateProduct(product);
        }

        //Delete
        public bool DeleteProduct(string idProduct)
        {
            if (string.IsNullOrWhiteSpace(idProduct))
                throw new Exception("idProduct is not valid.");

            return productDAL.DeleteProduct(idProduct);
        }
        public string GetProductIDByName(string name)
        {
            return new ProductDAL().GetProductIDByName(name);
        }

    }
}
