using System;

namespace Entities
{
    public class DishOrder: BaseEntity<int>
    
    {
        public TimeSpan CookingTime{ get; set; }

        public int DishId { get; set; }
        public virtual Dish Dish { get; set; }

        public int CookId { get; set; }
        public virtual Cook Cook { get; set; }
        
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}