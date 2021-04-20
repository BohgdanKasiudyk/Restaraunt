using System;
using System.Collections.Generic;

namespace Entities
{
    public class Order: BaseEntity<int>
    {
        public DateTime StartTime { get; set; }
        
        public TimeSpan CookingTime { get; set; }

        public virtual ICollection<DishOrder> DishOrders { get; set; }

        public Order()
        {
            DishOrders = new List<DishOrder>();
        }
    }
}