using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
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
        public Area GetByAccountId(int accountId)
        {
            return _context.Areas.SingleOrDefault(p => p.AccountId == accountId);
        }

        public List<Area> GetByShopId(int id)
        {
            return _context.Areas.Where(p => p.ShopId == id).ToList();
        }

        public List<Area> GetAll()
        {
            return _context.Areas.ToList();
        }

        public Area GetById(int id)
        {
            return _context.Areas.FirstOrDefault(c => c.AreaId == id && c.Status == true);
        }

        public Area GetByName(string name)
        {
            return _context.Areas.FirstOrDefault(c => c.AreaName.Equals(name));
        }

        public void Update(Area area)
        {
            _context.Entry(area).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Create(Area area)
        {
            _context.Areas.Add(area);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var area = GetById(id);
            if (area != null)
            {
                _context.Areas.Remove(area);
                _context.SaveChanges();
            }
        }
    }
}
