using BusinessObject.DTO;
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
    public class DrinkRepository : IDrinkRepository
    {
        public void CreateDrink(Drink request)
        {
            DrinkDAO.Instance.CreateDrinkOfCat(request);
        }

        public List<DinkInfor> GetAllByShopId(int shopId)
        {
            return DrinkDAO.Instance.GetAllByShopId(shopId);
        }

        public Drink GetByDrinkName(string drinkName, int shopId)
        {
            return DrinkDAO.Instance.GetByDrinkName(drinkName, shopId);
        }

        public List<BookingDetailInformation> GetByShopId(int shopId)
        {
            return DrinkDAO.Instance.GetByShopId(shopId);
        }

        public Task<IList<Drink>> ListDrinkOfShop(int shopId)
        {
            return DrinkDAO.Instance.ListDrinkOfShop(shopId);
        }

        public void UpdateDrink(Drink request)
        {
            DrinkDAO.Instance.UpdatelistDrinkSOfCat(request);
        }
    }
}
