using System;
using RestaurantConsole.Abstraction;

namespace RestaurantConsole.Impementation
{
    public class DataReader : IDataReader
    {
        public int GetDishId()
        {
            Console.Write("Input dish Id: ");
            return Convert.ToInt32(Console.ReadLine());

        }

        public int GetConsoleNumber()
        {
            Console.Write("Select number: ");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}