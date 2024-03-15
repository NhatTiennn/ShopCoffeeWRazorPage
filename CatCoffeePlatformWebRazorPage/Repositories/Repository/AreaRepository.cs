using BusinessObject.DTO;
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
        public async Task<Area> Create(Area area)
        {
            return await AreaDAO.Instance.Create(area);
        }

        public async Task<Area> DeleteById(int? id)
        {
            return await AreaDAO.Instance.DeleteById(id);
        }

        public async Task<IList<Area>> GetAll()
        {
            return await AreaDAO.Instance.GetAll();
        }

        public List<Area> GetByShopId(int id)
        { 
            return AreaDAO.Instance.GetByShopId(id);
        }
        public async Task<Area> GetByAccountId(int accountId)
        //public Area GetByAccountId(int accountId)
        {
            return await AreaDAO.Instance.GetShopIdByAccountId(accountId);
            //return  AreaDAO.Instance.GetByAccountId(accountId);
        }

        public async Task<Area> GetById(int? id)
        {
            return await AreaDAO.Instance.GetById(id);
        }

        public async Task<IList<Area>> SearchAreaByName(string name)
        {
            return await AreaDAO.Instance.SearchAreaByName(name);
        }

        public async Task<Area> Update(Area area)
        {
            return await AreaDAO.Instance.Update(area);    
        }

        public async Task<IList<AreaInformation>> AreaInformation()
        {
            return await AreaDAO.Instance.AreaInformation();
        }

        public async Task<AreaInformation> GetAreaInforById(int? id)
        {
            return await AreaDAO.Instance.GetAreaInforById(id);
        }

        public async Task<bool> IsAreaNameExist(string areaName, int shopId, int areaId)
        {
            return await AreaDAO.Instance.IsAreaNameExist(areaName,  shopId,  areaId);
        }
    }
}
