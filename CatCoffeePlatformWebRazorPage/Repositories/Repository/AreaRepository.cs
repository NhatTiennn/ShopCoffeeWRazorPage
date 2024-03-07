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
    public class AreaRepository : IAreaRepository
    {
        public void Create(Area area)
        {
            AreaDAO.Instance.Create(area);
        }

        public void DeleteById(int id)
        {
            AreaDAO.Instance.DeleteById(id);
        }

        public List<Area> GetAll()
        {
            return AreaDAO.Instance.GetAll();
        }

        public List<Area> GetByShopId(int id)
        { 
            return AreaDAO.Instance.GetByShopId(id);
        }
        public Area GetByAccountId(int accountId)
        {
            return AreaDAO.Instance.GetByAccountId(accountId);
        }

        public Area GetById(int id)
        {
            return AreaDAO.Instance.GetById(id);
        }

        public Area GetByName(string name)
        {
            return AreaDAO.Instance.GetByName(name);
        }

        public void Update(Area area)
        {
            AreaDAO.Instance.Update(area);    
        }
    }
}
