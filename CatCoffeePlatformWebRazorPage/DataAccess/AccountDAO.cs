using BusinessObject.DTO;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
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
        public Account GetAccountByemail(string email)
        {
            return _context.Accounts.SingleOrDefault(p => p.Email.Equals(email));

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

        public async Task<IList<Account>> GetAllAccounts()
        {
            IList<Account> list = null;
            try
            {
                list = await _context.Accounts.ToListAsync();
                if (list.Count == 0)
                {
                    return list;
                }
                else
                {
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("List is have a problem");
            }
        }

        public async Task<Account> CreateAccount(Account area)
        {
            Account creAccount = new Account
            {
                UserName = area.UserName,
                AccountId = area.AccountId,
                RoleId = area.RoleId,
                Phone = area.Phone,
                Address = area.Address,
                Dob = area.Dob,
                Email = area.Email,
                Password = area.Password,
                Status = area.Status
            };
            _context.Accounts.Add(creAccount);
            await _context.SaveChangesAsync();

            return null;
        }

        public async Task<Account> GetAccountById(int? id)
        {
            Account area = null;
            try
            {
                area = await _context.Accounts.SingleOrDefaultAsync(area => area.AccountId == id);
                if (area == null)
                {
                    throw new Exception("The area can't found");
                }
                else
                {
                    return area;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("The area can't found");
            }
        }

        public async Task<Account> DeleteAccountById(int id)
        {
            Account area = await _context.Accounts.SingleOrDefaultAsync(c => c.AccountId == id);
            if (area == null)
            {
                throw new Exception("The area can't found");
            }
            else
            {
                _context.Remove(area);
                _context.SaveChangesAsync();
            }
            return area;
        }

        public async Task<Account> UpdateAccount(Account area)
        {
            try
            {
                Account getAccount = await GetAccountById(area.AccountId);
                if (getAccount == null)
                {
                    throw new Exception("The area can't found");
                }
                else
                {
                    Account updAccount = new Account
                    {
                        AccountId = getAccount.AccountId,
                        UserName = getAccount.UserName,
                        Status = getAccount.Status,
                    };
                    await _context.SaveChangesAsync();
                    return updAccount;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Have a problem with Update Account");
            }
        }

        public async Task<Account> DeleteAccount(int? id)
        {
            try
            {
                Account getAccount = await GetAccountById(id);
                if (getAccount == null)
                {
                    throw new Exception("The area can't found");
                }
                else
                {
                    _context.Remove(getAccount);
                    await _context.SaveChangesAsync();
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Have a problem with Delete Account");
            }
        }

        public async Task<IList<Account>> SearchAccountByName(string keyword)
        {
            try
            {
                IList<Account> listSearchAccount = null;
                listSearchAccount = await _context.Accounts.Where(name => name.UserName.Contains(keyword)).ToListAsync();
                if (listSearchAccount == null)
                {
                    throw new Exception("No found");
                }
                else
                {
                    return listSearchAccount;
                }
            }
            catch
            {
                throw new Exception("Have somethings wrong when search area");
            }
        }

        public async Task<IList<AccountInformation>> AccountInformation()
        {
            try
            {
                IList<AccountInformation> listAccountInformation = null;
                listAccountInformation = await (from a in _context.Accounts.AsNoTracking()
                                                join b in _context.Roles.AsNoTracking() on a.RoleId equals b.RoleId
                                                select new AccountInformation
                                                {
                                                    AccountId = a.AccountId,
                                                    UserName = a.UserName,
                                                    Address = a.Address,
                                                    Email = a.Email,
                                                    Phone = a.Phone,
                                                    Status = a.Status,
                                                    RoleName = b.RoleName
                                                }).ToListAsync();
                return listAccountInformation;
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<AccountInformation> GetAccountInforById(int? id)
        {
            try
            {
                AccountInformation catInfor = null;
                catInfor = await (from a in _context.Accounts.AsNoTracking()
                                  join b in _context.Roles.AsNoTracking() on a.RoleId equals b.RoleId
                                  select new AccountInformation
                                  {
                                      AccountId = a.AccountId,
                                      UserName = a.UserName,
                                      Address = a.Address,
                                      Email = a.Email,
                                      Phone = a.Phone,
                                      Status = a.Status,
                                      RoleName = b.RoleName
                                  }).FirstOrDefaultAsync(a => a.AccountId == id);
                return catInfor;
            }
            catch
            {
                throw new Exception();
            }
        }

        public List<Account> GetAccount()
        {
            return _context.Accounts.ToList();
        }

        public async Task<List<Account>> GetAccountsByRoleId(int roleId)
        {
            // Lấy danh sách các tài khoản có RoleId lớn hơn hoặc bằng 2
            var accounts = await _context.Accounts
                                        .Where(a => a.RoleId <= roleId)
                                        .ToListAsync();
            return accounts;
        }
    }
}
