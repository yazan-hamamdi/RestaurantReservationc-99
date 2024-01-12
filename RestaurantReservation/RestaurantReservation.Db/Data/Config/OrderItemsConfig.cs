using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Data.Config
{
    public class OrderItemsConfig : IEntityTypeConfiguration<OrderItems>
    {

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<OrderItems> builder)
        {
            builder.HasKey(x => x.order_item_id);
            builder.Property(x => x.order_item_id).ValueGeneratedNever().IsRequired();
            builder.Property(x => x.order_id).IsRequired();
            builder.Property(x => x.item_id).IsRequired();


            builder.HasOne(x => x.MenuItem)
             .WithMany(x => x.OrderItems)
             .HasForeignKey(x => x.item_id)
             .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Order)
            .WithMany(x => x.OrderItems)
            .HasForeignKey(x => x.order_id)
            .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(LoadOrderItems());

            builder.ToTable("OrderItems");
        }
        private static List<OrderItems> LoadOrderItems()
        {
            return new List<OrderItems>
            {
            new OrderItems { order_item_id = 101,order_id = 1112 , item_id = 11, quantity = 2 },
            new OrderItems { order_item_id = 202,order_id = 2223 , item_id = 22, quantity = 1 },
            new OrderItems { order_item_id = 303,order_id = 3334 , item_id = 33, quantity = 3 },
            new OrderItems { order_item_id = 404,order_id = 4445 , item_id = 44, quantity = 2 },
            new OrderItems { order_item_id = 505,order_id = 5556 , item_id = 55, quantity = 1 }
            };
        }
    }
}
