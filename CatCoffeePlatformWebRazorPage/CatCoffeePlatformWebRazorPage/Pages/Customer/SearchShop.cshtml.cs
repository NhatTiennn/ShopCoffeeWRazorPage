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

namespace CatCoffeePlatformWebRazorPage.Pages.Customer
{
    public class SearchShopModel : PageModel
    {
        private readonly IShopCoffeeCatRepository _shopCoffeeCatRepository;
        private readonly ICatTypeRepository _catTypeRepository;
        private readonly IAccountRepository accountRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SearchShopModel(IShopCoffeeCatRepository shopCoffeeCatRepository, IAccountRepository accountRepository, ICatTypeRepository catTypeRepository, IHttpContextAccessor httpContextAccessor)
        {
            _shopCoffeeCatRepository = shopCoffeeCatRepository;
            this.accountRepository = accountRepository;
            this.httpContextAccessor = httpContextAccessor;
            _catTypeRepository = catTypeRepository;
            customer = new Account();

        }

        public IList<ShopCoffeeCat>? SearchedShops { get; set; }
        public IList<CatType> CatTypes { get; set; }
        public Account customer { get; set; }

        public async Task<IActionResult> OnGet(string catTypeName)
        {
            int? accountId = httpContextAccessor.HttpContext.Session.GetInt32("AccountId");
            customer = await accountRepository.GetById(accountId);
            SearchedShops = _shopCoffeeCatRepository.SearchShops(catTypeName);
           CatTypes = _catTypeRepository.GetAll();
            //return Redirect("/Customer/SearchShop");
            return Page();
        }
    }
}
