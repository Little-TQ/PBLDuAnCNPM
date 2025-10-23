using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DTO
{
    public class UpdateDTO
    {
        public string idUpdate { get; set; }
        public string idMaterial { get; set; }
        public DateTime UpdateTime { get; set; }
        public decimal Price { get; set; }
        public decimal ChangePrice { get; set; }
        public decimal RepurchasePrice { get; set; }
        public decimal RepurchaseChange {  get; set; }

        public UpdateDTO() { }

        public UpdateDTO(string idUpdate, string idMaterial, DateTime updateTime, decimal price, decimal changePrice)
        {
            this.idUpdate = idUpdate;
            this.idMaterial = idMaterial;
            this.UpdateTime = updateTime;
            this.Price = price;
            this.ChangePrice = changePrice;
        }
    }
}