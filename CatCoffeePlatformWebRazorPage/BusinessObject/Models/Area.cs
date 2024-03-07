using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Area
    {
        public Area()
        {
            AreaOfCats = new HashSet<AreaOfCat>();
            Tables = new HashSet<Table>();
        }

        public int AreaId { get; set; }
        public string AreaName { get; set; } = null!;
        public int ShopId { get; set; }
        public int AccountId { get; set; }
        public bool Status { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual ShopCoffeeCat Shop { get; set; } = null!;
        public virtual ICollection<AreaOfCat> AreaOfCats { get; set; }
        public virtual ICollection<Table> Tables { get; set; }
    }
}
