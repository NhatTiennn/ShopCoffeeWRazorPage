using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Booking
    {
        public Booking()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public int ShopId { get; set; }
        public double Total { get; set; }
        public int AccountId { get; set; }
        public int TableId { get; set; }
        public int SlotId { get; set; }
        public bool Status { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual ShopCoffeeCat Shop { get; set; } = null!;
        public virtual SlotBooking Slot { get; set; } = null!;
        public virtual Table Table { get; set; } = null!;
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
