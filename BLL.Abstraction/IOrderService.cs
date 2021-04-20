using System.Collections.Generic;
using System.Linq;
using DTO;

namespace BLL.Abstraction
{
    public interface IOrderService
    {
        OrderDTO CreateOrder(IEnumerable<DishDTO> dishes);
        
        
    }
}