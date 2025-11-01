using Jewelry.DAL;
using Jewelry.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.BLL
{
    internal class FollowOrderBLL
    {
        private FollowOrderDAL dal = new FollowOrderDAL();

        public string GenerateFollowOrderID()
        {
            return dal.GenerateFollowOrderID();
        }

        public bool AddFollowOrder(FollowOrderDTO order)
        {
            return dal.AddFollowOrder(order);
        }
    }
}
