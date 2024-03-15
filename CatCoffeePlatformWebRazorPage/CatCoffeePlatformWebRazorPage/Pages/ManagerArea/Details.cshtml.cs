using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using Repositories.IRepository;

namespace CatCoffeePlatformWebRazorPage.Pages.ManagerArea
{
    public class DetailsModel : PageModel
    {
        private readonly IAreaRepository _areaRepository;
        private readonly IAccountRepository _accountRepository;

        public DetailsModel(IAreaRepository areaRepository, IAccountRepository accountRepository)
        {
            _areaRepository = areaRepository;
            _accountRepository = accountRepository;
        }

        public Area Area { get; set; } = default!; 

        //public async Task<IActionResult> OnGetAsync(int? id)
        //{
        //    if (id == null || _context.Areas == null)
        //    {
        //        return NotFound();
        //    }

        //    var area = await _context.Areas.FirstOrDefaultAsync(m => m.AreaId == id);
        //    if (area == null)
        //    {
        //        return NotFound();
        //    }
        //    else 
        //    {
        //        Area = area;
        //    }
        //    return Page();
        //}
    }
}
