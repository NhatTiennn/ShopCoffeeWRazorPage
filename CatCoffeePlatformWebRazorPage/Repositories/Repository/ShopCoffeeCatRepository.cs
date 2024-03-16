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
    public class ShopCoffeeCatRepository : IShopCoffeeCatRepository
    {
        public void CreateShopCoffee(ShopCoffeeCat request)
        {
            ShopCoffeeCatDAO.Instance.CreateShopCoffee(request);
        }

        public List<ShopCoffeeCat> GetAll()
        {
            return ShopCoffeeCatDAO.Instance.GetAll();
        }


        public ShopCoffeeCat GetById(int? id)
        {
            return ShopCoffeeCatDAO.Instance.GetById(id);
        }

        public List<Cat> GetCatByShopId(int id)
        {
            return ShopCoffeeCatDAO.Instance.GetCatByShopId(id);
        }

        public List<Drink> GetDrinkByShopId(int id)
        {
            return ShopCoffeeCatDAO.Instance.GetDinkByShopId(id);
        }

        public List<FoodForCat> GetFoodForCatByShopId(int id)
        {
            return ShopCoffeeCatDAO.Instance.GetFoodForCatByShopId(id);
        }

        public List<ShopCoffeeCat> GetTop10Shops()
        {
            return ShopCoffeeCatDAO.Instance.GetTop10Shops();
        }

        public List<ShopCoffeeCat> SearchShops(string catTypeName)
        {
            return ShopCoffeeCatDAO.Instance.SearchShops(catTypeName);
        }
    }
}
