using System;
using System.Collections.Generic;
using DTO;

namespace RestaurantConsole.Abstraction
{
    public interface IDataWriter
    {
        void ShowInstruction();

        void ShowMenu(IEnumerable<DishDTO> dishDtos);

        void ShowSelectedDishes(IEnumerable<DishDTO> dishDtos);

        void ShowOrder(OrderDTO orderDto);
        
        
    }
}