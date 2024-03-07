using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RoleDAO
    {
        private CatCoffeePlatformContext _context = new CatCoffeePlatformContext();
        private static RoleDAO instance;
        private static readonly object instanceLock = new object();
        private RoleDAO() { }
        public static RoleDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RoleDAO();
                    }
                }
                return instance;
            }
        }

        public Role GetRole(int roleId)
        {
            return _context.Roles.SingleOrDefault(p => p.RoleId == roleId);
        }
    }
}
