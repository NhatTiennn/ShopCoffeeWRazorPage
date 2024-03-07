using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookingDetailDAO
    {
        private CatCoffeePlatformContext _context = new CatCoffeePlatformContext();
        private static BookingDetailDAO instance;
        private static readonly object instanceLock = new object();
        private BookingDetailDAO() { }
        public static BookingDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BookingDetailDAO();
                    }
                }
                return instance;
            }
        }

        public void create(BookingDetail bookingDetail)
        {
            _context.BookingDetails.Add(bookingDetail);
            _context.SaveChanges();
        }

        public BookingDetail GetById(int foodCatId)
        {
            return _context.BookingDetails.SingleOrDefault(c => c.FoodCatId == foodCatId);

        }

        public void update(BookingDetail bookingDetail)
        {
            _context.Entry(bookingDetail).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
