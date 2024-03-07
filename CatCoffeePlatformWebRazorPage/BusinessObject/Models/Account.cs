using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Account
    {
        public Account()
        {
            Areas = new HashSet<Area>();
            Bookings = new HashSet<Booking>();
            Ratings = new HashSet<Rating>();
        }

        public int AccountId { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; } = null!;
        public int? ShopId { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public DateTime? Dob { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool Status { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ShopCoffeeCat? Shop { get; set; }
        public virtual ICollection<Area> Areas { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
