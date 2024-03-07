using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class BookingInformation : Booking
    {
        public string tableName {  get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public double price {  get; set; }
        public string shopName { get; set; }
    }
}
