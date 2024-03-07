using BusinessObject.DTO;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface ICatRepository
    {
        Task<IList<Cat>> GetAllCats();

        Task<Cat> GetCatById(int? id);

        Task<Cat> CreateCat(Cat cat);

        Task<Cat> UpdateCat(Cat cat);

        Task<Cat> DeleteCat(int? id);

        Task<IList<Cat>> SearchCatByName(string name);

        Task<IList<CatInformation>> CatInformation();

        Task<CatInformation> GetCatInforById(int? id);
    }
}
