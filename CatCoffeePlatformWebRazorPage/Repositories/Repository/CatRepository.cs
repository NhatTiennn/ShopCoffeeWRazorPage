using BusinessObject.DTO;
using BusinessObject.Models;
using DataAccess;
using Repositories.IRepository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class CatRepository : ICatRepository
    {
        public async Task<Cat> CreateCat(Cat cat)
        {
            return await CatDAO.Instance.CreateCat(cat);
        }

        public async Task<Cat> DeleteCat(int? id)
        {
            return await CatDAO.Instance.DeleteCat(id);
        }

        public async Task<IList<Cat>> GetAllCats()
        {
            return await CatDAO.Instance.GetAllCats();
        }

        public async Task<Cat> GetCatById(int? id)
        {
            return await CatDAO.Instance.GetCatById(id);
        }

        public async Task<Cat> UpdateCat(Cat cat)
        {
            return await CatDAO.Instance.UpdateCat(cat);
        }

        public async Task<IList<Cat>> SearchCatByName(string name)
        {
            return await CatDAO.Instance.SearchCatByName(name);
        }

        public async Task<IList<CatInformation>> CatInformation()
        {
            return await CatDAO.Instance.CatInformation();
        }

        public async Task<CatInformation> GetCatInforById(int? id)
        {
            return await CatDAO.Instance.GetCatInforById(id);
        }
    }
}
