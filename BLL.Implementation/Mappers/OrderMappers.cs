using System.Linq;
using DTO;
using Entities;

namespace BLL.Implementation.Mappers
{
    public static class OrderMappers
    {
        public static Order ToEntity(this OrderDTO orderDto)
        {
            return new Order
            {
                Id = orderDto.Id,
                StartTime = orderDto.BeginOfOrder,
                DishOrders = orderDto.DishOrderDTOs.Select(dish => dish.ToEntity()).ToList(),
                CookingTime = orderDto.CookingTime
            };
        }

        public static OrderDTO ToDto(this Order order)
        {
            return new OrderDTO
            {
                Id = order.Id,
                BeginOfOrder = order.StartTime,
                DishOrderDTOs = order.DishOrders.Select(dish => dish.ToDto()).ToList(),
                CookingTime = order.CookingTime
            };
        }
    }
}