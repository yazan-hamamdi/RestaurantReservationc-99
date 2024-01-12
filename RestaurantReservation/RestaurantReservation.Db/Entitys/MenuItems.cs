using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Entitys
{
    public class MenuItems
    {
        public int item_id { set; get; }
        public int restaurant_id { set; get; }
        public string? name { set; get; }
        public string? description { set; get; }
        public int price { set; get; }
        public Restaurants? Restaurant { get; internal set; }
        public ICollection<OrderItems>? OrderItems { get; set; } = new List<OrderItems>();

    }
}
