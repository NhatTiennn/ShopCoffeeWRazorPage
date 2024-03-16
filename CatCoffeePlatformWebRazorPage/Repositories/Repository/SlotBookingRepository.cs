using BusinessObject.DTO;
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

        public List<SlotInformation> GetByShopId(int shopId)
        {
            return SlotBookingDAO.Instance.GetByShopId(shopId);
        }

        public SlotBooking GetShopByStartTime(string startTime, int value)
        {
            return SlotBookingDAO.Instance.GetShopByStartTime(startTime, value);
        }
    }
}
