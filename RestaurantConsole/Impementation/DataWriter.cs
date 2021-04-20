using System;
using System.Collections.Generic;
using DTO;
using RestaurantConsole.Abstraction;

namespace RestaurantConsole.Impementation
{
    public class DataWriter : IDataWriter
    {
        public void ShowInstruction()
        {
            Console.WriteLine("Choose");
            Console.WriteLine("1. Get menu");
            Console.WriteLine("2. Add to order");
            Console.WriteLine("3. Create Order");
            Console.WriteLine("4. Show your order");
            Console.WriteLine("5. Exit");
        }

        public void ShowMenu(IEnumerable<DishDTO> dishDtos)
        {
            Console.WriteLine("Menu: ");
            PrintDishes(dishDtos);
            Console.WriteLine(" ");
            
        }

        public void ShowSelectedDishes(IEnumerable<DishDTO> dishDtos)
        {
            Console.WriteLine("Your dishes ");
            PrintDishes(dishDtos);
            Console.WriteLine(" ");
        }

        public void ShowOrder(OrderDTO orderDto)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order start at: " + orderDto.BeginOfOrder);
            Console.WriteLine("Order cook will end at:  " + (orderDto.BeginOfOrder + orderDto.CookingTime));
        }


        private void PrintDishes(IEnumerable<DishDTO> dishDtos)
        {
            Console.WriteLine("Id, Name, Price");
            foreach (DishDTO dishDto in dishDtos)
            {
                Console.WriteLine(dishDto.Id + " , " + dishDto.Name + " , " + dishDto.Price);
            }
        }
        
    }
}