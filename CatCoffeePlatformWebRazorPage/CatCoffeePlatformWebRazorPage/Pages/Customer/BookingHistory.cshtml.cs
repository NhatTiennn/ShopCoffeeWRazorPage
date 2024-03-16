using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.IRepository;
using Repositories.Repository;

namespace CatCoffeePlatformWebRazorPage.Pages.Customer
{
    public class BookingHistoryModel : PageModel
    {
        private readonly IBookingDetailRepository bookingDetailRepository;
        private readonly IAccountRepository accountRepository;
        private readonly IBookingRepository bookingRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public BookingHistoryModel(IHttpContextAccessor httpContextAccessor,
            IAccountRepository accountRepository, IBookingRepository bookingRepository,
            IBookingDetailRepository bookingDetailRepository)
        {
            this.bookingDetailRepository = bookingDetailRepository;
            this.accountRepository = accountRepository;
            this.bookingRepository = bookingRepository;
            this.httpContextAccessor = httpContextAccessor;
            customer = new Account();

        }
        public IList<Booking> Booking { get; set; } = default!;
        public Account customer { get; set; }

        public async Task OnGetAsync()
        {
            int? accountId = httpContextAccessor.HttpContext.Session.GetInt32("AccountId");
            customer = await accountRepository.GetById(accountId);
            Booking = await bookingRepository.GetAllHistoryBookingByCustomerId(accountId.Value);
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var check = await bookingRepository.GetBookingByBookingId(id.Value);

            if (check == null)
            {
                return NotFound();
            }
            var booking = bookingRepository.GetBookingId(id.Value);
            booking.Status = false;
            bookingRepository.Update(booking);
            return RedirectToPage("/Customer/BookingHistory");
        }
    }
}
