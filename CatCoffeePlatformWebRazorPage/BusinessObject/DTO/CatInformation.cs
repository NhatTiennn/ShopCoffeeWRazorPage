using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class CatInformation : Cat
    {
        public string ShopName { get; set; }
        public string CatTypeName { get; set; }
    }
}
