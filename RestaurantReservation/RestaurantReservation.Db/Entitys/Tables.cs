using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Entitys
{
    public class Tables
    {
        public int table_id { set; get; }
        public int restaurant_id { set; get; }
        public int capacity { set; get; }
        public Restaurants? Restaurant { get;  set; }
        public ICollection<Reservations>? Reservations { get; set; } = new List<Reservations>();

    }
}
