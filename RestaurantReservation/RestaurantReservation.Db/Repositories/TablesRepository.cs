using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories
{
    public class TablesRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;
        private readonly object _lockObject = new object();

        public TablesRepository(RestaurantReservationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Tables
        public void CreateTable(Tables table)
        {
            lock (_lockObject)
            {
                _dbContext.Tables.Add(table);
                _dbContext.SaveChanges();
            }
        }

        public void UpdateTable(Tables table)
        {
            lock (_lockObject)
            {
                _dbContext.Tables.Update(table);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteTable(int tableId)
        {
            lock (_lockObject)
            {
                var tableToDelete = _dbContext.Tables.Find(tableId);
                if (tableToDelete != null)
                {
                    _dbContext.Tables.Remove(tableToDelete);
                    _dbContext.SaveChanges();
                }
            }
        }
        // End Tables
    }

}
