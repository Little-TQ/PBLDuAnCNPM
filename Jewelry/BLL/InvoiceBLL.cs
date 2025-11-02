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

        public DataTable GetInvoiceDetails(string invoiceId)
        {
            return new InvoiceDAL().GetInvoiceDetails(invoiceId);
        }
        public InvoiceDTO GetInvoiceById(string invoiceId)
        {
            return new InvoiceDAL().GetInvoiceById(invoiceId);
        }
        public DataTable GetAllInvoicesWithPreview()
        {
            return new InvoiceDAL().GetAllInvoicesWithPreview();
        }
        public DataTable SearchInvoices(string keyword)
        {
            return new InvoiceDAL().SearchInvoices(keyword);
        }
    }
}
