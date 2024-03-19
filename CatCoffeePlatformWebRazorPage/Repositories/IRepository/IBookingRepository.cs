using BusinessObject.DTO;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IBookingRepository
    {
        public List<BookingInformation> GetAll();
        public List<Booking> GetByAccountId(int? accountId);
        public void Create(Booking booking);
        public Boolean checkSlot(Booking booking);
        public void Update(Booking newBooking);
        public Booking CheckBookingExist(Booking booking);
        public Booking GetBookingId(int bookingId);
        Task<Booking> GetBookingByBookingId(int bookingId);

        Task<IList<Booking>> GetAllHistoryBookingByCustomerId(int accountId);
        Task<IList<Booking>> GetAllHistoryBookingByShopId(int shopId);

        void TotalRevenue(int shopId);
    }
}
