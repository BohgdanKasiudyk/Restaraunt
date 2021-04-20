using System.Collections.Generic;
using System.Linq;
using BLL.Abstraction;
using DTO;
using RestaurantConsole.Abstraction;

namespace RestaurantConsole.Impementation
{
    public class UI : IUI
    {
        private readonly IDishService _dishService;
        private readonly IOrderService _orderService;
        private readonly IDataReader _dataReader;
        private readonly IDataWriter _dataWriter;
        private ICollection<DishDTO> dishes;
        private ICollection<DishDTO> selectedDishes;
        

        public UI(IDishService dishService, IOrderService orderService, IDataReader dataReader, IDataWriter dataWriter)
        {
            _dishService = dishService;
            _orderService = orderService;
            _dataReader = dataReader;
            _dataWriter = dataWriter;
            this.dishes = _dishService.GetAllDishes().ToList();
            this.selectedDishes = new List<DishDTO>();
        }

        public void Show()
        {
            bool workingNow = true;
            int selectedNumber;
            int dishId;
            OrderDTO orderDto = new OrderDTO();
            while (workingNow)
            {
                _dataWriter.ShowInstruction();
                selectedNumber = _dataReader.GetConsoleNumber();
                switch (selectedNumber)
                {
                    case 1: _dataWriter.ShowMenu(dishes);
                        break;
                    case 2:
                        dishId = _dataReader.GetDishId();
                        AddDish(dishes.Where(d => d.Id == dishId).First());
                        break;
                    case 3:
                        orderDto = CreateOrder();
                        break;
                    case 4:
                        _dataWriter.ShowOrder(orderDto);
                        break;
                    case 5:
                        workingNow = false;
                        break;
                }
            }
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