using BusinessObject.Models;
using System;
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
    }
}
