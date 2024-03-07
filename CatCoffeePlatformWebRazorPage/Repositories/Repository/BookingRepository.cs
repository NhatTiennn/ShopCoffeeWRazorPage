using BusinessObject.DTO;
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
    public class BookingRepository : IBookingRepository
    {
        public bool checkSlot(Booking booking)
        {
           return BookingDAO.Instance.checkSlot(booking);
        }

        public void Create(Booking booking)
        {
            BookingDAO.Instance.Create(booking);
        }

        public List<BookingInformation> GetAll()
        {
           return BookingDAO.Instance.GetAll();
        }

        public List<Booking> GetByAccountId(int accountId)
        {
            return BookingDAO.Instance.GetByAccountId(accountId);
        }

        public void Update(Booking newBooking)
        {
            BookingDAO.Instance.Update(newBooking);
        }
    }
}
