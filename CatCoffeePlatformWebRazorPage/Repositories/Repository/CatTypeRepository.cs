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
    public class CatTypeRepository : ICatTypeRepository
    {
        public List<CatType> GetAll()
        {
            return CatTypeDAO.Instance.GetAll();
        }
        public Task<CatType> CreateCatType(CatType catType)
        {
            return CatTypeDAO.Instance.CreateTypeCat(catType);
        }

        public Task<CatType> DeleteCatTypeById(int id)
        {
            return CatTypeDAO.Instance.DeleteCatTypeById(id);
        }

        public async Task<IList<CatType>> GetCatAllTypes()
        {
            return await CatTypeDAO.Instance.GetCatTypeAll();
        }

        public Task<CatType> GetCatTypeById(int id)
        {
            return CatTypeDAO.Instance.GetCatTypeById(id);
        }

        public Task<IList<CatType>> SearchCatTypeById(string name)
        {
            return CatTypeDAO.Instance.SearchCatType(name);
        }

        public Task<IList<CatType>> SearchCatTypeByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<CatType> UpdateCatType(CatType catType)
        {
            return CatTypeDAO.Instance.UpdateCatTypeById(catType);
        }
    }
}
