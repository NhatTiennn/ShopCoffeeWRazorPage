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
        public void Update(BookingDetail bookingDetail);
        public void Create(BookingDetail bookingDetail);
        public List<BookingDetail> GetAllByBookingId(int bookingId);
        Task<double> GetSumDrinkByBookingIdAsync(int bookingId);
        Task<double> GetSumFoodByBookingIdAsync(int bookingId);
        Task<IList<BookingDetail>> GetAllBookingDetailByBookingId(int bookingId);
        Task<IList<BookingDetail>> GetAllBookingDetailDrinkByBookingId(int bookingId);
        Task<IList<BookingDetail>> GetAllBookingDetailFoodByBookingId(int bookingId);



    }
}
