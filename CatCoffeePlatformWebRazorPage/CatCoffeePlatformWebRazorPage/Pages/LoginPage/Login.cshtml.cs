using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.IRepository;
using System.ComponentModel.DataAnnotations;

namespace CatCoffeePlatformWebRazorPage.Pages.LoginPage
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [BindProperty]
        [Required]
        public string Password { get; set; }
        private readonly IAccountRepository accountRepository;
        private readonly IRoleRepository roleRepository;
        public LoginModel(IAccountRepository accountRepository, IRoleRepository roleRepository)
        {
            this.accountRepository = accountRepository;
            this.roleRepository = roleRepository;
        }

        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            var account = await accountRepository.GetByEmail(Email);
            if(account != null)
            {
                HttpContext.Session.SetString("Email", Email);
                HttpContext.Session.SetInt32("AccountId", account.AccountId);
            }
            var role = roleRepository.GetRole(account.RoleId);
            if (role.RoleName.ToLower().Equals("customer"))
            {
                return Redirect("https://localhost:7125?id=" + account.AccountId);
            }
            if (role.RoleName.ToLower().Equals("staff"))
            {
                return Redirect("/Staff/StaffHome");
            }
            return Page();
        }
    }
}
