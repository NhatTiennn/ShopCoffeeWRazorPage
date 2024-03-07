using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class FoodForCat
    {
        public FoodForCat()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public int FoodCatId { get; set; }
        public int ShopId { get; set; }
        public string FoodCatName { get; set; } = null!;
        public string FoodCatInfo { get; set; } = null!;
        public double FoodPrice { get; set; }
        public string ImageFoodForCat { get; set; } = null!;
        public bool Status { get; set; }

        public virtual ShopCoffeeCat Shop { get; set; } = null!;
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
