namespace Entities
{
    public class DishMenu: BaseEntity<int>
    {
        public int MenuId { get; set; }
        public virtual Menu Menu { get; set; }
        public int DishId { get; set; }
        public virtual Dish Dish { get; set; }
    }
}