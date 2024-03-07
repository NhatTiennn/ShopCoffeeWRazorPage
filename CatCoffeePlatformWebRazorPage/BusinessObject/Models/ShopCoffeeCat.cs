using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class ShopCoffeeCat
    {
        public ShopCoffeeCat()
        {
            Accounts = new HashSet<Account>();
            Areas = new HashSet<Area>();
            Bookings = new HashSet<Booking>();
            Cats = new HashSet<Cat>();
            Drinks = new HashSet<Drink>();
            FoodForCats = new HashSet<FoodForCat>();
            Ratings = new HashSet<Rating>();
            SlotBookings = new HashSet<SlotBooking>();
            Tables = new HashSet<Table>();
        }

        public int ShopId { get; set; }
        public string ShopName { get; set; } = null!;
        public string StartTime { get; set; } = null!;
        public string EndTime { get; set; } = null!;
        public string ImageShop { get; set; } = null!;
        public bool Status { get; set; }
        public string Address { get; set; } = null!;

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Area> Areas { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Cat> Cats { get; set; }
        public virtual ICollection<Drink> Drinks { get; set; }
        public virtual ICollection<FoodForCat> FoodForCats { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<SlotBooking> SlotBookings { get; set; }
        public virtual ICollection<Table> Tables { get; set; }
    }
}
