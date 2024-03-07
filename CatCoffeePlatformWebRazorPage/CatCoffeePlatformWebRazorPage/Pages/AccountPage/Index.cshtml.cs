using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;

namespace CatCoffeePlatformWebRazorPage.Pages.AccountPage
{
    public class IndexModel : PageModel
    {
        private readonly CatCoffeePlatformContext _context;

        public IndexModel(CatCoffeePlatformContext context)
        {
            _context = context;
        }

        public IList<Account> Account { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Accounts != null)
            {
                Account = await _context.Accounts
                .Include(a => a.Role).ToListAsync();
            }
        }
    }
}
