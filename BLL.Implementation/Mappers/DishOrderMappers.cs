using DTO;
using Entities;

namespace BLL.Implementation.Mappers
{
    public static class DishOrderMappers
    {
        public static DishOrder ToEntity(this DishOrderDTO dishOrderDto)
        {
            return new DishOrder
            { 
                CookingTime =  dishOrderDto.CookingTime,
                DishId = dishOrderDto.DishDTO.Id,
                Id = dishOrderDto.Id,
                CookId = dishOrderDto.CookDto.Id,
                OrderId = dishOrderDto.OrderDto.Id
            };
        }

        public static DishOrderDTO ToDto(this DishOrder dishOrder)
        {
            return new DishOrderDTO
            {
                Id = dishOrder.Id,
                CookingTime = dishOrder.CookingTime,
                
            };
        }
    }
}