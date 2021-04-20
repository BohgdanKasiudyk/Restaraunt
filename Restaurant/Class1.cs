using System;
using DAL.Implementation.EnFr;
using Entities;

namespace Restaurant
{
    class Class1
    {
        static void main(string[] args)
        {
            RestaurantDbContext cool = new RestaurantDbContext();
            cool.Dishes.Add(new Dish("fnlknflk"));
            cool.SaveChanges();
        }
    }
}