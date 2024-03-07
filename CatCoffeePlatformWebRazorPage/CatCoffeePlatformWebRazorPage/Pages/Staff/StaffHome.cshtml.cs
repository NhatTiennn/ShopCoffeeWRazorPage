using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatCoffeePlatformWebRazorPage.Pages.Staff
{
    public class StaffHomeModel : PageModel
    {
        public IActionResult OnPost(string action)
        {
            if (action == "Manage cat")
            {
                return RedirectToPage("/ManagerCat/ListCat");
            }
            else if (action == "Manage booking")
            {
                return RedirectToPage("/ManageBooking/Index");
            }
            else if (action == "Manage area")
            {
                return RedirectToPage("/FoodDetail");
            }

            return Page();
        }
    }
}
