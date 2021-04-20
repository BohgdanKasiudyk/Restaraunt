using DTO;
using Entities;

namespace BLL.Implementation.Mappers
{
    public static class SpecializationMappers
    {
        public static SpecializationDTO ToDto(this Specialization specialization)
        {
            return new SpecializationDTO
            {
                Name = specialization.Name,
                Id = specialization.Id
            };
        }

        public static Specialization ToEntity(this SpecializationDTO specializationDto)
        {
            return new Specialization
            {
                Name = specializationDto.Name,
                Id = specializationDto.Id
            };
        }
    }
}