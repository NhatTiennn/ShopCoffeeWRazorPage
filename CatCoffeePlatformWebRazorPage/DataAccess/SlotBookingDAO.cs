using BusinessObject.DTO;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SlotBookingDAO
    {
        private CatCoffeePlatformContext _context = new CatCoffeePlatformContext();
        private static SlotBookingDAO instance;
        private static readonly object instanceLock = new object();
        private SlotBookingDAO() { }
        public static SlotBookingDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new SlotBookingDAO();
                    }
                }
                return instance;
            }
        }
        public SlotBooking GetById(int slotId)
        {
            return _context.SlotBookings.SingleOrDefault(p => p.SlotId == slotId);
        }

        public List<SlotBooking> GetSlotByShopId(int shopId)
        {
            return _context.SlotBookings.Where(p =>p.ShopId == shopId).ToList();
        }

        public SlotBooking GetSlotByShopId(int slotId, int shopId)
        {
            return _context.SlotBookings.SingleOrDefault(p => p.SlotId == slotId && p.ShopId == shopId);
        }

        public List<SlotInformation> GetByShopId(int shopId)
        {
            var listSlot = _context.SlotBookings.Where(p => p.ShopId == shopId).ToList();
            List<SlotInformation> list = new List<SlotInformation>();
            foreach (var slot in listSlot)
            {
                list.Add(new SlotInformation()
                {
                    StartTime = slot.StartTime,
                    EndTime = slot.EndTime,
                    ShopId = slot.ShopId,
                    Price = slot.Price,
                    StartEndTime = slot.StartTime + "-" + slot.EndTime
                });
            }
            return list;
        }
        public SlotBooking GetShopByStartTime(string startTime, int shopId)
        {
            return _context.SlotBookings.SingleOrDefault(p => p.StartTime.Equals(startTime) && p.ShopId == shopId);
        }
    }
}
