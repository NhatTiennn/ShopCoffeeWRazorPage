using BusinessObject.DTO;
using BusinessObject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IAccountRepository
    {
        public Account GetByEmail(string email);
        public void createAccount(Account account);

        Account GetById(int? id);

        Task<IList<Account>> GetAllAccounts();

        Task<Account> GetAccountById(int? id);

        Task<Account> CreateAccount(Account cat);

        Task<Account> UpdateAccount(Account cat);

        Task<Account> DeleteAccount(int? id);

        Task<IList<Account>> SearchAccountByName(string name);

        Task<IList<AccountInformation>> AccountInformation();

        Task<AccountInformation> GetAccountInforById(int? id);
        List<Account> GetAccount();
        Task<List<Account>> GetAccountsByRoleId(int v);
    }
}
