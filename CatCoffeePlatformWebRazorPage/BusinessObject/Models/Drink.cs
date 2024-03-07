using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Drink
    {
        public Drink()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public int DrinkId { get; set; }
        public string DrinkName { get; set; } = null!;
        public string DinkInfo { get; set; } = null!;
        public int ShopId { get; set; }
        public string? ImageDrink { get; set; }
        public double Price { get; set; }
        public bool Status { get; set; }

        public virtual ShopCoffeeCat Shop { get; set; } = null!;
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
