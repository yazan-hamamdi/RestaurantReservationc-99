using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Entitys
{
    public class Customers
    {
        public int customer_id { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string? email { get; set; }
        public string? phone_number { get; set; }
        public ICollection<Reservations>? Reservations { get; set; } = new List<Reservations>();


    }
}
