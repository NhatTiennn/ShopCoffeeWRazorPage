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
    public class TableRepository : ITableRepository
    {
        
        public Table GetById(int tableId)
        {
            return TableDAO.Instance.GetById(tableId);
        }

        public List<Table> GetTableByShopId( int shopId)
        {
            return TableDAO.Instance.GetTableByShopId( shopId);
        }
        public List<Table> GetByShopId(int shopId)
        {
            return TableDAO.Instance.GetByShopId(shopId);
        }

        public Table GetByTableName(string tableName, int shopId)
        {
            return TableDAO.Instance.GetByTableName(tableName, shopId);
        }
    }
}
