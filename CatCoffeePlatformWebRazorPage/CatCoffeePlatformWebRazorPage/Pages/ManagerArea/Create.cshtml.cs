using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Models;
using Repositories.IRepository;
using Microsoft.Identity.Client;
using Repositories.Repository;
using BusinessObject.DTO;

namespace CatCoffeePlatformWebRazorPage.Pages.ManagerArea
{
    public class CreateModel : PageModel
    {
        private readonly IAreaRepository _areaRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IShopCoffeeCatRepository _shopCoffeeCatRepository;

        public CreateModel(IAreaRepository areaRepository, IAccountRepository accountRepository, IShopCoffeeCatRepository shopCoffeeCatRepository)
        {
            _areaRepository = areaRepository;
            _accountRepository = accountRepository;
            _shopCoffeeCatRepository = shopCoffeeCatRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            var email = await _accountRepository.GetAccountsByRoleId(2);
            var shopId = _shopCoffeeCatRepository.GetAll();
            ViewData["AccountId"] = new SelectList(email, "AccountId", "Email");
            ViewData["ShopId"] = new SelectList(shopId, "ShopId", "ShopName");

            // Get current account Login
            return Page();
        }

        [BindProperty]
        public Area Area { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Page();
                }

                bool isAreaNameExist = await _areaRepository.IsAreaNameExist(Area.AreaName,Area.ShopId, Area.AreaId);
                if (isAreaNameExist)
                {
                    ModelState.AddModelError("Area.AreaName", "Area name already exists.");
                    await OnGet();
                    return Page();
                }

                await _areaRepository.Create(Area);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToPage("/ManagerArea/Index");
        }
    }
}
