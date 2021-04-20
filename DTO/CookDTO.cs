using System;

namespace DTO
{
    public class CookDTO : BaseDTO<int>
    { 
        public string Name { get; set; }
        public string Surname { get; set; }
        public  double Efficiency { get; set; }
        public SpecializationDTO SpecializationDto { get; set; }
        public DateTime WhenIsFree { get; set; }
    }
}