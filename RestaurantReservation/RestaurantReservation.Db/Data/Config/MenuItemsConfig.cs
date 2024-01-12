using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Data.Config
{
    public class MenuItemsConfig : IEntityTypeConfiguration<MenuItems>
    {

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MenuItems> builder)
        {
            builder.HasKey(x => x.item_id);
            builder.Property(x => x.item_id).ValueGeneratedNever().IsRequired();
            builder.Property(x => x.restaurant_id).IsRequired();

            builder.HasOne(x => x.Restaurant)
               .WithMany(x => x.MenuItems)
               .HasForeignKey(x => x.restaurant_id);
            builder.HasData(LoadMenuItems());

            builder.ToTable("MenuItems");
        }
        private static List<MenuItems> LoadMenuItems()
        {
            return new List<MenuItems>
            {
            new MenuItems { item_id = 11, restaurant_id = 111, name = "Burger", description = "Juicy beef burger with cheese and veggies", price = 10 },
            new MenuItems { item_id = 22, restaurant_id = 222, name = "Pasta", description = "Spaghetti with tomato sauce and meatballs", price = 15 },
            new MenuItems { item_id = 33, restaurant_id = 333, name = "Salad", description = "Fresh garden salad with mixed greens", price = 8 },
            new MenuItems { item_id = 44, restaurant_id = 444, name = "Pizza", description = "Margherita pizza with tomato, mozzarella, and basil", price = 12 },
            new MenuItems { item_id = 55, restaurant_id = 555, name = "Sushi", description = "Assorted sushi rolls with wasabi and soy sauce", price = 18 }
            };
        }
    }
}
