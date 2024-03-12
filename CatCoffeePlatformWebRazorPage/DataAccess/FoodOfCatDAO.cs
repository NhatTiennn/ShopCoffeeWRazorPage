using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FoodOfCatDAO
    {
        private CatCoffeePlatformContext _context = new CatCoffeePlatformContext();
        private static FoodOfCatDAO instance;
        private static readonly object instanceLock = new object();
        private FoodOfCatDAO() { }
        public static FoodOfCatDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new FoodOfCatDAO();
                    }
                }
                return instance;
            }
        }

        public async Task<IList<FoodForCat>> ListFoodOfShop(int shopId)
        {

            var checkShop = await _context.ShopCoffeeCats.FirstOrDefaultAsync(x => x.ShopId == shopId);
            if (checkShop != null)
            {
                var listFoodShop = await _context.FoodForCats.Where(x => x.ShopId == shopId).ToListAsync();
                return listFoodShop;
            }
            return null;
        }

        public async void UpdateFoodOfCat(FoodForCat request)
        {
            _context.FoodForCats.Update(request);
            await _context.SaveChangesAsync();
        }

        public async void CreateFoodOfCat(FoodForCat request)
        {
            _context.FoodForCats.Add(request);
            await _context.SaveChangesAsync();
        }
    }
}
