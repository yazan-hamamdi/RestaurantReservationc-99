using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Entitys
{
    public class Reservations
    {
        public int reservation_id { set; get; }
        public int customer_id { set; get; }
        public int restaurant_id { set; get; }
        public int table_id { set; get; }
        public DateTime reservation { set; get; }
        public int party_size { set; get; }
        public Restaurants? Restaurant { get;  set; }
        public Customers? Customer{ get;  set; }
        public Tables? Table { get; set; }
        public ICollection<Orders>? Orders { get; set; } = new List<Orders>();


    }
}
