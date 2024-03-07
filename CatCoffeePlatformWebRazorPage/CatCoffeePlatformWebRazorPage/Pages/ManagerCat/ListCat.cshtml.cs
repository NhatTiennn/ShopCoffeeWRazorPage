using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using Repositories.IRepository;
using Repositories.Repository;
using BusinessObject.DTO;

namespace CatCoffeePlatformWebRazorPage.Pages.ManagerCat
{
    public class ListCat : PageModel
    {
        private readonly ICatRepository _catRepository;
        private readonly IShopCoffeeCatRepository _shopCoffeeCatRepository;
        private readonly ICatTypeRepository _catTypeRepository;
        public ListCat(ICatRepository catRepository, IShopCoffeeCatRepository shopCoffeeCatRepository,
                        ICatTypeRepository catTypeRepository)
        {
            _catRepository = catRepository;
            _shopCoffeeCatRepository = shopCoffeeCatRepository;
            _catTypeRepository = catTypeRepository;
        }

        public IList<CatInformation> Cat { get;set; }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                Cat = await _catRepository.CatInformation();
                if(Cat == null)
                {
                    return Page();
                }else
                {
                    return Page();
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}
