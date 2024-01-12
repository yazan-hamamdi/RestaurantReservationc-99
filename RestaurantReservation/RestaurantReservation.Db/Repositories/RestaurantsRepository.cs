using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories
{
    public class RestaurantsRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;
        private readonly object _lockObject = new object();

        public RestaurantsRepository(RestaurantReservationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Restaurants
        public void CreateRestaurant(Restaurants restaurant)
        {
            lock (_lockObject)
            {
                _dbContext.Restaurants.Add(restaurant);
                _dbContext.SaveChanges();
            }
        }

        public void UpdateRestaurant(Restaurants restaurant)
        {
            lock (_lockObject)
            {
                _dbContext.Restaurants.Update(restaurant);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteRestaurant(int restaurantId)
        {
            lock (_lockObject)
            {
                var restaurantToDelete = _dbContext.Restaurants.Find(restaurantId);
                if (restaurantToDelete != null)
                {
                    _dbContext.Restaurants.Remove(restaurantToDelete);
                    _dbContext.SaveChanges();
                }
            }
        }
        // End Restaurants
    }

}
