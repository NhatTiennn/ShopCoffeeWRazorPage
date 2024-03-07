using BusinessObject.DTO;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CatDAO
    {
        private CatCoffeePlatformContext _context = new CatCoffeePlatformContext();
        private static CatDAO instance;
        private static readonly object instanceLock = new object();
        private CatDAO() { }
        public static CatDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CatDAO();
                    }
                }
                return instance;
            }
        }

        public async Task<IList<Cat>> GetAllCats()
        {
            IList<Cat> list = null;
            try
            {
                list = await _context.Cats.ToListAsync();
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

        public async Task<Cat> CreateCat(Cat cat)
        {
            Cat creCat = new Cat
            {
                CatName = cat.CatName,
                CatTypeId = cat.CatTypeId,
                ImageCat = cat.ImageCat,
                ShopId = cat.ShopId,
                Status = cat.Status
            };
            _context.Cats.Add(creCat);
            await _context.SaveChangesAsync();

            return null;
        }

        public async Task<Cat> GetCatById(int? id)
        {
            Cat cat = null;
            try
            {
                cat = await _context.Cats.SingleOrDefaultAsync(cat => cat.CatId == id);
                if (cat == null)
                {
                    throw new Exception("The cat can't found");
                }
                else
                {
                    return cat;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("The cat can't found");
            }
        }

        public async Task<Cat> DeleteCatById(int id)
        {
            Cat cat = await _context.Cats.SingleOrDefaultAsync(c => c.CatId == id);
            if (cat == null)
            {
                throw new Exception("The cat can't found");
            }
            else
            {
                _context.Remove(cat);
                _context.SaveChangesAsync();
            }
            return cat;
        }

        public async Task<Cat> UpdateCat(Cat cat)
        {
            try
            {
                Cat getCat = await GetCatById(cat.CatId);
                if (getCat == null)
                {
                    throw new Exception("The cat can't found");
                } else {
                    Cat updCat = new Cat
                    {
                        CatTypeId = getCat.CatTypeId,
                        CatName = getCat.CatName,
                        CatType = getCat.CatType,
                        ImageCat = getCat.ImageCat,
                        Status = getCat.Status,
                        ShopId = getCat.ShopId
                    };
                    await _context.SaveChangesAsync();
                    return updCat;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Have a problem with Update Cat");
            }
        }

        public async Task<Cat> DeleteCat(int? id)
        {
            try
            {
                Cat getCat = await GetCatById(id);
                if (getCat == null)
                {
                    throw new Exception("The cat can't found");
                }
                else
                {
                   _context.Remove(getCat);
                   await _context.SaveChangesAsync();
                    return null;
                }
            }catch (Exception ex)
            {
                throw new Exception("Have a problem with Delete Cat");
            }
        }

        public async Task<IList<Cat>> SearchCatByName(string keyword)
        {
            try { 
                IList<Cat> listSearchCat = null;
                listSearchCat = await _context.Cats.Where(name => name.CatName.Contains(keyword)).ToListAsync();
                if(listSearchCat == null)
                {
                    throw new Exception("No found");
                }else
                {
                    return listSearchCat;
                }
            }
            catch
            {
                throw new Exception("Have somethings wrong when search cat");
            }
        }

        public async Task<IList<CatInformation>> CatInformation ()
        {
            try{
                IList<CatInformation> listCatInformation = null;
                listCatInformation = await (from a in _context.Cats.AsNoTracking() join b in _context.CatTypes.AsNoTracking() on a.CatTypeId equals b.CatTypeId
                                      join c in _context.ShopCoffeeCats.AsNoTracking() on a.ShopId equals c.ShopId
                                      select new CatInformation
                                      {
                                          CatId = a.CatId,
                                          CatName = a.CatName,
                                          CatType = a.CatType,
                                          ImageCat = a.ImageCat,
                                          CatTypeName = b.CatTypeName,
                                          ShopName = c.ShopName,
                                          Status = c.Status
                                      }).ToListAsync();
                return listCatInformation;
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<CatInformation> GetCatInforById(int? id)
        {
            try{
                CatInformation catInfor = null;
                catInfor = await (from a in _context.Cats.AsNoTracking() join b in _context.CatTypes.AsNoTracking() on a.CatTypeId equals b.CatTypeId
                                      join c in _context.ShopCoffeeCats.AsNoTracking() on a.ShopId equals c.ShopId

                                      select new CatInformation
                                      {
                                          CatId = a.CatId,
                                          CatName = a.CatName,
                                          CatType = a.CatType,
                                          ImageCat = a.ImageCat,
                                          CatTypeName = b.CatTypeName,
                                          ShopName = c.ShopName
                                      }).FirstOrDefaultAsync(a => a.CatId == id);
                return catInfor;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
