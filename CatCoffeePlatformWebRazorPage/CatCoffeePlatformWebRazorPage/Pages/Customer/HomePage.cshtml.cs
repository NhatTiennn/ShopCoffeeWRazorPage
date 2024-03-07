using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using Repositories.IRepository;

namespace CatCoffeePlatformWebRazorPage.Pages.Customer
{
    public class HomePageModel : PageModel
    {
        private readonly IShopCoffeeCatRepository shopCoffeeCatRepository;
        private readonly IAccountRepository accountRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public HomePageModel(IShopCoffeeCatRepository shopCoffeeCatRepository, IAccountRepository accountRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.shopCoffeeCatRepository = shopCoffeeCatRepository;
            this.accountRepository = accountRepository;
            this.httpContextAccessor = httpContextAccessor;
            customer = new Account();
        }

        public IList<ShopCoffeeCat> ShopCoffeeCat { get;set; } = default!;
        public string CatTypeName { get; set; }

        public Account customer { get; set; }


        public IActionResult OnGetAsync()
        {
            int? accountId = httpContextAccessor.HttpContext.Session.GetInt32("AccountId");
            customer = accountRepository.GetById(accountId);
            if (!string.IsNullOrEmpty(CatTypeName))
            {
            return  RedirectToPage("/Customer/SearchShop", new { catTypeName = CatTypeName });
            }
            
            ShopCoffeeCat = shopCoffeeCatRepository.GetAll();
            return Page();
        }
    }
}
