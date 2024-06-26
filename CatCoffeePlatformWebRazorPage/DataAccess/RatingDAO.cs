﻿using BusinessObject.Models;
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

        public async Task<int> GetRatingAShop(int? shopId)
        {
            try
            {
                int totalUserRate = await _context.Ratings.AsNoTracking().Where(a => a.ShopId == shopId)
                                            .Select(x => x.AccountId).Distinct().CountAsync();
                var totalRateShop = await _context.Ratings.AsNoTracking().Where(a => a.ShopId == shopId)
                                            .Select(x => x.RateNumber).Distinct().SumAsync();
                int average = 0;
                if (totalUserRate == 0)
                {
                    average = totalRateShop / 1;

                }
                else if (totalUserRate == 1)
                {
                    average = totalRateShop / 1;
                }
                else
                {
                    average = totalRateShop / 5;
                }
                if (average > 0)
                {
                    return average;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> GetRatingByUser(int? accountId, int? shopId)
        {
            try
            {
                int score =  await _context.Ratings.AsNoTracking()
                                        .Where(a => a.AccountId == accountId && a.ShopId == shopId)
                                        .Select(x => x.RateNumber).FirstOrDefaultAsync();
                return score;
            }
            catch (Exception ex)
            {
                throw new Exception("Error");
            }
        }

        public async Task<Rating> RatingByUser(Rating request)
        {
            try
            {
                var checkBooking = _context.Bookings.Where(c => c.AccountId == request.AccountId && c.ShopId == request.ShopId).FirstOrDefault();
                if (checkBooking != null)
                {
                    var checkUser = GetRatingByUser(request.AccountId, request.ShopId);
                    if (checkUser == null)
                    {
                        _context.Ratings.Add(request);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        Rating rate = _context.Ratings.Where(c => c.AccountId == request.AccountId && c.ShopId == request.ShopId).FirstOrDefault();
                        rate.RateNumber = request.RateNumber;
                        rate.ShopId = request.ShopId;
                        rate.AccountId = request.AccountId;
                        rate.Status = true;
                        rate.RateId = request.RateId;
                        _context.Ratings.Update(rate);
                        await _context.SaveChangesAsync();
                    }
                }
                return request;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> GetRatingID(int? accountId, int? shopId)
        {
            try
            {
                return await _context.Ratings
                    .Where(a => a.AccountId == accountId && a.ShopId == shopId)
                    .Select(x => x.RateId)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error");
            }
        }
    }
}