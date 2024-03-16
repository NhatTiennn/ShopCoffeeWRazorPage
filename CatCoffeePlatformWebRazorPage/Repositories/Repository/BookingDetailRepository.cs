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
        public void Create(BookingDetail bookingDetail)
        {
            BookingDetailDAO.Instance.Create(bookingDetail);
        }

        public BookingDetail GetById(int foodCatId)
        {
          return  BookingDetailDAO.Instance.GetById(foodCatId);
        }

        public void Update(BookingDetail bookingDetail)
        {
            BookingDetailDAO.Instance.Update(bookingDetail);
        }

        public List<BookingDetail> GetAllByBookingId(int bookingId)
        {
            return BookingDetailDAO.Instance.GetAllByBookingId(bookingId);
        }

        public async Task<double> GetSumDrinkByBookingIdAsync(int bookingId)
        {
          return await BookingDetailDAO.Instance.GetSumDrinkByBookingIdAsync(bookingId);
        }

        public async Task<double> GetSumFoodByBookingIdAsync(int bookingId)
        { 
           return await BookingDetailDAO.Instance.GetSumFoodByBookingIdAsync(bookingId);
        }

        public Task<IList<BookingDetail>> GetAllBookingDetailByBookingId(int bookingId)
        {
            return BookingDetailDAO.Instance.GetAllBookingDetailByBookingId(bookingId);
        }

        public Task<IList<BookingDetail>> GetAllBookingDetailDrinkByBookingId(int bookingId)
        {
            return BookingDetailDAO.Instance.GetAllBookingDetailDrinkByBookingId(bookingId);
        }

        public Task<IList<BookingDetail>> GetAllBookingDetailFoodByBookingId(int bookingId)
        {
            return BookingDetailDAO.Instance.GetAllBookingDetailFoodByBookingId(bookingId) ;
        }
    }
}
