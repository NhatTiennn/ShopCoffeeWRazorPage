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
        public Area GetByAccountId(int accountId);
        public List<Area> GetAll();
        public Area GetById(int id);
        public Area GetByName(string name);
        public List<Area> GetByShopId(int id);
        public void Update(Area area);
        public void DeleteById(int id);
        public void Create(Area area);
    }
}
