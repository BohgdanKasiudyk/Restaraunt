using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Cook : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public  double Efficiency { get; set; }
        public int SpecializationId { get; set; }
        public virtual Specialization Specialization { get; set; }
        
        [Column(TypeName = "datetime2")]
        public DateTime WhenIsFree { get; set; }

        public Cook()
        {
        }
    }
}