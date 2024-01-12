using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Entitys
{
    public class Orders
    {
        public int order_id { set; get; }
        public int reservation_id { set; get; }
        public int employee_id { set; get; }
        public DateTime order_date { set; get; }
        public int total_amount { set; get; }
        public ICollection<OrderItems>? OrderItems { get; set; } = new List<OrderItems>();
        public Reservations? Reservation { get; set; }
        public Employees? Employee { get; set; }



    }
}
