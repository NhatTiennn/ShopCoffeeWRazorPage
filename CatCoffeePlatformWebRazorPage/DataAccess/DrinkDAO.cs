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
    public class DrinkDAO
    {
        private CatCoffeePlatformContext _context = new CatCoffeePlatformContext();
        private static DrinkDAO instance;
        private static readonly object instanceLock = new object();
        private DrinkDAO() { }
        public static DrinkDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new DrinkDAO();
                    }
                }
                return instance;
            }
        }

        public async Task<IList<Drink>> ListDrinkOfShop(int shopId)
        {

            var checkShop = await _context.ShopCoffeeCats.FirstOrDefaultAsync(x => x.ShopId == shopId);
            if (checkShop != null)
            {
                var listDrinkShop = await _context.Drinks.Where(x => x.ShopId == shopId).ToListAsync();
                return listDrinkShop;
            }
            return null;
        }

        public async void UpdatelistDrinkSOfCat(Drink request)
        {
            _context.Drinks.Update(request);
            await _context.SaveChangesAsync();
        }

        public async void CreateDrinkOfCat(Drink request)
        {
            _context.Drinks.Add(request);
            await _context.SaveChangesAsync();
        }

        public List<BookingDetailInformation> GetByShopId(int shopId)
        {
            var listDrink = _context.Drinks.Where(p => p.ShopId == shopId).ToList();
            List<BookingDetailInformation> list = new List<BookingDetailInformation>();
            foreach (var food in listDrink)
            {
                list.Add(new BookingDetailInformation()
                {
                    foodCatAndPrice = food.DrinkName + "-" + "Price :" + food.Price.ToString()
                });
            }
            return list;
        }
        public Drink GetByDrinkName(string drinkName, int shopId)
        {
            return _context.Drinks.SingleOrDefault(p => p.DrinkName.Equals(drinkName) && p.ShopId == shopId);
        }
        public List<DinkInfor> GetAllByShopId(int shopId)
        {
            var list = _context.Drinks.Where(p => p.ShopId == shopId).ToList();
            List<DinkInfor> listDrink = new List<DinkInfor>();
            foreach (var d in list)
            {
                listDrink.Add(new DinkInfor
                {
                    DrinkId = d.DrinkId,
                    ShopId = d.ShopId,
                    DrinkName = d.DrinkName,
                    DinkInfo = d.DinkInfo,
                    Price = d.Price,
                    ImageDrink = d.ImageDrink,
                    numberOfDrink = 0,
                    Status = d.Status
                });
            }
            return listDrink;
        }
    }
}
