using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface ISlotBookingRepository
    {
        public SlotBooking GetById(int slotId);
        public List<SlotBooking> GetSlotByShopId(int shopId);
        public SlotBooking GetSlotByShopId(int slotId, int shopId);


    }
}
