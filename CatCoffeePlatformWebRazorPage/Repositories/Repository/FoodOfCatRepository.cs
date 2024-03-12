using BusinessObject.Models;
using DataAccess;
using Repositories.IRepository;

namespace Repositories.Repository
{
    public class FoodOfCatRepository : IFoodOfCatRepository
    {
        public async void CreateFoodOfCat(FoodForCat request)
        {
            FoodOfCatDAO.Instance.CreateFoodOfCat(request);
        }

        public async Task<IList<FoodForCat>> ListFoodOfShop(int shopId)
        {
            return await FoodOfCatDAO.Instance.ListFoodOfShop(shopId);
        }

        public async void UpdateFoodInfor(FoodForCat request)
        {
            FoodOfCatDAO.Instance.UpdateFoodOfCat(request);
        }
    }
}
