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
    public class RoleRepository : IRoleRepository
    {
        
        public Role GetRole(int roleId)
        {
            return RoleDAO.Instance.GetRole(roleId);
        }
    }
}
