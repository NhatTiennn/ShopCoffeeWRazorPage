using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Repositories.Repository;

namespace CatCoffeePlatformWebRazorPage.Pages.Customer
{
    public class ShopDetailsModel : PageModel
    {
        private readonly IRatingRepository ratingRepository;
        private readonly IShopCoffeeCatRepository shopCoffeeCatRepository;
        private readonly ICatTypeRepository catTypeRepository;
        private readonly IAccountRepository accountRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ShopDetailsModel(IRatingRepository ratingRepository, IShopCoffeeCatRepository shopCoffeeCatRepository, IAccountRepository accountRepository, ICatTypeRepository catTypeRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.ratingRepository = ratingRepository;
            this.shopCoffeeCatRepository = shopCoffeeCatRepository;
            this.catTypeRepository = catTypeRepository;
            this.accountRepository = accountRepository;
            this.httpContextAccessor = httpContextAccessor;
            customer = new Account();

        }

        public ShopCoffeeCat ShopCoffeeCat { get; set; } = default!;
        public IList<ShopCoffeeCat> Top10Shop { get; set; }

        public IList<Drink> Drinks { get; set; }
        public IList<Cat> Cats { get; set; }

        public IList<CatType> CatTypes { get; set; }
        [BindProperty(SupportsGet = true)]
        public int SelectedCat { get; set; }
        public IList<FoodForCat> FoodForCats { get; set; }
        [BindProperty(SupportsGet = true)]
        public int SelectedFoodForCat { get; set; }

        [BindProperty(SupportsGet = true)]
        public int SelectedDink { get; set; }

        public Account customer { get; set; }

        public int Rating {  get; set; }
        public Rating Rate { get; set; }



        public async Task<IActionResult> OnGetAsync(int? id)
        {
            int? accountId = httpContextAccessor.HttpContext.Session.GetInt32("AccountId");
            customer = accountRepository.GetById(accountId);
            if (id == null)
            {
                return NotFound();
            }

            var shopcoffeecat = shopCoffeeCatRepository.GetById(id);
            var drink = shopCoffeeCatRepository.GetDrinkByShopId((int)id);
            var fdCat = shopCoffeeCatRepository.GetFoodForCatByShopId((int)id);
            var cat = shopCoffeeCatRepository.GetCatByShopId((int)id);
            var catT = catTypeRepository.GetAll();
            var top10Shops = shopCoffeeCatRepository.GetTop10Shops();
            Rating = await ratingRepository.GetRatingAShop(shopcoffeecat.ShopId);
            CustomerRating = await ratingRepository.GetRatingByUser((int)accountId, (int)id);

            if (shopcoffeecat == null)
            {
                return NotFound();
            }
            else 
            {
                ShopCoffeeCat = shopcoffeecat;
                Drinks = drink;
                Cats = cat;
                FoodForCats = fdCat;
                CatTypes = catT;
                Top10Shop = top10Shops;
            }
            return Page();
        }
        [BindProperty(SupportsGet = true)]
        public int CustomerRating { get; set; }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            try
            {
                var shopcoffeecat = shopCoffeeCatRepository.GetById(id);
                int? accountId = httpContextAccessor.HttpContext.Session.GetInt32("AccountId");
                Rating newRating = new Rating
                {
                    RateId = await ratingRepository.GetRatingID((int)accountId, (int)id),
                    AccountId = (int)accountId,
                    ShopId = (int)id,
                    RateNumber = CustomerRating
                };
                Rate = await ratingRepository.RatingByUser(newRating);
                Rating = await ratingRepository.GetRatingAShop(Rate.ShopId);
                var drink = shopCoffeeCatRepository.GetDrinkByShopId((int)id);
                var fdCat = shopCoffeeCatRepository.GetFoodForCatByShopId((int)id);
                var cat = shopCoffeeCatRepository.GetCatByShopId((int)id);
                var catT = catTypeRepository.GetAll();
                var top10Shops = shopCoffeeCatRepository.GetTop10Shops();
                CustomerRating = await ratingRepository.GetRatingByUser((int)accountId,(int)id);
                ShopCoffeeCat = shopcoffeecat;
                Drinks = drink;
                Cats = cat;
                FoodForCats = fdCat;
                CatTypes = catT;
                Top10Shop = top10Shops;
                return Page();
            }
            catch (Exception ex)
            {
                return Page();
            }
        }
    }
}
