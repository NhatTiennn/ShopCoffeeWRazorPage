using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class DinkInfor : Drink
    {
        public int numberOfDrink { get; set; } = 0;
        public double Price { get; set; } = 0;

    }
}
