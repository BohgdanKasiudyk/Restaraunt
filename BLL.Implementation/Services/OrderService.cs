using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Abstraction;
using BLL.Implementation.Mappers;
using DAL.Abstraction.UnitOfWork;
using DTO;
using Entities;

namespace BLL.Implementation.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICookService _cookService;

        public OrderService(IUnitOfWork unitOfWork, ICookService cookService)
        {
            this._unitOfWork = unitOfWork;
            this._cookService = cookService;
        }

        public OrderDTO CreateOrder(IEnumerable<DishDTO> dishes)
        {  
            DateTime startOrderTime = DateTime.Now;
            Order order = new Order
            {
                StartTime = startOrderTime
            };

            foreach (DishDTO dishDto in dishes)
            {
                Cook cook = new Cook();
                Dish dish = _unitOfWork.Dishes.Read(dishDto.Id);
                 cook = _cookService.GetReadyCook(startOrderTime, dish.SpecializationId);
                TimeSpan dishOrderTime = CountTimeToCookDish(startOrderTime,dish, cook);
                DishOrder dishOrder = new DishOrder
                {
                    CookingTime = dishOrderTime,
                    Dish = dish,
                    Cook = cook
                };

                DateTime endOrder = startOrderTime + dishOrderTime;
                cook.WhenIsFree = endOrder;
                _unitOfWork.Cooks.Update(cook);
                order.DishOrders.Add(dishOrder);
            }

            DishOrder first = order.DishOrders.OrderBy(d => d.CookingTime).First();

            order.CookingTime = first.CookingTime ;
            
            _unitOfWork.Orders.Create(order);
            _unitOfWork.Save();
            return order.ToDto();
        }

        private TimeSpan CountTimeToCookDish( DateTime startOrderTime,Dish dish, Cook cook)
        {
            TimeSpan dishCookTime =
                new TimeSpan((long) (dish.CookingTime.Ticks + dish.CookingTime.Ticks * 0.1 * cook.Efficiency));

            if (cook.WhenIsFree < startOrderTime)
            {
                return dishCookTime;
            }

            return dishCookTime + (cook.WhenIsFree - startOrderTime);
        }
        
    }
    
}