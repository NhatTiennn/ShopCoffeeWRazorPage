using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CatTypeDAO
    {
        private CatCoffeePlatformContext _context = new CatCoffeePlatformContext();
        private static CatTypeDAO instance;
        private static readonly object instanceLock = new object();
        private CatTypeDAO() { }
        public static CatTypeDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CatTypeDAO();
                    }
                }
                return instance;
            }
        }
        public List<CatType> GetAll()
        {
            var catType = _context.CatTypes.ToList();
            return catType;
        }
        public async Task<IList<CatType>> GetCatTypeAll()
        {
            try
            {
                IList<CatType> catTypes = null;
                catTypes = await _context.CatTypes.ToListAsync();
                return catTypes;
            }
            catch (Exception ex)
            {
                throw new Exception("Have a problem when get all cat type");
            }
        }

        public async Task<CatType> CreateTypeCat(CatType catType)
        {
            try
            {
                CatType creCatType = null;
                creCatType = new CatType
                {
                    CatTypeName = catType.CatTypeName,
                    Status = catType.Status
                };
                _context.CatTypes.Add(creCatType);
                _context.SaveChangesAsync();
                return creCatType;
            }
            catch (Exception ex)
            {
                throw new Exception("Create cat type failed");
            }
        }

        public async Task<CatType> GetCatTypeById(int id)
        {
            try
            {
                var checkCatType = await _context.CatTypes.FirstOrDefaultAsync(type => type.CatTypeId == id);
                if (checkCatType != null)
                {
                    return checkCatType;
                }
                else
                {
                    throw new Exception("The type cat type not found");
                }
            }
            catch
            {
                throw new Exception("Have somethings problem when find the cat Type");
            }
        }

        public async Task<CatType> DeleteCatTypeById(int id)
        {
            try
            {
                CatType checkCatType = await GetCatTypeById(id);
                if (checkCatType != null)
                {
                    _context.CatTypes.Remove(checkCatType);
                }
                else
                {
                    throw new Exception("The type cat type not found");
                }
                return checkCatType;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CatType> UpdateCatTypeById(CatType cat)
        {
            try
            {
                var checkCatType = await GetCatTypeById(cat.CatTypeId);
                if (checkCatType != null)
                {
                    checkCatType = cat;
                    _context.Entry(checkCatType).State = EntityState.Modified;
                    return checkCatType;
                }
                else
                {
                    throw new Exception("The type cat type not found");
                }
            }
            catch
            {
                throw new Exception("Have a problem when updated");
            }
        }

        public async Task<IList<CatType>> SearchCatType(string name)
        {
            try
            {
                IList<CatType> catType = await _context.CatTypes.Where(x => x.CatTypeName.Contains(name)).ToListAsync();
                if (catType != null)
                {
                    return catType;
                }
                else
                {
                    throw new Exception("Not found");
                }
            }
            catch
            {
                throw new Exception("Have somethins wrong when search cat type");
            }
        }
    }
}
