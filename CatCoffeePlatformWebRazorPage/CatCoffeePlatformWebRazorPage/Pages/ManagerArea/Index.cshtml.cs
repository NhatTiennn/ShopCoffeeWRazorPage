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
using Repositories.Repository;

namespace CatCoffeePlatformWebRazorPage.Pages.ManagerArea
{
    public class IndexModel : PageModel
    {
        private readonly IAreaRepository _areaRepository;

        public IndexModel(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        public IList<AreaInformation> Area { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                Area = await _areaRepository.AreaInformation();
                if (Area == null)
                {
                    return Page();
                }
                else
                {
                    return Page();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}
