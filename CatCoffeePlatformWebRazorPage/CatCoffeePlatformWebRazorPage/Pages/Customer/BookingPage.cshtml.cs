using BusinessObject.DTO;
using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories.IRepository;
using Repositories.Repository;
using System.IO;
using System.Xml.Schema;

namespace CatCoffeePlatformWebRazorPage.Pages.Customer
{
    public class BookingPageModel : PageModel
    {
        private readonly IDrinkRepository drinkRepository;
        private readonly IBookingDetailRepository bookingDetailRepository;
        private readonly IAccountRepository accountRepository;
        private readonly ITableRepository tableRepository;
        private readonly IAreaRepository areaRepository;
        private readonly ISlotBookingRepository slotBookingRepository;
        private readonly IBookingRepository bookingRepository;
        private readonly IFoodOfCatRepository foodOfCatRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public BookingPageModel(ITableRepository tableRepository, IAreaRepository areaRepository,
            ISlotBookingRepository slotBookingRepository, IHttpContextAccessor httpContextAccessor,
            IAccountRepository accountRepository,IDrinkRepository drinkRepository,
            IFoodOfCatRepository foodOfCatRepository,IBookingRepository bookingRepository,
            IBookingDetailRepository bookingDetailRepository)
        {
            this.drinkRepository = drinkRepository;
            this.bookingDetailRepository = bookingDetailRepository;
            this.accountRepository = accountRepository;
            this.tableRepository = tableRepository;
            this.areaRepository = areaRepository;
            this.slotBookingRepository = slotBookingRepository;
            this.bookingRepository = bookingRepository;
            this.foodOfCatRepository = foodOfCatRepository;
            this.httpContextAccessor = httpContextAccessor;
            customer = new Account();
        }
        [BindProperty]
        public string AreaName { get; set; } = default!;
        [BindProperty]
        public string TableName { get; set; } = default!;
        [BindProperty]
        public string StartEndTime { get; set; } = default!;
        [BindProperty]
        public string BookingDate { get; set; } = default!;

        [BindProperty]
        public List<Area> Area { get; set; } = default!;
        public Account customer { get; set; }
        [BindProperty]
        public List<FoodCatInfor> foodForCats { get; set; }
        [BindProperty]
        public List<DinkInfor> drinks { get; set; }


        public async Task<IActionResult> OnGet(int? id)
        {
            int? accountId = httpContextAccessor.HttpContext.Session.GetInt32("AccountId");
            customer = await accountRepository.GetById(accountId);
            if (customer == null) {
                return Page();
            }
            ViewData["TableName"] = new SelectList(tableRepository.GetByShopId(id.Value), "TableName", "TableName");
            ViewData["AreaName"] = new SelectList(areaRepository.GetByShopId(id.Value), "AreaName", "AreaName");
            ViewData["StartEndTime"] = new SelectList(slotBookingRepository.GetByShopId(id.Value), "StartEndTime", "StartEndTime");
            Area = areaRepository.GetByShopId(id.Value);
            foodForCats = foodOfCatRepository.GetAllByShopId(id.Value);
            drinks = drinkRepository.GetAllByShopId(id.Value);
            return Page();
        }



        public async Task<IActionResult> OnPost(int? id)
        {
            DateTime current = DateTime.Now;
            if (DateTime.Parse(BookingDate).Year < current.Year)
            {
                return Page();
            }
            if (DateTime.Parse(BookingDate).Month < current.Month)
            {
                return Page();
            }
            if (DateTime.Parse(BookingDate).Month == current.Month &&DateTime.Parse(BookingDate).Day < current.Day)
            {
                return Page();
            }
            string[] slotTime = StartEndTime.Split("-");
            string startTime = slotTime[0];
            int? accountId = HttpContext.Session.GetInt32("AccountId");
            customer = await accountRepository.GetById(accountId);
            if (customer == null)
            {
                ViewData["TableName"] = new SelectList(tableRepository.GetByShopId(id.Value), "TableName", "TableName");
                ViewData["AreaName"] = new SelectList(areaRepository.GetByShopId(id.Value), "AreaName", "AreaName");
                ViewData["StartEndTime"] = new SelectList(slotBookingRepository.GetByShopId(id.Value), "StartEndTime", "StartEndTime");
                Area = areaRepository.GetByShopId(id.Value);
                foodForCats = foodOfCatRepository.GetAllByShopId(id.Value);
                drinks = drinkRepository.GetAllByShopId(id.Value);
                return Page();
            }
            SlotBooking slot = slotBookingRepository.GetShopByStartTime(startTime, id.Value);
            Table table = tableRepository.GetByTableName(TableName, id.Value);
            var booking = new Booking
            {
                BookingDate = DateTime.Parse(BookingDate),
                ShopId = id.Value,
                Total = slot.Price,
                AccountId = accountId.Value,
                TableId = table.TableId,
                SlotId = slot.SlotId,
                Status = true
            };
            var bookingExist = bookingRepository.CheckBookingExist(booking);
            var areaExist = areaRepository.CheckAreaEixst(AreaName, id.Value, accountId.Value);
            if (bookingExist != null && areaExist != null)
            {
                return Page();
            }
             bookingRepository.Create(booking);

            int bookingId = bookingRepository.CheckBookingExist(booking).BookingId;
            if (bookingId != 0)
            {
                int count = 0;
                if (foodForCats.Count > drinks.Count)
                    count = foodForCats.Count;
                else count = drinks.Count;
                for (int i = 0; i < count; i++)
                {
                    var bookingDetail = new BookingDetail
                    {
                        BookingId = bookingId
                    };
                    var check = false;
                    if (i < drinks.Count)
                    {
                        if (drinks[i].numberOfDrink > 0)
                        {
                            bookingDetail.DrinkId = drinks[i].DrinkId;
                            bookingDetail.NumberOfDrink = drinks[i].numberOfDrink;
                            bookingDetail.TotalPriceDrink = drinks[i].numberOfDrink * drinks[i].Price;
                            check = true;
                        }

                    }
                    if (i < foodForCats.Count)
                    {
                        if (foodForCats[i].numberOfFood > 0)
                        {
                            bookingDetail.FoodCatId = foodForCats[i].FoodCatId;
                            bookingDetail.NumberOfFoodCat = foodForCats[i].numberOfFood;
                            bookingDetail.TotalPriceFood = foodForCats[i].FoodPrice * foodForCats[i].numberOfFood;
                            check = true;
                        }
                    }
                    if (check)
                    {
                        bookingDetailRepository.Create(bookingDetail);
                    }

                }
                double drinkToTal = await bookingDetailRepository.GetSumDrinkByBookingIdAsync(bookingId);
                double foodTotal = await bookingDetailRepository.GetSumFoodByBookingIdAsync(bookingId);
                var book = bookingRepository.GetBookingId(bookingId);
                book.Total = book.Total + foodTotal + drinkToTal;
                bookingRepository.Update(book);
                return Redirect("https://localhost:7125");
            }
            ViewData["TableName"] = new SelectList(tableRepository.GetByShopId(id.Value), "TableName", "TableName");
            ViewData["AreaName"] = new SelectList(areaRepository.GetByShopId(id.Value), "AreaName", "AreaName");
            ViewData["StartEndTime"] = new SelectList(slotBookingRepository.GetByShopId(id.Value), "StartEndTime", "StartEndTime");
            Area = areaRepository.GetByShopId(id.Value);
            foodForCats = foodOfCatRepository.GetAllByShopId(id.Value);
            drinks = drinkRepository.GetAllByShopId(id.Value);
            return Page();
        }
    }
}
