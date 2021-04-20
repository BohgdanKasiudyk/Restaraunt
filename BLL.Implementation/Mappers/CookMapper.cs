using DTO;
using Entities;

namespace BLL.Implementation.Mappers
{
    public static class CookMapper
    {
        public static Cook ToEntity(this CookDTO cookDto)
        {
            return new Cook
            {
                Name = cookDto.Name,
                Surname = cookDto.Surname,
                Efficiency = cookDto.Efficiency,
                Id = cookDto.Id,
                SpecializationId = cookDto.SpecializationDto.Id,
                WhenIsFree = cookDto.WhenIsFree

            };
        }

        public static CookDTO ToDto(this Cook cook)
        {
            return new CookDTO
            {
                Name = cook.Name,
                Surname = cook.Surname,
                Efficiency = cook.Efficiency,
                Id = cook.Id,
               SpecializationDto = cook.Specialization.ToDto(),
                WhenIsFree = cook.WhenIsFree
            };
        }
    }
}