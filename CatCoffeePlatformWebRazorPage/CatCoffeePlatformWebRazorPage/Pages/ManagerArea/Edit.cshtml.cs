using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using Repositories.IRepository;
using Microsoft.Identity.Client;

namespace CatCoffeePlatformWebRazorPage.Pages.ManagerArea
{
    public class EditModel : PageModel
    {
        private readonly IAreaRepository _areaRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IShopCoffeeCatRepository _shopCoffeeCatRepository;
        public EditModel(IAreaRepository areaRepository, IAccountRepository accountRepository, IShopCoffeeCatRepository shopCoffeeCatRepository)
        {
            _areaRepository = areaRepository;
            _accountRepository = accountRepository;
            _shopCoffeeCatRepository = shopCoffeeCatRepository;
        }

        [BindProperty]
        public Area Area { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var area = await _areaRepository.GetById(id);
            var account = await _accountRepository.GetAccountsByRoleId(2);
            var shopId = _shopCoffeeCatRepository.GetAll();

            if (area == null)
            {
                return NotFound();
            }
            Area = area;
            Area.Status = area.Status;
            Console.WriteLine(area.Status);
            ViewData["AccountId"] = new SelectList(account, "AccountId", "Email");
            ViewData["ShopId"] = new SelectList(shopId, "ShopId", "ShopName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                Area area = await _areaRepository.GetById(id);
                if (int.TryParse(Request.Form["Area.AccountId"], out int accountId))
                {
                    area.AccountId = accountId;
                }
                else
                {
                    throw new Exception("Invalid AccountId");
                }

                ShopCoffeeCat shop = _shopCoffeeCatRepository.GetById(Area.ShopId);

                bool isAreaNameExist = await _areaRepository.IsAreaNameExist(Area.AreaName, Area.ShopId, Area.AreaId);
                if (isAreaNameExist)
                {
                    ModelState.AddModelError("", "[ "+ Area.AreaName +" ] already exists in [ " + shop.ShopName + " ]");
                    await OnGetAsync(id);
                    return Page();
                }

                area.AreaName = Request.Form["Area.AreaName"];

                area.ShopId = int.Parse(Request.Form["Area.ShopId"]);

                try
                {
                    area.Status = bool.Parse(Request.Form["status"]);
                }
                catch
                {
                    area.Status = bool.Parse(Request.Form["Area.Status"]);
                }

                await _areaRepository.Update(area);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception("Something's wrong");
            }

            return Redirect("/ManagerArea/Index");

        }

        //private bool AreaExists(int id)
        //{
        //    return (_areaRepository.Any(e => e.AreaId == id)).GetValueOrDefault();
        //}
    }
}
