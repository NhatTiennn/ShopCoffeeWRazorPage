using BusinessObject.Models;
using DataAccess;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class SlotBookingRepository : ISlotBookingRepository
    {
        public SlotBooking GetById(int slotId)
        {
            return SlotBookingDAO.Instance.GetById(slotId);
        }

        public List<SlotBooking> GetSlotByShopId(int shopId)
        {
            return SlotBookingDAO.Instance.GetSlotByShopId(shopId);
        }

        public SlotBooking GetSlotByShopId(int slotId, int shopId)
        {
            return SlotBookingDAO.Instance.GetSlotByShopId(shopId, slotId);
        }
    }
}
