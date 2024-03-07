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
        public void createAccount(Account account)
        {
            AccountDAO.Instance.createAccount(account);
        }

        public Account GetByEmail(string email)
        {
            return AccountDAO.Instance.GetAccountByemail(email);
        }

        public Account GetById(int? id)
        {
            return AccountDAO.Instance.GetById(id);
        }
    }
}
