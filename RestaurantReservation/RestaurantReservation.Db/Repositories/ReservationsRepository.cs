using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories
{
        public class ReservationsRepository
        {
            private readonly RestaurantReservationDbContext _dbContext;
            private readonly object _lockObject = new object();

            public ReservationsRepository(RestaurantReservationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            // Reservations
            public void CreateReservation(Reservations reservation)
            {
                lock (_lockObject)
                {
                    _dbContext.Reservations.Add(reservation);
                    _dbContext.SaveChanges();
                }
            }

            public void UpdateReservation(Reservations reservation)
            {
                lock (_lockObject)
                {
                    _dbContext.Reservations.Update(reservation);
                    _dbContext.SaveChanges();
                }
            }

            public void DeleteReservation(int reservationId)
            {
                lock (_lockObject)
                {
                    var reservationToDelete = _dbContext.Reservations.Find(reservationId);
                    if (reservationToDelete != null)
                    {
                        _dbContext.Reservations.Remove(reservationToDelete);
                        _dbContext.SaveChanges();
                    }
                }
            }
            // End Reservations

            public List<Reservations> GetReservationsByCustomer(int customerId)
            {
                lock (_lockObject)
                {
                    var reservations = _dbContext.Reservations
                       .Where(r => r.customer_id == customerId)
                       .ToList();
                    return reservations;
                }
            }
        }

  }

