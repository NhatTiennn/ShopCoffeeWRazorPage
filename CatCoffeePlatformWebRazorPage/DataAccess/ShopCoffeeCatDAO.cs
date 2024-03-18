using BusinessObject.Models;
using DataAccess.Constants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccess.Constants.Constant;

namespace DataAccess
{
    public class ShopCoffeeCatDAO
    {
        private CatCoffeePlatformContext _context = new CatCoffeePlatformContext();
        private static ShopCoffeeCatDAO instance;
        private static readonly object instanceLock = new object();
        private ShopCoffeeCatDAO() { }
        public static ShopCoffeeCatDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ShopCoffeeCatDAO();
                    }
                }
                return instance;
            }
        }
        public List<ShopCoffeeCat> GetAll()
        {
            var shop = _context.ShopCoffeeCats.ToList();
            return shop;
        }

        public List<ShopCoffeeCat> SearchShops(string catTypeName)
        {
            var shopsWithMatchingCatType = _context.ShopCoffeeCats
                .Where(shop => shop.Cats.Any(cat => cat.CatType.CatTypeName == catTypeName))
                .ToList();
            return shopsWithMatchingCatType;
        }

        public ShopCoffeeCat GetById(int? id)
        {
            ShopCoffeeCat infor = null;
            infor = _context.ShopCoffeeCats.SingleOrDefault(s => s.ShopId == id);
            return infor;
        }

        public List<Drink> GetDinkByShopId(int id)
        {
            return _context.ShopCoffeeCats
                .Where(s => s.ShopId == id)
                .SelectMany(s => s.Drinks)
                .ToList();
        }

        public List<Cat> GetCatByShopId(int id)
        {
            var cats = (from shop in _context.ShopCoffeeCats
                        join cat in _context.Cats on shop.ShopId equals cat.ShopId
                        join catType in _context.CatTypes on cat.CatTypeId equals catType.CatTypeId
                        where shop.ShopId == id
                        select new Cat
                        {
                            CatId = cat.CatId,
                            CatName = cat.CatName,
                            CatInfo = cat.CatInfo,
                            ImageCat = cat.ImageCat,
                            CatType = new CatType
                            {
                                CatTypeId = catType.CatTypeId,
                                CatTypeName = catType.CatTypeName
                            }
                        }).ToList();

            return cats;
        }


        public List<FoodForCat> GetFoodForCatByShopId(int id)
        {
            return _context.ShopCoffeeCats
                            .Where(s => s.ShopId == id)
                            .SelectMany(s => s.FoodForCats)
                            .ToList();
        }

        public List<ShopCoffeeCat> GetTop10Shops()
        {
            var top10Shops = _context.ShopCoffeeCats.OrderByDescending(shop => shop.ShopId)
                .Take(10)
                .ToList();

            return top10Shops;
        }

        public void CreateShopCoffee(ShopCoffeeCat request)
        {
            _context.ShopCoffeeCats.Add(request);
            _context.SaveChanges();
        }

        public async Task<IList<ShopCoffeeCat>> ManagerShopByAdmin(int roleId)
        {
            if(roleId == Constant.Role.ADMIN)
            {
                IList<ShopCoffeeCat> list = GetAll();
                return list;
            }

            return null;
        }

        public async Task<ShopCoffeeCat> ChangeStatusByAdmin(int shopId, int roleId)
        {
            if (roleId == Constant.Role.ADMIN)
            {
                var getOneShop = await _context.ShopCoffeeCats.FirstOrDefaultAsync(x => x.ShopId == shopId);
                if (getOneShop != null)
                {
                    getOneShop.Status = false;
                    await _context.SaveChangesAsync();
                    return getOneShop;
                }
                return null;
            }
            return null;
        }
    }
}
