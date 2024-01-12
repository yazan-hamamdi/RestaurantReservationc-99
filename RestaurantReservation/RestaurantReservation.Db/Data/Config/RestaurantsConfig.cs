using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Data.Config
{
    public class RestaurantsConfig : IEntityTypeConfiguration<Restaurants>
    {

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Restaurants> builder)
        {
            builder.HasKey(x => x.restaurant_id);
            builder.Property(x => x.restaurant_id).ValueGeneratedNever().IsRequired();
            builder.HasData(LoadRestaurants());
            builder.ToTable("Restaurants");
        }
        private static List<Restaurants> LoadRestaurants()
        {
            return new List<Restaurants>
            {
              new Restaurants { restaurant_id = 111, name = "Doe's Diner", address = "123 Main St", phone_number = 5551657, opening_hours = 8 },
              new Restaurants { restaurant_id = 222, name = "Smith's Bistro", address = "456 Oak Ave", phone_number = 555543, opening_hours = 9 },
              new Restaurants { restaurant_id = 333, name = "Johnson's Grill", address = "789 Elm Blvd", phone_number = 555490, opening_hours = 7 },
              new Restaurants { restaurant_id = 444, name = "Williams' Pizzeria", address = "567 Pine Dr", phone_number = 5544478, opening_hours = 10 },
              new Restaurants { restaurant_id = 555, name = "Anderson's Sushi House", address = "890 Cedar Ln", phone_number = 555432, opening_hours = 11 }
             };
        }
    }
}
