using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Cat
    {
        public Cat()
        {
            AreaOfCats = new HashSet<AreaOfCat>();
        }

        public int CatId { get; set; }
        public int CatTypeId { get; set; }
        public int ShopId { get; set; }
        public string CatInfo { get; set; } = null!;
        public string CatName { get; set; } = null!;
        public string ImageCat { get; set; } = null!;
        public bool Status { get; set; }

        public virtual CatType CatType { get; set; } = null!;
        public virtual ShopCoffeeCat Shop { get; set; } = null!;
        public virtual ICollection<AreaOfCat> AreaOfCats { get; set; }
    }
}
