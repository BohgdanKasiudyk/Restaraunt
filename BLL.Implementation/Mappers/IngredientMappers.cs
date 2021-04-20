using DTO;
using Entities;

namespace BLL.Implementation.Mappers
{
    public static class IngredientMappers
    {
        public static Ingredient ToEntity(this IngredientDTO ingredientDto)
        {
            return new Ingredient
            {
                Id = ingredientDto.Id,
                Name = ingredientDto.Name

            };
        }

        public static IngredientDTO ToDTO(this Ingredient ingredient)
        {
            return new IngredientDTO
            {
                Id = ingredient.Id,
                Name = ingredient.Name
            };
        }
    }
}