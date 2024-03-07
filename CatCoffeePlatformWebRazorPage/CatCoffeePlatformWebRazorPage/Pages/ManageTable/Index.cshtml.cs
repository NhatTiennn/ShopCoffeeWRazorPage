using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;

namespace CatCoffeePlatformWebRazorPage.Pages.ManageTable
{
    public class IndexModel : PageModel
    {
        private readonly CatCoffeePlatformContext _context;

        public IndexModel(CatCoffeePlatformContext context)
        {
            _context = context;
        }

        public IList<Table> Table { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Tables != null)
            {
                Table = await _context.Tables
                .Include(t => t.Area)
                .Include(t => t.Shop).ToListAsync();
            }
        }
    }
}
