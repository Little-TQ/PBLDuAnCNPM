using Jewelry.DAL;
using Jewelry.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.BLL
{
    internal class InvoicePreviewBLL
    {
        private InvoicePreviewDAL dal = new InvoicePreviewDAL();

        public bool AddOrUpdatePreview(InvoicePreviewDTO dto)
        {
            if (string.IsNullOrEmpty(dto.idInvoice) || string.IsNullOrEmpty(dto.LinkInvoice))
                return false;
            return dal.AddOrUpdatePreview(dto);
        }

        public List<InvoicePreviewDTO> GetAllPreviews()
        {
            return dal.GetAllPreviews();
        }
    }
}
