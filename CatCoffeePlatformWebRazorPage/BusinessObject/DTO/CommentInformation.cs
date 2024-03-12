using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class CommentInformation
    {
        public int CommentId { get; set; }
        public string Context { get; set; } = null!;
        public int ShopId { get; set; }
        public int AccountId { get; set; }
        public bool Status { get; set; }
        public string UserName { get; set; }
    }
}
