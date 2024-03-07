using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;
using Repositories.IRepository;
using BusinessObject.Models;


namespace CatCoffeePlatformWebRazorPage.Pages.AccountPage
{
    public class CreateModel : PageModel
    {
        private readonly IAccountRepository accountRepository;

        public CreateModel(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        [BindProperty]
        public string? UserName { get; set; }

        [BindProperty]
        public string? Phone { get; set; }

        [BindProperty]
        public string? Address { get; set; }
        [BindProperty]
        public string? Dob { get; set; }

        [BindProperty]
        [EmailAddress]
        [Required(ErrorMessage = "Email required")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }

        [BindProperty]
        public string ConfirmPassword { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var accountExist = accountRepository.GetByEmail(Email);
            if (accountExist == null)
            {
                if(Dob == null)
                {
                    var newAccount = new Account
                    {
                        RoleId = 2,
                        UserName = UserName,
                        Phone = Phone,
                        Address = Address,
                        Email = Email,
                        Password = Password,
                        Status = true
                    };
                    accountRepository.createAccount(newAccount);
                }
                else
                {
                    var newAccount = new Account
                    {
                        RoleId = 2,
                        UserName = UserName,
                        Phone = Phone,
                        Address = Address,
                        Dob = DateTime.Parse(Dob),
                        Email = Email,
                        Password = Password,
                        Status = true
                    };
                    accountRepository.createAccount(newAccount);
                }
                return RedirectToPage("/Customer/HomePage");
            }
            return Page();

        }
    }
}
