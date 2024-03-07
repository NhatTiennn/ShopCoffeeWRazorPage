using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Rating
    {
        public int RateId { get; set; }
        public int RateNumber { get; set; }
        public int ShopId { get; set; }
        public int AccountId { get; set; }
        public bool Status { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual ShopCoffeeCat Shop { get; set; } = null!;
    }
}
