using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Models;

namespace CatCoffeePlatformWebRazorPage.Pages.ManageTable
{
    public class CreateModel : PageModel
    {
        private readonly CatCoffeePlatformContext _context;

        public CreateModel(CatCoffeePlatformContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "AreaName");
        ViewData["ShopId"] = new SelectList(_context.ShopCoffeeCats, "ShopId", "EndTime");
            return Page();
        }

        [BindProperty]
        public Table Table { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Tables == null || Table == null)
            {
                return Page();
            }

            _context.Tables.Add(Table);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
