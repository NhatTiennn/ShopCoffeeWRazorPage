using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IRatingRepository
    {
        Task<int> GetRatingAShop(int shopId);
        Task<int> GetRatingByUser(int accountId, int shopId);
        Task<Rating> RatingByUser(Rating request);
    }
}
