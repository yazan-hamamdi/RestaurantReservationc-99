using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories
{
    public class EmployeeRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;
        private readonly object _lockObject = new object();

        public EmployeeRepository(RestaurantReservationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Employees
        public void CreateEmployee(Employees employee)
        {
            lock (_lockObject)
            {
                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();
            }
        }

        public void UpdateEmployee(Employees employee)
        {
            lock (_lockObject)
            {
                _dbContext.Employees.Update(employee);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteEmployee(int employeeId)
        {
            lock (_lockObject)
            {
                var employeeToDelete = _dbContext.Employees.Find(employeeId);
                if (employeeToDelete != null)
                {
                    _dbContext.Employees.Remove(employeeToDelete);
                    _dbContext.SaveChanges();
                }
            }
        }
        // End Employees
    }

}
