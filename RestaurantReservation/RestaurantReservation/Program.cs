using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReservation.Db.Modifications_to_entities;
using RestaurantReservation.Db.Entitys;
using Microsoft.Extensions.Options;
using RestaurantReservation.Db.Data;

namespace RestaurantReservation
{
     public class Program
    {
        static void Main(string[] args)
        {
            using var dbContext = new RestaurantReservationDbContext();
            {
                var service = new Modifications_to_entities(dbContext);
                var newCustomer = new Customers
                {
                    customer_id=6666,
                    first_name = "Jossssshn",
                    last_name = "Dosssse",
                    email = "john.sssssssdoe@example.com",
                    phone_number = "3-456-7890"
                };
                service.UpdateCustomer(newCustomer);
            }
            Console.WriteLine("Done!!!");
        } 
    }
}