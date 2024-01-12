using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Entitys
{
    public class Restaurants
    {
        public int restaurant_id { set; get; }
        public string? name { set; get; }
        public string? address { set; get; }
        public int phone_number { set; get; }
        public int opening_hours { set; get; }
        public ICollection<Employees>? Employees { get; set; } = new List<Employees>();
        public ICollection<MenuItems>? MenuItems { get; set; } = new List<MenuItems>();
        public ICollection<Tables>? Tables { get; set; } = new List<Tables>();
        public ICollection<Reservations>? Reservations { get; set; } = new List<Reservations>();




    }
}
