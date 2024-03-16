using Azure;
using BusinessObject.DTO;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AreaDAO
    {
        private CatCoffeePlatformContext _context = new CatCoffeePlatformContext();
        private static AreaDAO instance;
        private static readonly object instanceLock = new object();
        private readonly AccountDAO _accountDAO = AccountDAO.Instance; // or however you initialize it
        private AreaDAO() { }
        public static AreaDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AreaDAO();
                    }
                }
                return instance;
            }
        }
        //public Area GetByAccountId(int accountId)
        //{
        //    return _context.Areas.SingleOrDefault(p => p.AccountId == accountId);
        //}

        public List<Area> GetByShopId(int id)
        {
            return _context.Areas.Where(p => p.ShopId == id).ToList();
        }

        public async Task<IList<Area>> GetAll()
        {
            IList<Area> list = null;
            try
            {
                list = await _context.Areas.ToListAsync();
                if (list.Count == 0)
                {
                    return list;
                }
                else
                {
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("List is have a problem");
            }
        }

        public async Task<Area> GetById(int? id)
        {
            //return _context.Areas.FirstOrDefault(c => c.AreaId == id && c.Status == true);

            Area area = null;
            try
            {
                area = await _context.Areas.SingleOrDefaultAsync(area => area.AreaId == id);
                if (area == null)
                {
                    throw new Exception("The area can't found");
                }
                else
                {
                    return area;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("The area can't found");
            }
        }

        public async Task<Area> GetShopIdByAccountId(int? accountId)
        {
            try
            {
                var area = await _context.Areas.FirstOrDefaultAsync(area => area.AccountId == 2);
                if (area == null)
                {
                    throw new Exception("The area can't found by " + accountId.Value);
                }
                return area;

            }
            catch (Exception ex)
            {
                throw new Exception("The area can't found " + accountId.Value);
            }
        }

        public async Task<Area> Create(Area area)
        {
            try
            {
                Area creArea = new Area
                {
                    AreaName = area.AreaName,
                    ShopId = area.ShopId,
                    AccountId = area.AccountId,
                    Status = area.Status
                };
                //var shopId = _accountDAO.GetById(creArea.AccountId);
                //creArea.ShopId = (int)shopId.ShopId;

                //Console.WriteLine(creArea);
                _context.Areas.Add(creArea);
                await _context.SaveChangesAsync();

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        public async Task<IList<Area>> SearchAreaByName(string keyword)
        {
            try
            {
                IList<Area> listSearchArea = null;
                listSearchArea = await _context.Areas.Where(name => name.AreaName.Contains(keyword)).ToListAsync();
                if (listSearchArea == null)
                {
                    throw new Exception("No found");
                }
                else
                {
                    return listSearchArea;
                }
            }
            catch
            {
                throw new Exception("Have somethings wrong when search area");
            }
        }

        //public async Task<Area> Update(Area area)
        //{
        //    try
        //    {
        //        Area getArea = await GetById(area.AreaId);
        //        if (getArea == null)
        //        {
        //            throw new Exception("The area can't found");
        //        }
        //        else
        //        {
        //            Area updArea = new Area
        //            {
        //                AreaId = getArea.AreaId,
        //                AreaName = getArea.AreaName,
        //                ShopId = getArea.ShopId,
        //                AccountId = getArea.AccountId,
        //                Status = getArea.Status
        //            };
        //            await _context.SaveChangesAsync();
        //            return updArea;
        //        }
        //    }
        //    catch
        //    {
        //        throw new Exception("Have a problem with Update Area");
        //    }
        //}

        public async Task<Area> Update(Area area)
        {
            try
            {
                Area getArea = await GetById(area.AreaId);

                if (getArea == null)
                {
                    throw new Exception("The area can't be found.");
                }
                else
                {
                    Area updArea = new Area
                    {
                        AreaName = getArea.AreaName,
                        ShopId = getArea.ShopId,
                        AccountId = getArea.AccountId,
                        Status = getArea.Status
                    };

                    await _context.SaveChangesAsync();
                    return updArea;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the area.", ex);
            }
        }

        public async Task<bool> IsAreaNameExist(string areaName, int shopId, int areaId)
        {
            bool isExist = await _context.Areas.AnyAsync(a => a.ShopId == shopId && a.AreaName == areaName && a.AreaId != areaId);
            return isExist;
        }


        public async Task<Area> DeleteById(int? id)
        {
            try
            {
                Area getArea = await _context.Areas.SingleOrDefaultAsync(c => c.AreaId == id);
                if (getArea == null)
                {
                    throw new Exception("The area can't found");
                }
                else
                {
                    _context.Remove(getArea);
                    await _context.SaveChangesAsync();
                    return null;
                }
            }
            catch
            {
                throw new Exception("Have a problem with Delete Area");
            }
        }

        public async Task<IList<AreaInformation>> AreaInformation()
        {
            try
            {
                IList<AreaInformation> listAreaInformation = null;
                listAreaInformation = await (from a in _context.Areas.AsNoTracking()
                                             join b in _context.Accounts.AsNoTracking() on a.AccountId equals b.AccountId
                                             join s in _context.ShopCoffeeCats.AsNoTracking() on a.ShopId equals s.ShopId
                                             select new AreaInformation
                                             {
                                                 AreaId = a.AreaId,
                                                 AreaName = a.AreaName,
                                                 AccountId = a.AccountId,
                                                 Email = b.Email,
                                                 ShopName = s.ShopName,
                                                 Status = a.Status
                                             }).ToListAsync();
                return listAreaInformation;
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<AreaInformation> GetAreaInforById(int? id)
        {
            try
            {
                AreaInformation catInfor = null;
                catInfor = await (from a in _context.Areas.AsNoTracking()
                                  join b in _context.Accounts.AsNoTracking() on a.AccountId equals b.AccountId
                                  join c in _context.ShopCoffeeCats.AsNoTracking() on a.ShopId equals c.ShopId

                                  select new AreaInformation
                                  {
                                      AreaId = a.AreaId,
                                      AreaName = a.AreaName,
                                      Account = a.Account,
                                  }).FirstOrDefaultAsync(a => a.AreaId == id);
                return catInfor;
            }
            catch
            {
                throw new Exception();
            }
        }
        public Area CheckAreaEixst(string AreaName, int shopId, int accountId)
        {
            return _context.Areas.SingleOrDefault(p => p.AreaName.Equals(AreaName) && p.ShopId == shopId && p.AccountId == accountId);
        }
    }
}
