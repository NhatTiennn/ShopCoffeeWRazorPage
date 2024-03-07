using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface ITableRepository
    {
        public Table GetById(int tableId);
        List<Table> GetTableByShopId(int shopId);

    }
}
