using System;
using DAL.Implementation.EnFr;
using Entities;

namespace Res
{
    class Program
    {
        static void Main(string[] args)
        {
            RestaurantDbContext cool = new RestaurantDbContext();
            cool.Specializations.Add(new Specialization("fnlknflk"));
            cool.SaveChanges();
        }
    }
}