using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Data.Config
{
     public class ReservationsConfig : IEntityTypeConfiguration<Reservations>
    {

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Reservations> builder)
        {
            builder.HasKey(x => x.reservation_id);
            builder.Property(x => x.reservation_id).ValueGeneratedNever().IsRequired();
            builder.Property(x => x.restaurant_id).IsRequired();

            builder.HasOne(x => x.Restaurant)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.restaurant_id)
                .OnDelete(DeleteBehavior.Restrict);  

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.customer_id)
                .OnDelete(DeleteBehavior.Restrict);  

            builder.HasOne(x => x.Table)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.table_id)
                .OnDelete(DeleteBehavior.Restrict);  

            builder.HasData(LoadReservations());

            builder.ToTable("Reservations");
        }
        private static List<Reservations> LoadReservations()
        {
            return new List<Reservations>
            {
             new Reservations { reservation_id = 1234, customer_id = 1111,  restaurant_id = 111,  table_id = 1122, reservation = DateTime.Now.AddDays(1), party_size = 4 },
             new Reservations { reservation_id = 2345, customer_id = 2222,  restaurant_id = 222,  table_id = 2233, reservation = DateTime.Now.AddDays(2), party_size = 2 },
             new Reservations { reservation_id = 3456, customer_id = 3333,  restaurant_id = 333,  table_id = 3344, reservation = DateTime.Now.AddDays(3), party_size = 6 },
             new Reservations { reservation_id = 4567, customer_id = 4444,  restaurant_id = 444,  table_id = 4455, reservation = DateTime.Now.AddDays(4), party_size = 3 },
             new Reservations { reservation_id = 5678, customer_id = 5555,  restaurant_id = 555,  table_id = 5566, reservation = DateTime.Now.AddDays(5), party_size = 5 }
             };
        } 
    }
}
