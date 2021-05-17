using System.Collections;
using System.Collections.Generic;

namespace DTO
{
    public class MenuDTO: BaseDTO<int>
    {
        public string Name { get; set; }
        public IEnumerable<DishDTO> DishDtos { get; set; }

        public MenuDTO()
        {
            DishDtos = new List<DishDTO>();
        }
    }
}