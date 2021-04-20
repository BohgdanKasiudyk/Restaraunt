
using System;
using System.Collections.Generic;

namespace Entities
{
    public class Dish: BaseEntity<int>
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public double Weight { get; set; }
        public TimeSpan CookingTime { get; set; } 
        
        public int SpecializationId { get; set; }
        
        public virtual Specialization Specialization { get; set; }

        
        
        public virtual ICollection<DishIngredient> DishIngredients { get; set; }

       

        public Dish()
        {
            DishIngredients = new List<DishIngredient>();
        }
    }
}