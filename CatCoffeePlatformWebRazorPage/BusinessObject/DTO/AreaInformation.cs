using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class AreaInformation : Area
    {
        public string Email { get; set; }
        public string ShopName { get; set; }
    }
}
