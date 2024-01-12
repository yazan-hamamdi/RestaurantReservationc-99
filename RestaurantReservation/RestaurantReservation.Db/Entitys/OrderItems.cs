using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Entitys
{
    public class OrderItems
    {
        public int order_item_id { set; get; }
        public int order_id { set; get; }
        public int item_id { set; get; }
        public int quantity { set; get; }
        public MenuItems? MenuItem { get;  set; }
        public Orders? Order { get; set; }

    }
}
