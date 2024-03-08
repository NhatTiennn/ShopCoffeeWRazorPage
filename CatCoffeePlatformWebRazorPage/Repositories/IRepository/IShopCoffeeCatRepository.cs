using BusinessObject.Models;
using Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface  IShopCoffeeCatRepository
    {
        List<ShopCoffeeCat> GetAll();

        List<ShopCoffeeCat> SearchShops(string catTypeName);

        List<Drink> GetDrinkByShopId(int id);

        List<FoodForCat> GetFoodForCatByShopId(int id);
        List<Cat> GetCatByShopId(int id);

        ShopCoffeeCat GetById(int? id);
        List<ShopCoffeeCat> GetTop10Shops();

        void CreateShopCoffee(ShopCoffeeCat request);

    }
}
