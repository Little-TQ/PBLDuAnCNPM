using Jewelry.DAL;
using Jewelry.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.BLL
{
    internal class InvoiceBLL
    {
        private InvoiceDAL dal = new InvoiceDAL();


        public bool SaveInvoice(InvoiceDTO invoice, List<InvoiceDetailDTO> details)
        {
            if (dal.InsertInvoice(invoice))
            {
                return dal.InsertInvoiceDetails(details);
            }
            return false;
        }
    }
}
