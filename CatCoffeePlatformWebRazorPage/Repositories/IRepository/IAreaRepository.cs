using BusinessObject.DTO;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IAreaRepository
    {
        Task<Area> GetByAccountId(int accountId);
        //Area GetByAccountId(int accountId);
        Task<IList<Area>> GetAll();
        Task<Area> GetById(int? id);
        Task<IList<Area>> SearchAreaByName(string name);
        public List<Area> GetByShopId(int id);
        Task<Area> Update(Area area);
        Task<Area> DeleteById(int? id);
        Task<Area> Create(Area area);

        Task<IList<AreaInformation>> AreaInformation();

        Task<AreaInformation> GetAreaInforById(int? id);
        Task<bool> IsAreaNameExist(string areaName, int shopId, int areaId);
        Area CheckAreaEixst(string AreaName, int shopId, int accountId);
    }
}
