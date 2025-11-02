using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jewelry.DAL;
using Jewelry.DTO;

namespace Jewelry.BLL
{
    public class RepurchaseDetailBLL
    {
        private RepurchaseDetailDAL dal = new RepurchaseDetailDAL();

        public bool SaveRepurchaseDetail(RepurchaseDetailDTO repurchase)
        {
            return dal.InsertRepurchaseDetail(repurchase);
        }

        public bool SaveRepurchaseDetails(List<RepurchaseDetailDTO> repurchases)
        {
            return dal.InsertRepurchaseDetails(repurchases);
        }
    }
}
