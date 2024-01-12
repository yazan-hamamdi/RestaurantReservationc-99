using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Data.Config
{
    public class TablesConfig : IEntityTypeConfiguration<Tables>
    {

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Tables> builder)
        {
            builder.HasKey(x => x.table_id);
            builder.Property(x => x.table_id).ValueGeneratedNever().IsRequired();
            builder.Property(x => x.restaurant_id).IsRequired();

            builder.HasOne(x => x.Restaurant)
               .WithMany(x => x.Tables)
               .HasForeignKey(x => x.restaurant_id);
            builder.HasData(LoadTables());

            builder.ToTable("Tables");
        }
        private static List<Tables> LoadTables()
        {
            return new List<Tables>
            {
             new Tables { table_id = 1122, restaurant_id = 111, capacity = 4 },
             new Tables { table_id = 2233, restaurant_id = 222, capacity = 6 },
             new Tables { table_id = 3344, restaurant_id = 333, capacity = 2 },
             new Tables { table_id = 4455, restaurant_id = 444, capacity = 8 },
             new Tables { table_id = 5566, restaurant_id = 555, capacity = 5 }
            };
        }
    }
}
