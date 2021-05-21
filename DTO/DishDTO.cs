using System;
using System.Collections.Generic;

namespace DTO
{
    public class DishDTO : BaseDTO<int>
    {
        
        public string Name { get; set; }
        public int Price { get; set; }
        public double Weight { get; set; }
        public TimeSpan CookingTime { get; set; } 
        public IEnumerable<IngredientDTO> IngredientDTOs { get; set; }
        public SpecializationDTO Specialization { get; set; }
        
        

        public DishDTO()
        {
            IngredientDTOs = new List<IngredientDTO>();
            
        }
    }
}