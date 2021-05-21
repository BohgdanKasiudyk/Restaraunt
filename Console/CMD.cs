using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections;
using BLL.Abstraction;
using DAL.Abstraction.Repositories;
using DTO;
using Entities;

namespace Console
{
    public class CMD : ICMD
    {
        private readonly IDishService _dishService;
        private readonly IOrderService _orderService;
        private readonly IMenuService _menuService;
        private ICollection<DishDTO> disheDtos;
        private ICollection<DishDTO> selectedDishes;
        private ICollection<MenuDTO> Menus;

        public CMD(IDishService dishService, IOrderService orderService , IMenuService menuService)
        {
            _menuService = menuService;
            _dishService = dishService;
            _orderService = orderService;
            disheDtos = new List<DishDTO>();
            selectedDishes = new List<DishDTO>();
            Menus = _menuService.GetALLMenus().ToList();
        }



        public void Show()
        {
            bool work = true;
            int number;
            int dishId;
            int menuId = new int(); 
            OrderDTO orderDto = new OrderDTO();
            
            while (work)
            {ShowInstruction();
                number = GetConsoleNumber();
                
                switch (number)
                {
                    case 1: ShowMenus();
                        break;
                    case 2: 
                        menuId = GetMenuId();
                        disheDtos = _menuService.GetAllDishesFromMenu(menuId).ToList();
                        break;
                    case 3:
                        //disheDtos = _menuService.GetAllDishesFromMenu(menuId).ToList();
                        ShowMenu(disheDtos);
                        break;
                    case 4: dishId = GetDishId();
                        AddDish(disheDtos.Where(d => d.Id == dishId).First());
                        break;
                    case 5:
                        orderDto = CreateOrder();
                        break;
                    case 6:
                        ShowOrder(orderDto);
                        break;
                        
                    case 7:
                        work = false;
                        break;

                }

                
            }
        }
        
        private void ShowInstruction()
        {
            System.Console.WriteLine("Choose");
            System.Console.WriteLine("1. Show menus");
            System.Console.WriteLine("2. Select menu");
            System.Console.WriteLine("3. Get menu");
            System.Console.WriteLine("4. Add to order");
            System.Console.WriteLine("5. Create Order");
            System.Console.WriteLine("6. Show your order");
            System.Console.WriteLine("7. Exit");
        }
        
        
        private int GetDishId()
        {
            System.Console.Write("Input dish Id: ");
            return System.Convert.ToInt32(System.Console.ReadLine());

        }
        
        //private int Get

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

        private void ShowMenus()
        {
            System.Console.WriteLine("Id , Name" );
            foreach (MenuDTO menu in Menus)
            {
                System.Console.WriteLine(menu.Id + " " + menu.Name);
            }
        }

        private int GetMenuId()
        {
            System.Console.Write("Input menu Id: ");
            return System.Convert.ToInt32(System.Console.ReadLine());
            
        }

    }
}