using BusinessObject.DTO;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookingDAO
    {
        private CatCoffeePlatformContext _context = new CatCoffeePlatformContext();
        private static BookingDAO instance;
        private static readonly object instanceLock = new object();
        private BookingDAO() { }
        public static BookingDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BookingDAO();
                    }
                }
                return instance;
            }
        }
        public List<BookingInformation> GetAll() 
        {
            var list = _context.Bookings.ToList();
            List<BookingInformation> listBooking = new List<BookingInformation>(); 
            foreach (var booking in list)
            {

                ShopCoffeeCat shop = _context.ShopCoffeeCats.SingleOrDefault(p => p.ShopId == booking.ShopId);
                Table table = _context.Tables.SingleOrDefault(p => p.TableId == booking.TableId);
                SlotBooking slotBooking = _context.SlotBookings.SingleOrDefault(p=> p.SlotId == booking.SlotId);
                listBooking.Add(new BookingInformation
                {
                    BookingDate = booking.BookingDate,
                    Total = booking.Total,
                    Status = booking.Status,
                    AccountId = booking.AccountId,
                    shopName = shop.ShopName,
                    tableName = table.TableName,
                    startTime = slotBooking.StartTime,
                    endTime = slotBooking.EndTime,
                    price = slotBooking.Price
                });
               
            }
            return  listBooking;
        }
        public Boolean checkSlot(Booking booking)
        {
            var list = _context.Bookings.Where(p => p.BookingDate == booking.BookingDate && p.SlotId == booking.SlotId && p.TableId == booking.TableId).ToList();
            if (list.Count == 0)
            {
                return false;
            }
            return true;
        }
        public void Create(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public List<Booking> GetByAccountId(int? accountId)
        {
            return _context.Bookings.Where(p => p.AccountId == accountId).ToList();
        }

        public void Update(Booking newBooking)
        {
            _context.Entry(newBooking).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
