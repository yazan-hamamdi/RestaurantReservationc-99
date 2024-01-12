using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Data.Config
{
    public class OrdersConfig : IEntityTypeConfiguration<Orders>
    {

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Orders> builder)
        {
            builder.HasKey(x => x.order_id);
            builder.Property(x => x.order_id).ValueGeneratedNever().IsRequired();
            builder.Property(x => x.reservation_id).IsRequired();
            builder.Property(x => x.employee_id).IsRequired();


            builder.HasOne(x => x.Reservation)
              .WithMany(x => x.Orders)
              .HasForeignKey(x => x.reservation_id)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Employee)
             .WithMany(x => x.Orders)
             .HasForeignKey(x => x.employee_id)
             .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(LoadOrders());

            builder.ToTable("Orders");
        } 
        private static List<Orders> LoadOrders()
        {
            return new List<Orders>
            {
            new Orders { order_id = 1112, reservation_id = 1234, employee_id = 4321, order_date = DateTime.Parse("2024-01-04"), total_amount = 85 },
            new Orders { order_id = 2223, reservation_id = 2345, employee_id = 5432, order_date = DateTime.Parse("2024-01-05"), total_amount = 120 },
            new Orders { order_id = 3334, reservation_id = 3456, employee_id = 6543, order_date = DateTime.Parse("2024-01-06"), total_amount = 45 },
            new Orders { order_id = 4445, reservation_id = 4567, employee_id = 7654, order_date = DateTime.Parse("2024-01-07"), total_amount = 100 },
            new Orders { order_id = 5556, reservation_id = 5678, employee_id = 8765, order_date = DateTime.Parse("2024-01-08"), total_amount = 150 }
            };
         }
    }
}
