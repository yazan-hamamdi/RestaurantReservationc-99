using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Entitys
{
    public class Employees
    {
        public int employee_id { set; get; }
        public int restaurant_id { set; get; }
        public string? first_name { set; get; }
        public string? last_name { set; get; }
        public string? position { set; get; }
        public Restaurants? Restaurant { get; set; }
        public ICollection<Orders>? Orders { get; set; } = new List<Orders>();

    }
}
