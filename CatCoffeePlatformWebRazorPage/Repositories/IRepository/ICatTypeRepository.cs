using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface ICatTypeRepository
    {
        List<CatType> GetAll();

        Task<IList<CatType>> GetCatAllTypes();

        Task<IList<CatType>> SearchCatTypeByName(string name);

        Task<CatType> UpdateCatType(CatType catType);

        Task<CatType> DeleteCatTypeById(int id);

        Task<CatType> CreateCatType(CatType catType);

        Task<CatType> GetCatTypeById(int id);
    }
}
