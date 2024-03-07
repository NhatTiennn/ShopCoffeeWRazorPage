using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public string Context { get; set; } = null!;
        public int ShopId { get; set; }
        public int AccountId { get; set; }
        public bool Status { get; set; }
    }
}
