using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Models;
using Repositories.IRepository;
using Repositories.Repository;
using BusinessObject.DTO;

namespace CatCoffeePlatformWebRazorPage.Pages.ManagerCat
{
    public class CreateModel : PageModel
    {
        private readonly ICatRepository _catRepository;
        private readonly ICatTypeRepository _catTypeRepository;
        private readonly IShopCoffeeCatRepository _shopCoffeeCatRepository;

        public CreateModel(ICatRepository catRepository, ICatTypeRepository catTypeRepository, IShopCoffeeCatRepository shopCoffeeCatRepository)
        {
            _catRepository = catRepository;
            _catTypeRepository = catTypeRepository;
            _shopCoffeeCatRepository = shopCoffeeCatRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            var catType = await _catTypeRepository.GetCatAllTypes();
            var shop = _shopCoffeeCatRepository.GetAll();
            ViewData["CatTypeId"] = new SelectList(catType, "CatTypeId", "CatTypeName");
            ViewData["ShopId"] = new SelectList(shop, "ShopId", "ShopName");
            return Page();
        }

        [BindProperty]
        public CatInformation Cat { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (ModelState.IsValid)
            {
                return Page();
            }

          await _catRepository.CreateCat(Cat);
          return Redirect("/ManagerCat/ListCat");
        }
    }
}
