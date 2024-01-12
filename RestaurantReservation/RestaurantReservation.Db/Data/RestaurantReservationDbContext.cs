using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestaurantReservation.Db.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Data
{
    public class RestaurantReservationDbContext : DbContext
    {
        public DbSet<Customers> Customers { set; get; }
        public DbSet<Employees> Employees { set; get; }
        public DbSet<MenuItems> MenuItems { set; get; }
        public DbSet<OrderItems> OrderItems { set; get; }
        public DbSet<Orders> Orders { set; get; }
        public DbSet<Reservations> Reservations { set; get; }
        public DbSet<Restaurants> Restaurants { set; get; }
        public DbSet<Tables> Tables { set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var con = new ConfigurationBuilder().AddJsonFile("AppSetting.json").Build();

            var c = con.GetSection("constr").Value;
            optionsBuilder.UseSqlServer(c);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RestaurantReservationDbContext).Assembly);
            modelBuilder.Entity<Reservations>()
           .HasOne(r => r.Table)
           .WithMany(t => t.Reservations)
           .HasForeignKey(r => r.table_id)
           .OnDelete(DeleteBehavior.ClientNoAction);
        }

    }
}
