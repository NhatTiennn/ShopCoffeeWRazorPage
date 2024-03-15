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

namespace CatCoffeePlatformWebRazorPage.Pages.ManagerArea
{
    public class DeleteModel : PageModel
    {
        private readonly IAreaRepository _areaRepository;
        private readonly IAccountRepository _accountRepository;

        public DeleteModel(IAreaRepository areaRepository, IAccountRepository accountRepository)
        {
            _areaRepository = areaRepository;
            _accountRepository = accountRepository;
        }

        [BindProperty]
        public Area Area { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Area = await _areaRepository.GetAreaInforById(id);


            if (Area == null)
            {
                return NotFound();
            }
            else
            {
                Area = Area;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }
            var area = await _areaRepository.GetById(id);

            if (area != null)
            {
                await _areaRepository.DeleteById(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
