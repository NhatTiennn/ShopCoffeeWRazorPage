using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class FoodCatInfor : FoodForCat
    {
        public int numberOfFood { get; set; } = 0;
        public double foodCatPrice { get; set; } = 0;
    }
}
