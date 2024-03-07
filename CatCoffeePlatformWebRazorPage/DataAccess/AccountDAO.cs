using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataAccess
{
    public class AccountDAO
    {
        private CatCoffeePlatformContext _context = new CatCoffeePlatformContext();
        private static AccountDAO instance;
        private static readonly object instanceLock = new object();
        private AccountDAO() { }
        public static AccountDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AccountDAO();
                    }
                }
                return instance;
            }
        }
        public  Account GetAccountByemail(string email)
        {
            return _context.Accounts.SingleOrDefault(p => p.Email.Equals(email) );
            
        }
        public void createAccount(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        public Account GetById(int? id)
        {
            return _context.Accounts.SingleOrDefault(p => p.AccountId.Equals(id));
        }

    }
}
