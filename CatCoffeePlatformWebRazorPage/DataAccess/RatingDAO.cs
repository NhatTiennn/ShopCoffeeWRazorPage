using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RatingDAO
    {
        private CatCoffeePlatformContext _context = new CatCoffeePlatformContext();
        private static RatingDAO instance;
        private static readonly object instanceLock = new object();
        private RatingDAO() { }
        public static RatingDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RatingDAO();
                    }
                }
                return instance;
            }
        }

        public async Task<int> GetRatingAShop(int shopId)
        {
            try
            {
                var totalUserRate = await _context.Ratings.AsNoTracking().Where(a => a.ShopId == shopId)
                                            .Select(x => x.AccountId).Distinct().CountAsync();
                var totalRateShop = await _context.Ratings.AsNoTracking().Where(a => a.ShopId == shopId)
                                            .Select(x => x.RateNumber).Distinct().SumAsync();
                var average =totalRateShop/totalUserRate;
                return average;
            }
            catch (Exception ex) { 
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> GetRatingByUser(int accountId,int shopId)
        {
            try
            {
                var scoreShopOfUser = await _context.Ratings.AsNoTracking()
                                        .Where(a => a.AccountId == accountId && a.ShopId == shopId)
                                        .Select(x => x.RateNumber).FirstOrDefaultAsync();
                return scoreShopOfUser;
            }catch (Exception ex) {
                throw new Exception("Error");
            }
        }

        public async Task<Rating> RatingByUser(Rating request)
        {
            try
            {
                var checkUser = GetRatingByUser(request.AccountId, request.ShopId);
                if(checkUser == null)
                {
                    _context.Ratings.Add(request);
                    await _context.SaveChangesAsync();
                }else
                {
                    _context.Ratings.Update(request);
                    await _context.SaveChangesAsync();
                }
                return request;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
