using BusinessObject.DTO;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IDrinkRepository
    {
        void CreateDrink(Drink request);
        void UpdateDrink(Drink request);
        Task<IList<Drink>> ListDrinkOfShop(int shopId);
        public List<BookingDetailInformation> GetByShopId(int shopId);
        public List<DinkInfor> GetAllByShopId(int shopId);
        public Drink GetByDrinkName(string drinkName, int shopId);
    }
}
