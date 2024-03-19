using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Repositories.Repository;
using Repositories.IRepository;

namespace CatCoffeePlatformWebRazorPage.Pages.Customer
{
    public class MyProfileModel : PageModel
    {
        private readonly IShopCoffeeCatRepository shopCoffeeCatRepository;
        private readonly IAccountRepository accountRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public MyProfileModel(IShopCoffeeCatRepository shopCoffeeCatRepository, IAccountRepository accountRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.shopCoffeeCatRepository = shopCoffeeCatRepository;
            this.accountRepository = accountRepository;
            this.httpContextAccessor = httpContextAccessor;
            Account = new Account();
        }

        [BindProperty]
        public Account Account { get; set; } = default!;
        [BindProperty]
        public string ConfirmPassword { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Account = await accountRepository.GetById((int)id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return Page();
            }

            if (Account.Password != ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "Mật khẩu và xác nhận mật khẩu không khớp.");
                return Page();
            }

            var accountToUpdate = await accountRepository.GetById((int)id);
            if (accountToUpdate == null)
            {
                return Page();
            }

            // Cập nhật thông tin tài khoản
            accountToUpdate.AccountId = Account.AccountId;
            accountToUpdate.Password = Account.Password;
            accountToUpdate.UserName = Account.UserName;
            accountToUpdate.Email = Account.Email;
            accountToUpdate.Phone = Account.Phone;
            accountToUpdate.Email = Account.Email;
            accountToUpdate.Dob = Account.Dob;
            accountToUpdate.Status = true;

             accountRepository.UpdateAccount(accountToUpdate);

            return Redirect("/Customer/MyProfile?id=" + id);
            }
    }
}
