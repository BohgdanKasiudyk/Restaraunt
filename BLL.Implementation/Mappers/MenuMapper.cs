using DTO;
using Entities;

namespace BLL.Implementation.Mappers
{
    public static class MenuMapper
    {
        public static MenuDTO toDTO(this Menu menu)
        {
            return new MenuDTO
            {
                Id = menu.Id,
                Name = menu.Name,

            };
        }

        public static Menu toEntity(this Menu menu)
        {
            return new Menu
            {
                Id = menu.Id,
                Name = menu.Name
            };
        }
    }
}