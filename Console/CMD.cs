using System.Collections.Generic;
using System.Linq;
using System;
using BLL.Abstraction;

using DTO;

namespace Console
{
    public class CMD : ICMD
    {
        private readonly IDishService _dishService;
        private readonly IOrderService _orderService;
        private ICollection<DishDTO> disheDtos;
        private ICollection<DishDTO> selectedDishes;

        public CMD(IDishService dishService, IOrderService orderService)
        {
            _dishService = dishService;
            _orderService = orderService;
            disheDtos = _dishService.GetAllDishes().ToList();
            selectedDishes = new List<DishDTO>();
        }



        public void Show()
        {
            bool work = true;
            int number;
            int dishId;
            OrderDTO orderDto = new OrderDTO();
            
            while (work)
            {ShowInstruction();
                number = GetConsoleNumber();
                
                switch (number)
                {
                    case 1: ShowMenu(disheDtos);
                        break;
                    case 2: dishId = GetDishId();
                        AddDish(disheDtos.Where(d => d.Id == dishId).First());
                        break;
                    case 3:
                        orderDto = CreateOrder();
                        break;
                    case 4:
                        ShowOrder(orderDto);
                        break;
                        
                    case 5:
                        work = false;
                        break;

                }

                
            }
        }
        
        private void ShowInstruction()
        {
            System.Console.WriteLine("Choose");
            System.Console.WriteLine("1. Get menu");
            System.Console.WriteLine("2. Add to order");
            System.Console.WriteLine("3. Create Order");
            System.Console.WriteLine("4. Show your order");
            System.Console.WriteLine("5. Exit");
        }
        
        
        private int GetDishId()
        {
            System.Console.Write("Input dish Id: ");
            return System.Convert.ToInt32(System.Console.ReadLine());

        }

        private int GetConsoleNumber()
        {
            System.Console.Write("Select number: ");
            return System.Convert.ToInt32(System.Console.ReadLine());
        }
        
        private void ShowMenu(IEnumerable<DishDTO> dishDtos)
        {
            System.Console.WriteLine("Menu: ");
            PrintDishes(dishDtos);
            System.Console.WriteLine(" ");
            
        }
        
        private void PrintDishes(IEnumerable<DishDTO> dishDtos)
        {
            System.Console.WriteLine("Id, Name, Price");
            foreach (DishDTO dishDto in dishDtos)
            {
                System.Console.WriteLine(dishDto.Id + " , " + dishDto.Name + " , " + dishDto.Price);
            }
        }
        private void ShowOrder(OrderDTO orderDto)
        {
            System.Console.WriteLine(" ");
            System.Console.WriteLine("Order start at: " + orderDto.BeginOfOrder);
            System.Console.WriteLine("Order cook will end at:  " + (orderDto.BeginOfOrder + orderDto.CookingTime));
        }
        
        private void AddDish(DishDTO dishDto)
        {
            selectedDishes.Add(dishDto);
        }
        
        private OrderDTO CreateOrder()
        {
            OrderDTO orderDto = _orderService.CreateOrder(selectedDishes.ToList());
            selectedDishes.Clear();
            return orderDto;
        }
        
    }
}