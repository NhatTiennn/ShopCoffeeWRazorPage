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
    }
}
