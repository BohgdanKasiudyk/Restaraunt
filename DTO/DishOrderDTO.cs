using System;

namespace DTO
{
    public class DishOrderDTO : BaseDTO<int>
    {
        
        
        public TimeSpan CookingTime { get; set; }

        public DishDTO DishDTO { get; set; }
        
        public CookDTO CookDto { get; set; }
        
        public OrderDTO OrderDto { get; set; }
    }
}