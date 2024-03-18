using BusinessObject.DTO;
using BusinessObject.Models;
using DataAccess;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public async void createAccount(Account account)
        {
            AccountDAO.Instance.createAccount(account);
        }

        public async Task<Account> GetByEmail(string email)
        {
            return await AccountDAO.Instance.GetAccountByemail(email);
        }

        public async Task<Account> GetById(int? id)
        {
            return await AccountDAO.Instance.GetById(id);
        }

        public async void UpdateAcount(Account request)
        {
            AccountDAO.Instance.UpdateAccount(request);
        }

        public async Task<Account> CreateAccount(Account cat)
        {
            return await AccountDAO.Instance.CreateAccount(cat);
        }

        public async Task<Account> DeleteAccount(int? id)
        {
            return await AccountDAO.Instance.DeleteAccount(id);
        }

        public async Task<IList<Account>> GetAllAccounts()
        {
            return await AccountDAO.Instance.GetAllAccounts();
        }

        public async Task<Account> GetAccountById(int? id)
        {
            return await AccountDAO.Instance.GetAccountById(id);
        }

        public async Task<Account> UpdateAccount(Account cat)
        {
            return await AccountDAO.Instance.UpdateAccount(cat);
        }

        public async Task<IList<Account>> SearchAccountByName(string name)
        {
            return await AccountDAO.Instance.SearchAccountByName(name);
        }

        public async Task<IList<AccountInformation>> AccountInformation()
        {
            return await AccountDAO.Instance.AccountInformation();
        }

        public async Task<AccountInformation> GetAccountInforById(int? id)
        {
            return await AccountDAO.Instance.GetAccountInforById(id);
        }

        public List<Account> GetAccount()
        {
            return AccountDAO.Instance.GetAccount();
        }

        public Task<List<Account>> GetAccountsByRoleId(int v)
        {
            return AccountDAO.Instance.GetAccountsByRoleId(v);
        }
    }
}
