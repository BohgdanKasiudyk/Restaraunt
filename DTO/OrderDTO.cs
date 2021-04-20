using System;
using System.Collections.Generic;

namespace DTO


{
    public class OrderDTO: BaseDTO<int>
    {
        
        public DateTime BeginOfOrder { get; set; }
        
        public TimeSpan CookingTime { get; set; }

        public IEnumerable<DishOrderDTO> DishOrderDTOs { get; set; }

        public OrderDTO()
        {
            DishOrderDTOs = new List<DishOrderDTO>();
        }
    }
}