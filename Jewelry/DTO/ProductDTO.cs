using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DTO
{
    public class ProductDTO
    {
        public string idProduct { get; set; }
        public string NameProduct { get; set; }
        public decimal? PriceSilver { get; set; }
        public decimal? Wage { get; set; }
        public int Sold { get; set; }
        public int Instock { get; set; }
        public string idCategory { get; set; }
        public string idMaterial { get; set; }
        public string idColor { get; set; }
        public string idCollection { get; set; }
        public string Gender { get; set; }
        public double? Weight { get; set; }
        public double? Size { get; set; }
        public string Photo { get; set; }

        public ProductDTO() { }
        public ProductDTO(string idProduct, string nameProduct, decimal? priceSilver, decimal? wage,
                     int sold, int instock, string idCategory, string idMaterial,
                     string idColor, string idCollection, string gender,
                     double? weight, double? size, string photo)
        {
            this.idProduct = idProduct;
            this.NameProduct = nameProduct;
            this.PriceSilver = priceSilver;
            this.Wage = wage;
            this.Sold = sold;
            this.Instock = instock;
            this.idCategory = idCategory;
            this.idMaterial = idMaterial;
            this.idColor = idColor;
            this.idCollection = idCollection;
            this.Gender = gender;
            this.Weight = weight;
            this.Size = size;
            this.Photo = photo;
        }

    }
}
