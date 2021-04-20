namespace Entities
{
    public class DishIngredient: BaseEntity<int>
    {
        public int DishId { get; set; }
        public virtual Dish Dish { get; set; }

        public int IngredientId { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}