using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IBookingDetailRepository
    {
        public BookingDetail GetById(int foodCatId);
        public void update(BookingDetail bookingDetail);
        public void create(BookingDetail bookingDetail);
    }
}
