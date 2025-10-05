using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jewelry.DAL;
using Jewelry.DTO;

namespace Jewelry.BLL
{
    public class UpdateBLL
    {
        private UpdateDAL updateDAL = new UpdateDAL();

        // Lấy tất cả lịch sử cập nhật giá
        public DataTable GetAllUpdatePrices()
        {
            return updateDAL.GetAllUpdatePrices();
        }

        // Lấy giá mới nhất của chất liệu
        public decimal GetLatestPriceByMaterial(string idMaterial)
        {
            return updateDAL.GetLatestPriceByMaterial(idMaterial);
        }

        // Thực hiện cập nhật giá
        public bool UpdatePrice(UpdateDTO updateDTO)
        {
            // Thêm bản ghi lịch sử
            bool historySuccess = updateDAL.InsertUpdatePrice(updateDTO);

            // Cập nhật PricePerOunce trong Product
            bool productSuccess = updateDAL.UpdateProductPricePerOunce(updateDTO.idMaterial, updateDTO.Price);

            return historySuccess && productSuccess;
        }

        // Lấy tất cả chất liệu
        public DataTable GetAllMaterials()
        {
            return updateDAL.GetAllMaterials();
        }

        // Lấy PricePerOunce hiện tại
        public decimal GetCurrentPricePerOunce(string idMaterial)
        {
            return updateDAL.GetCurrentPricePerOunce(idMaterial);
        }

        // Lấy thông tin thống kê
        public DataTable GetPriceStatistics(string idMaterial)
        {
            return updateDAL.GetPriceStatistics(idMaterial);
        }

        // Tạo ID mới cho bản ghi cập nhật
        public string GenerateUpdateId()
        {
            return "UP" + DateTime.Now.ToString("D3");
        }

        // Validate dữ liệu nhập
        public string ValidatePriceUpdate(string priceText, string selectedMaterial)
        {
            if (string.IsNullOrEmpty(selectedMaterial))
                return "Vui lòng chọn chất liệu!";

            if (string.IsNullOrEmpty(priceText))
                return "Vui lòng nhập giá mới!";

            if (!decimal.TryParse(priceText, out decimal price) || price <= 0)
                return "Giá phải là số và lớn hơn 0!";

            return "VALID";
        }
    }
}