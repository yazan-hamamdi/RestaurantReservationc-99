using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories
{
    public class MenuItemsRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;
        private readonly object _lockObject = new object();

        public MenuItemsRepository(RestaurantReservationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // MenuItems
        public void CreateMenuItem(MenuItems menuItem)
        {
            lock (_lockObject)
            {
                _dbContext.MenuItems.Add(menuItem);
                _dbContext.SaveChanges();
            }
        }

        public void UpdateMenuItem(MenuItems menuItem)
        {
            lock (_lockObject)
            {
                _dbContext.MenuItems.Update(menuItem);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteMenuItem(int itemId)
        {
            lock (_lockObject)
            {
                var menuItemToDelete = _dbContext.MenuItems.Find(itemId);
                if (menuItemToDelete != null)
                {
                    _dbContext.MenuItems.Remove(menuItemToDelete);
                    _dbContext.SaveChanges();
                }
            }
        }
        // End MenuItems
    }

}
