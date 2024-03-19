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

        public List<Booking> GetByAccountId(int? accountId)
        {
            return BookingDAO.Instance.GetByAccountId(accountId);
        }

        public void Update(Booking newBooking)
        {
            BookingDAO.Instance.Update(newBooking);
        }
        public Booking CheckBookingExist(Booking booking)
        {
            return BookingDAO.Instance.CheckBookingExist(booking);
        }
        public Booking GetBookingId(int bookingId)
        {
            return BookingDAO.Instance.GetBookingId(bookingId);
        }

        public Task<IList<Booking>> GetAllHistoryBookingByCustomerId(int accountId)
        {
            return BookingDAO.Instance.GetAllHistoryBookingByCustomerId(accountId);
        }

        public Task<IList<Booking>> GetAllHistoryBookingByShopId(int shopId)
        {
            return BookingDAO.Instance.GetAllHistoryBookingByShopId(shopId);
        }

        public Task<Booking> GetBookingByBookingId(int bookingId)
        {
           return BookingDAO.Instance.GetBookingByBookingId(bookingId);

        }

        public void TotalRevenue(int shopId)
        {
            BookingDAO.Instance.TotalRevenue(shopId);
        }
    }
}
