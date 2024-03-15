using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "AreaName is required.")]
        [StringLength(100, ErrorMessage = "AreaName must be at most 100 characters long.")]
        public string AreaName { get; set; } = null!;
        [Required(ErrorMessage = "Shop is required.")]
        public int ShopId { get; set; }
        [Required(ErrorMessage = "Account is required.")]
        public int AccountId { get; set; }
        public bool Status { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual ShopCoffeeCat Shop { get; set; } = null!;
        public virtual ICollection<AreaOfCat> AreaOfCats { get; set; }
        public virtual ICollection<Table> Tables { get; set; }
    }
}
