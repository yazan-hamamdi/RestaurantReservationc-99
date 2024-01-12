using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.methods
{
    public class CustomersRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;
        private readonly object _lockObject = new object();

        public CustomersRepository(RestaurantReservationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Customers
        public void CreateCustomer(Customers customer)
        {
            lock (_lockObject)
            {
                _dbContext.Customers.Add(customer);
                _dbContext.SaveChanges();
            }
        }

        public void UpdateCustomer(Customers customer)
        {
            lock (_lockObject)
            {
                _dbContext.Customers.Update(customer);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteCustomer(int customerId)
        {
            lock (_lockObject)
            {
                var customerToDelete = _dbContext.Customers.Find(customerId);
                if (customerToDelete != null)
                {
                    _dbContext.Customers.Remove(customerToDelete);
                    _dbContext.SaveChanges();
                }
            }
        }

        // End Customers
        public List<Employees> ListManagers()
        {
            lock (_lockObject)
            {
                var managers = _dbContext.Employees
                    .Where(e => e.position == "Manager")
                    .ToList();

                return managers;
            }
        }
    }

}