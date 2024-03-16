using BusinessObject.DTO;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

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
        public Booking CheckBookingExist(Booking booking)
        {
            return _context.Bookings.SingleOrDefault(p => p.BookingDate == booking.BookingDate && p.ShopId == booking.ShopId && p.AccountId == booking.AccountId && p.TableId == booking.TableId && p.SlotId == booking.SlotId);
        }
        public Booking GetBookingId(int bookingId)
        {
            return _context.Bookings.SingleOrDefault(p => p.BookingId == bookingId);
        }

       
        public async Task<Booking> GetBookingByBookingId(int bookingId)
        {
            var books = (from book in _context.Bookings
                         join table in _context.Tables on book.TableId equals table.TableId
                         join area in _context.Areas on table.AreaId equals area.AreaId
                         join slot in _context.SlotBookings on book.SlotId equals slot.SlotId
                         join shop in _context.ShopCoffeeCats on book.ShopId equals shop.ShopId
                         where book.BookingId == bookingId
                         orderby book.BookingId
                         select new Booking
                         {
                             BookingId = book.BookingId,
                             BookingDate = book.BookingDate,
                             Total = book.Total,
                             Status = book.Status,
                             Table = new Table
                             {
                                 TableId = table.TableId,
                                 TableName = table.TableName,
                                 Area = new Area
                                 {
                                     AreaId = area.AreaId,
                                     AreaName = area.AreaName,
                                 }
                             },
                             Slot = new SlotBooking
                             {
                                 SlotId = slot.SlotId,
                                 StartTime = slot.StartTime,
                                 Price = slot.Price,
                                 EndTime = slot.EndTime,
                             },
                             Shop = new ShopCoffeeCat
                             {
                                 ShopId = shop.ShopId,
                                 ShopName = shop.ShopName,
                             }
                         }).FirstOrDefault();

            return books;
        }

        public async Task<IList<Booking>> GetAllHistoryBookingByCustomerId(int accountId)
        {
            var books = (from book in _context.Bookings
                        join table in _context.Tables on book.TableId equals table.TableId
                        join area in _context.Areas on table.AreaId equals area.AreaId
                        join slot in _context.SlotBookings on book.SlotId equals slot.SlotId
                        join shop in _context.ShopCoffeeCats on book.ShopId equals shop.ShopId
                        where book.AccountId == accountId
                        orderby book.BookingId
                         select new  Booking
                        {
                            BookingId = book.BookingId,
                            BookingDate = book.BookingDate,
                            Total = book.Total,
                            Status =  book.Status,
                            Table = new Table
                            {
                                TableId = table.TableId,
                                TableName = table.TableName,
                                Area =new Area
                                {
                                    AreaId = area.AreaId,
                                    AreaName = area.AreaName,
                                }
                            },
                            Slot = new SlotBooking
                            {
                                SlotId = slot.SlotId,
                                StartTime = slot.StartTime,
                                EndTime = slot.EndTime,
                            },
                            Shop = new ShopCoffeeCat
                            {
                                ShopId = shop.ShopId,
                                ShopName = shop.ShopName,
                            }
                        }).ToList();

            return books;
        }

        public async Task<IList<Booking>> GetAllHistoryBookingByShopId(int shopId)
        {
            var books = (from book in _context.Bookings
                         join table in _context.Tables on book.TableId equals table.TableId
                         join area in _context.Areas on table.AreaId equals area.AreaId
                         join slot in _context.SlotBookings on book.SlotId equals slot.SlotId
                         join shop in _context.ShopCoffeeCats on book.ShopId equals shop.ShopId
                         join account in _context.Accounts on book.AccountId equals account.AccountId
                         where book.ShopId == shopId
                         select new Booking
                         {
                             BookingId = book.BookingId,
                             BookingDate = book.BookingDate,
                             Total = book.Total,
                             Status = book.Status,
                             Table = new Table
                             {
                                 TableId = table.TableId,
                                 TableName = table.TableName,
                                 Area = new Area
                                 {
                                     AreaId = area.AreaId,
                                     AreaName = area.AreaName,
                                 }
                             },
                             Slot = new SlotBooking
                             {
                                 SlotId = slot.SlotId,
                                 StartTime = slot.StartTime,
                                 EndTime = slot.EndTime,
                             },
                             Shop = new ShopCoffeeCat
                             {
                                 ShopId = shop.ShopId,
                                 ShopName = shop.ShopName,
                             },
                             Account = new Account
                             {
                                 AccountId = account.AccountId,
                                UserName = account.UserName
                             }
                         }).ToList();

            return books;
        }
    }
}
