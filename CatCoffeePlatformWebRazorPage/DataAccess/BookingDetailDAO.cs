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

        public void Create(BookingDetail bookingDetail)
        {
            _context.BookingDetails.Add(bookingDetail);
            _context.SaveChanges();
        }

        public BookingDetail GetById(int foodCatId)
        {
            return _context.BookingDetails.SingleOrDefault(c => c.FoodCatId == foodCatId);

        }
        public List<BookingDetail> GetAllByBookingId(int bookingId)
        {
            return _context.BookingDetails.Where(p => p.BookingId == bookingId).ToList();
        }

        public void Update(BookingDetail bookingDetail)
        {
            _context.Entry(bookingDetail).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task<double> GetSumDrinkByBookingIdAsync(int bookingId)
        {
            double sumDrink =(double) _context.BookingDetails.Where(p => p.BookingId == bookingId).Sum(c => c.TotalPriceDrink);
            return sumDrink;
        }

        public async Task<double> GetSumFoodByBookingIdAsync(int bookingId)
        {
            double sumFood = (double)_context.BookingDetails.Where(p => p.BookingId == bookingId).Sum(c => c.TotalPriceFood);
            return sumFood;
        }

        public async Task<IList<BookingDetail>> GetAllBookingDetailByBookingId(int bookingId)
        {
            var books = (from bookingDetail in _context.BookingDetails
                         join drink in _context.Drinks on bookingDetail.DrinkId equals drink.DrinkId
                         join food in _context.FoodForCats on bookingDetail.FoodCatId equals food.FoodCatId
                         where bookingDetail.BookingId == bookingId
                         select new BookingDetail
                         {
                             BookingId = bookingDetail.BookingId,
                             BookingDetailId = bookingDetail.BookingDetailId,
                             TotalPriceDrink = bookingDetail.TotalPriceDrink,
                             TotalPriceFood = bookingDetail.TotalPriceFood,
                             NumberOfDrink = bookingDetail.NumberOfDrink,
                             NumberOfFoodCat = bookingDetail.NumberOfFoodCat,
                             Drink = new Drink
                             {
                                DrinkId = drink.DrinkId,
                                DrinkName = drink.DrinkName,
                                ImageDrink =  drink.ImageDrink,
                                Price = drink.Price,
                             },
                             FoodCat = new FoodForCat
                             {
                                FoodCatId = food.FoodCatId,
                                FoodCatName = food.FoodCatName,
                                ImageFoodForCat = food.ImageFoodForCat,
                                FoodPrice = food.FoodPrice,
                             }
                             
                         }).ToList();

            return books;
        }

        public async Task<IList<BookingDetail>> GetAllBookingDetailDrinkByBookingId(int bookingId)
        {
            var books = (from bookingDetail in _context.BookingDetails
                         join drink in _context.Drinks on bookingDetail.DrinkId equals drink.DrinkId
                         where bookingDetail.BookingId == bookingId
                         select new BookingDetail
                         {
                             BookingId = bookingDetail.BookingId,
                             BookingDetailId = bookingDetail.BookingDetailId,
                             TotalPriceDrink = bookingDetail.TotalPriceDrink,
                             TotalPriceFood = bookingDetail.TotalPriceFood,
                             NumberOfDrink = bookingDetail.NumberOfDrink,
                             NumberOfFoodCat = bookingDetail.NumberOfFoodCat,
                             Drink = new Drink
                             {
                                 DrinkId = drink.DrinkId,
                                 DrinkName = drink.DrinkName,
                                 ImageDrink = drink.ImageDrink,
                                 Price = drink.Price,
                             }
                         }).ToList();

            return books;
        }

        public async Task<IList<BookingDetail>> GetAllBookingDetailFoodByBookingId(int bookingId)
        {
            var books = (from bookingDetail in _context.BookingDetails
                         join food in _context.FoodForCats on bookingDetail.FoodCatId equals food.FoodCatId
                         where bookingDetail.BookingId == bookingId
                         select new BookingDetail
                         {
                             BookingId = bookingDetail.BookingId,
                             BookingDetailId = bookingDetail.BookingDetailId,
                             TotalPriceDrink = bookingDetail.TotalPriceDrink,
                             TotalPriceFood = bookingDetail.TotalPriceFood,
                             NumberOfDrink = bookingDetail.NumberOfDrink,
                             NumberOfFoodCat = bookingDetail.NumberOfFoodCat,
                             
                             FoodCat = new FoodForCat
                             {
                                 FoodCatId = food.FoodCatId,
                                 FoodCatName = food.FoodCatName,
                                 ImageFoodForCat = food.ImageFoodForCat,
                                 FoodPrice = food.FoodPrice,
                             }

                         }).ToList();

            return books;
        }
    }
}
