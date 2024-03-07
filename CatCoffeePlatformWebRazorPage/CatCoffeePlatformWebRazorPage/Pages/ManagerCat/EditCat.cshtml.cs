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

namespace CatCoffeePlatformWebRazorPage.Pages.ManagerCat
{
    public class EditModel : PageModel
    {
        private readonly ICatRepository _catRepository;
        private readonly ICatTypeRepository _catTypeRepository;
        private readonly IShopCoffeeCatRepository _shopCoffeeCatRepository;
        public EditModel(ICatRepository catRepository, ICatTypeRepository catTypeRepository,
                        IShopCoffeeCatRepository shopCoffeeCatRepository)
        {
            _catRepository = catRepository;
            _catTypeRepository = catTypeRepository;
            _shopCoffeeCatRepository = shopCoffeeCatRepository;
        }

        [BindProperty]
        public Cat Cat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _catRepository.GetCatById(id);
            var catType = await _catTypeRepository.GetCatAllTypes();
            var shop = _shopCoffeeCatRepository.GetAll();
            if (cat == null)
            {
                return NotFound();
            }
            Cat = cat;
           ViewData["CatTypeId"] = new SelectList(catType, "CatTypeId", "CatTypeName");
           ViewData["ShopId"] = new SelectList(shop, "ShopId", "ShopName");
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
                    Cat cat = await _catRepository.GetCatById(id);
                    cat.CatTypeId = int.Parse(Request.Form["catTypeId"]);
                    cat.ShopId = int.Parse(Request.Form["shopID"]);
                    cat.CatName = Request.Form["catName"];
                    cat.ImageCat = Request.Form["image"];
                    cat.Status = bool.Parse(Request.Form["status"]);
                    await _catRepository.UpdateCat(cat);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception("Somethings wrong");
            }

            return Redirect("/ManagerCat/ListCat");
        }
    }
}
