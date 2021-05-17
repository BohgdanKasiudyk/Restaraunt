using System.Collections;
using System.Collections.Generic;

namespace Entities
{
    public class Menu : BaseEntity<int>
    {
        
        public string Name { get; set; }
        public virtual ICollection<DishMenu> DishMenus { get; set; }

        public Menu()
        {
            DishMenus = new List<DishMenu>();
        }
    }
}