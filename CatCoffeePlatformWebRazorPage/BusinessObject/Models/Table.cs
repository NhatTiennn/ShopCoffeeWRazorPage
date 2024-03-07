using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Table
    {
        public Table()
        {
            Bookings = new HashSet<Booking>();
        }

        public int TableId { get; set; }
        public int ShopId { get; set; }
        public int AreaId { get; set; }
        public string TableName { get; set; } = null!;
        public bool Status { get; set; }

        public virtual Area Area { get; set; } = null!;
        public virtual ShopCoffeeCat Shop { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
