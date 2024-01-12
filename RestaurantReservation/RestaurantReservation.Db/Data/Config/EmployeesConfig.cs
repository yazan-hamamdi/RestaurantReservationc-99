using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Data.Config
{
    public class EmployeesConfig : IEntityTypeConfiguration<Employees>
    {

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Employees> builder)
        {
            builder.HasKey(x => x.employee_id);
            builder.Property(x => x.employee_id).ValueGeneratedNever().IsRequired();
            builder.Property(x => x.restaurant_id).IsRequired();

            builder.HasOne(x => x.Restaurant)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.restaurant_id);
            builder.HasData(Loademployees());

            builder.ToTable("Employees");
        }
        private static List<Employees> Loademployees()
        {
            return new List<Employees>
            {
        new Employees { employee_id = 4321,  restaurant_id = 111, first_name = "John", last_name = "Doe", position = "Server" },
        new Employees { employee_id = 5432,  restaurant_id = 222 ,first_name = "Jane", last_name = "Smith", position = "Chef" },
        new Employees { employee_id = 6543,  restaurant_id = 333 ,first_name = "Alice", last_name = "Johnson", position = "Waiter" },
        new Employees { employee_id = 7654,  restaurant_id = 444 ,first_name = "Bob", last_name = "Williams", position = "Bartender" },
        new Employees { employee_id = 8765,  restaurant_id = 555 ,first_name = "Eva", last_name = "Anderson", position = "Manager" }
           };
        }
    }
}
