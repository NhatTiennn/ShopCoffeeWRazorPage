using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class SlotBooking
    {
        public SlotBooking()
        {
            Bookings = new HashSet<Booking>();
        }

        public int SlotId { get; set; }
        public string StartTime { get; set; } = null!;
        public int ShopId { get; set; }
        public double Price { get; set; }
        public string EndTime { get; set; } = null!;

        public virtual ShopCoffeeCat Shop { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
