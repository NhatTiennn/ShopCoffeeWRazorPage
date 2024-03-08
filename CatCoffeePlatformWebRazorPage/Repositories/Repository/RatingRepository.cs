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
    public class RatingRepository : IRatingRepository
    {
        public async Task<int> GetRatingAShop(int? shopId)
        {
            return await RatingDAO.Instance.GetRatingAShop(shopId);
        }


        public async Task<int> GetRatingByUser(int? accountId, int? shopId)
        {
            return await RatingDAO.Instance.GetRatingByUser(accountId, shopId);
        }

        public async Task<int> GetRatingID(int? accountId, int? shopId)
        {
            return await RatingDAO.Instance.GetRatingID(accountId, shopId);
        }

        public async Task<Rating> RatingByUser(Rating request)
        {
            return await RatingDAO.Instance.RatingByUser(request);
        }
    }
}
