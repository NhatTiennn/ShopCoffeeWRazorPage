using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TableDAO
    {
        private CatCoffeePlatformContext _context = new CatCoffeePlatformContext();
        private static TableDAO instance;
        private static readonly object instanceLock = new object();
        private TableDAO() { }
        public static TableDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TableDAO();
                    }
                }
                return instance;
            }
        }


        public Table GetById(int tableId)
        {
            return _context.Tables.SingleOrDefault(p => p.TableId == tableId);
        }

        public List<Table> GetTableByShopId(int shopId)
        {
            return _context.Tables.Where(p => p.ShopId == shopId).ToList();
        }

        public List<Table> GetByShopId(int shopId)
        {
            return _context.Tables.Where(p => p.ShopId == shopId).ToList();
        }
        public Table GetByTableName(string tableName, int shopId)
        {
            return _context.Tables.SingleOrDefault(p => p.TableName.Equals(tableName) && p.ShopId == shopId);
        }
    }
}
