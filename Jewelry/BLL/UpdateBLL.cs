using System;
using System.Data;
using Jewelry.DAL;
using Jewelry.DTO;

namespace Jewelry.BLL
{
    internal class UpdateBLL
    {
        private UpdateDAL updateDAL = new UpdateDAL();

        public DataTable GetAllUpdatePrices(string idMaterial = null)
        {
            return updateDAL.GetAllUpdatePrices(idMaterial);
        }

        public decimal GetCurrentPricePerOunce(string idMaterial)
        {
            return updateDAL.GetCurrentPricePerOunce(idMaterial);
        }

        public DataTable GetAllMaterials()
        {
            return updateDAL.GetAllMaterials();
        }

        public DataTable GetPriceStatistics(string idMaterial)
        {
            return updateDAL.GetPriceStatistics(idMaterial);
        }

        public bool UpdatePrice(UpdateDTO updateDTO)
        {
            bool inserted = updateDAL.InsertUpdatePrice(updateDTO);
            return inserted;
        }

        public string GenerateUpdateId()
        {
            string time = DateTime.Now.ToString("yyMMddHHmmss");
            return "UP" + time;
        }

        public string ValidatePriceUpdate(string priceText, string materialId)
        {
            if (string.IsNullOrWhiteSpace(materialId))
                return "Vui lòng chọn chất liệu!";
            if (string.IsNullOrWhiteSpace(priceText))
                return "Vui lòng nhập giá mới!";
            if (!decimal.TryParse(priceText, out decimal price) || price <= 0)
                return "Giá phải là số và lớn hơn 0!";
            return "VALID";
        }

        //Lấy giá và thay đổi mới nhất
        public (decimal Price, decimal Change) GetLatestPriceAndChange(string idMaterial)
        {
            return updateDAL.GetLatestPriceAndChange(idMaterial);
        }
    }
}
