using BusinessObject.Models;
using DataAccess;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class BookingDetailRepository : IBookingDetailRepository
    {
        public void create(BookingDetail bookingDetail)
        {
            BookingDetailDAO.Instance.create(bookingDetail);
        }

        public BookingDetail GetById(int foodCatId)
        {
          return  BookingDetailDAO.Instance.GetById(foodCatId);
        }

        public void update(BookingDetail bookingDetail)
        {
            BookingDetailDAO.Instance.update(bookingDetail);
        }
    }
}
