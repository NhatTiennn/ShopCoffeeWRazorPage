using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class BookingDetail
    {
        public int BookingDetailId { get; set; }
        public int BookingId { get; set; }
        public int? FoodCatId { get; set; }
        public int? DrinkId { get; set; }
        public int? NumberOfDrink { get; set; }
        public int? NumberOfFoodCat { get; set; }

        public virtual Booking Booking { get; set; } = null!;
        public virtual Drink? Drink { get; set; }
        public virtual FoodForCat? FoodCat { get; set; }
    }
}
