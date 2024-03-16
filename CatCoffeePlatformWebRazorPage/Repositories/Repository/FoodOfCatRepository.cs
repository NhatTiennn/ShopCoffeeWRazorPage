using BusinessObject.DTO;
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

        public List<BookingDetailInformation> GetByShopId(int shopId)
        {
            return FoodOfCatDAO.Instance.GetByShopId(shopId);
        }

        public async Task<IList<FoodForCat>> ListFoodOfShop(int shopId)
        {
            return await FoodOfCatDAO.Instance.ListFoodOfShop(shopId);
        }

        public async void UpdateFoodInfor(FoodForCat request)
        {
            FoodOfCatDAO.Instance.UpdateFoodOfCat(request);
        }

        public List<FoodCatInfor> GetAllByShopId(int shopId)
        {
            return FoodOfCatDAO.Instance.GetAllByShopId(shopId);
        }
        public FoodForCat GetByFoodName(string foodName, int shopId)
        {
            return FoodOfCatDAO.Instance.GetByFoodName(foodName, shopId);
        }
    }
}
