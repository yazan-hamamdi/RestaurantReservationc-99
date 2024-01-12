using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories
{
    public class OrderItemsRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;
        private readonly object _lockObject = new object();

        public OrderItemsRepository(RestaurantReservationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // OrderItems
        public void CreateOrderItem(OrderItems orderItem)
        {
            lock (_lockObject)
            {
                _dbContext.OrderItems.Add(orderItem);
                _dbContext.SaveChanges();
            }
        }

        public void UpdateOrderItem(OrderItems orderItem)
        {
            lock (_lockObject)
            {
                _dbContext.OrderItems.Update(orderItem);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteOrderItem(int orderItemId)
        {
            lock (_lockObject)
            {
                var orderItemToDelete = _dbContext.OrderItems.Find(orderItemId);
                if (orderItemToDelete != null)
                {
                    _dbContext.OrderItems.Remove(orderItemToDelete);
                    _dbContext.SaveChanges();
                }
            }
        }
        // End OrderItems
    }

}
