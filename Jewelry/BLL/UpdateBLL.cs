using System;
using System.Data;
using Jewelry.DAL;
using Jewelry.DTO;

namespace Jewelry.BLL
{
    internal class UpdateBLL
    {
        private UpdateDAL updateDAL = new UpdateDAL();

        //Lấy tất cả lịch sử cập nhật giá (hoặc theo chất liệu)
        public DataTable GetAllUpdatePrices(string idMaterial = null)
        {
            return updateDAL.GetAllUpdatePrices(idMaterial);
        }

        //Lấy giá hiện tại của một chất liệu
        public (decimal SalePrice, decimal RepurchasePrice) GetCurrentPrices(string idMaterial)
        {
            return updateDAL.GetCurrentPrices(idMaterial);
        }

        //Lấy danh sách tất cả chất liệu
        public DataTable GetAllMaterials()
        {
            return updateDAL.GetAllMaterials();
        }

        //Lấy thống kê giá (cao nhất, thấp nhất, lần cập nhật cuối)
        public DataTable GetPriceStatistics(string idMaterial)
        {
            return updateDAL.GetPriceStatistics(idMaterial);
        }

        //Tạo ID tự động dạng "UPyyMMddHHmmss"
        public string GenerateUpdateId()
        {
            string time = DateTime.Now.ToString("yyMMddHHmmss");
            return "UP" + time;
        }

        //Validate dữ liệu nhập từ form
        public string ValidatePriceUpdate(string priceText, string repurchasePriceText, string materialId)
        {
            if (string.IsNullOrWhiteSpace(materialId))
                return "Please choose a material!";

            if (string.IsNullOrWhiteSpace(priceText))
                return "Please enter new price!";

            if (string.IsNullOrWhiteSpace(repurchasePriceText))
                return "Please enter repurchase price!";

            if (!decimal.TryParse(priceText, out decimal price) || price <= 0)
                return "Price is number and must larger than 0!";
            if (!decimal.TryParse(repurchasePriceText, out decimal repurchasePrice) || repurchasePrice <= 0)
                return "Repurchase price must be a number and larger than 0!";

            return "VALID";
        }
     
        //Lấy giá mới nhất và thay đổi gần nhất của 1 chất liệu
        public (decimal Price, decimal Change) GetLatestPriceAndChange(string idMaterial)
        {
            return updateDAL.GetLatestPriceAndChange(idMaterial);
        }
        //Lấy giá mua vào + thay đổi giá mua vào gần nhất của 1 chất liệu  
        public (decimal Repurchase, decimal RepurchaseChange) GetLatestRepurchasePriceAndChange(string idMaterial)
        {
            return updateDAL.GetLatestRepurchasePriceAndChange(idMaterial);
        }
        //Lấy bản ghi mới nhất trong bảng UpdatePrice
        public DataRow GetLatestRowByMaterial(string idMaterial)
        {
            return updateDAL.GetLatestRowByMaterial(idMaterial);
        }
        //Lấy dữ liệu giá trong ngày để vẽ biểu đồ
        public DataTable GetDailyPriceChartData(string idMaterial, DateTime selectedDate)
        {
            return updateDAL.GetDailyPriceChartData(idMaterial, selectedDate);
        }
        // Cập nhật giá mới
        public bool UpdatePrice(UpdateDTO updateDTO)
        {
            bool inserted = updateDAL.InsertUpdatePrice(updateDTO);
            bool updated = updateDAL.UpdateProductPriceByMaterial(updateDTO.idMaterial, updateDTO.Price);
            return inserted && updated;
        }
    }
}
