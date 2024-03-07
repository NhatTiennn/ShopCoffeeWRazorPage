using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class AreaOfCat
    {
        public int AreaOfCatId { get; set; }
        public int AreaId { get; set; }
        public int CatId { get; set; }
        public bool Status { get; set; }

        public virtual Area Area { get; set; } = null!;
        public virtual Cat Cat { get; set; } = null!;
    }
}
