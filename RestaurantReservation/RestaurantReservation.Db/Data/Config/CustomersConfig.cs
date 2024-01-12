using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Data.Config
{
    public class CustomersConfig : IEntityTypeConfiguration<Customers>
    {
        
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Customers> builder)
        {
            builder.HasKey(x => x.customer_id);
            builder.Property(x => x.customer_id).ValueGeneratedNever().IsRequired();
            builder.HasData(LoadCustomers());
            builder.ToTable("Customers");
        }
        public static List<Customers> LoadCustomers()
        {
            return new List<Customers>
        {
            new Customers { customer_id = 1111, first_name = "John", last_name = "Doe", email = "john.doe@example.com", phone_number = "+1234567890" },
            new Customers { customer_id = 2222, first_name = "Jane", last_name = "Smith", email = "jane.smith@example.com", phone_number = "+1987654321" },
            new Customers { customer_id = 3333, first_name = "Alice", last_name = "Johnson", email = "alice.johnson@example.com", phone_number = "+1122334455" },
            new Customers { customer_id = 4444, first_name = "Bob", last_name = "Williams", email = "bob.williams@example.com", phone_number = "+1555666777" },
            new Customers { customer_id = 5555, first_name = "Eva", last_name = "Anderson", email = "eva.anderson@example.com", phone_number = "+1444333222" }
        };
        }
    }
}
