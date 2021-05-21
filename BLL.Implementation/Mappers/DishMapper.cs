using System.Linq;
using DTO;
using Entities;

namespace BLL.Implementation.Mappers
{
    public static class DishMapper
    {
        public static Dish ToEntity(this DishDTO dishDto)
        {
            return new Dish
            {
                Id = dishDto.Id,
                Price = dishDto.Price,
                CookingTime = dishDto.CookingTime, 
                Weight = dishDto.Weight,
                SpecializationId = dishDto.Specialization.Id

            };
        }

        public static DishDTO ToDto(this Dish dish)
        {
            return new DishDTO
            {
                Name = dish.Name,
                Id = dish.Id,
                Price = dish.Price,
                CookingTime = dish.CookingTime,
                IngredientDTOs = dish.DishIngredients.Select(di => di.Ingredient.ToDTO()).ToList(),
                Weight = dish.Weight,
                
                Specialization = dish.Specialization.ToDto()
            };
        }
    }
}