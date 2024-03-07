using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class CatType
    {
        public CatType()
        {
            Cats = new HashSet<Cat>();
        }

        public int CatTypeId { get; set; }
        public string CatTypeName { get; set; } = null!;
        public bool Status { get; set; }

        public virtual ICollection<Cat> Cats { get; set; }
    }
}
