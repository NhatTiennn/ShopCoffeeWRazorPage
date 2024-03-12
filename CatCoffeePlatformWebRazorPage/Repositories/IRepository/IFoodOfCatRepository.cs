using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IFoodOfCatRepository
    {
        void CreateFoodOfCat(FoodForCat request);
        void UpdateFoodInfor(FoodForCat request);
        Task<IList<FoodForCat>> ListFoodOfShop(int shopId);
    }
}
