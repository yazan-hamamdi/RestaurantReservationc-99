using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories
{
    public class OrdersRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;
        private readonly object _lockObject = new object();

        public OrdersRepository(RestaurantReservationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Orders
        public void CreateOrder(Orders order)
        {
            lock (_lockObject)
            {
                _dbContext.Orders.Add(order);
                _dbContext.SaveChanges();
            }
        }

        public void UpdateOrder(Orders order)
        {
            lock (_lockObject)
            {
                _dbContext.Orders.Update(order);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteOrder(int orderId)
        {
            lock (_lockObject)
            {
                var orderToDelete = _dbContext.Orders.Find(orderId);
                if (orderToDelete != null)
                {
                    _dbContext.Orders.Remove(orderToDelete);
                    _dbContext.SaveChanges();
                }
            }
        }
        // End Orders
    }

}
