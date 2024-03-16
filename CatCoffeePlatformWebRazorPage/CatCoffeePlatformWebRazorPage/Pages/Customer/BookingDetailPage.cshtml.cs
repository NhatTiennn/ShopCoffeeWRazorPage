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
    public class BookingDetailPageModel : PageModel
    {
        private readonly IBookingRepository bookingRepository;
        private readonly IAccountRepository accountRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IBookingDetailRepository bookingDetailRepository;

        public BookingDetailPageModel(IBookingDetailRepository bookingDetailRepository, IBookingRepository bookingRepository,
            IAccountRepository accountRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.bookingRepository = bookingRepository;
            this.accountRepository = accountRepository;
            this.httpContextAccessor = httpContextAccessor;
            this.bookingDetailRepository = bookingDetailRepository;
            customer = new Account();

        }

        public IList<BookingDetail> BookingDetail { get;set; } = default!;
        public IList<BookingDetail> BookingDetailDrink{ get; set; } = default!;

        public IList<BookingDetail> BookingDetailFood { get; set; } = default!;

        public Booking Booking { get; set; } = default!;

        public Account customer { get; set; }

        public async Task<PageResult> OnGetAsync(int? id)
        {
            int? accountId = httpContextAccessor.HttpContext.Session.GetInt32("AccountId");
            customer = await accountRepository.GetById(accountId);
            Booking = await bookingRepository.GetBookingByBookingId((int)id);
            BookingDetailDrink = await bookingDetailRepository.GetAllBookingDetailDrinkByBookingId((int)id);
            BookingDetailFood = await bookingDetailRepository.GetAllBookingDetailFoodByBookingId((int)id);
            return Page();
        }
    }
}
