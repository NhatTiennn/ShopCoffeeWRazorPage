using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using Repositories.IRepository;
using BusinessObject.DTO;

namespace CatCoffeePlatformWebRazorPage.Pages.ManagerCat
{
    public class DeleteModel : PageModel
    {
        private readonly ICatRepository _catRepository;

        public DeleteModel(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        [BindProperty]
        public CatInformation Cat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cat = await _catRepository.GetCatInforById(id);

            if (Cat == null)
            {
                return NotFound();
            }
            else 
            {
                Cat = Cat;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cat = await _catRepository.GetCatById(id);

            if (cat != null)
            {
                await _catRepository.DeleteCat(id);
            }
            return Redirect("/ManagerCat/ListCat");
        }
    }
}
