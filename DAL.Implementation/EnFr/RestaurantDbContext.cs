using System;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementation.EnFr
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Cook> Cooks { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<DishOrder> DishOrders { get; set; }

        

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"database = RestaurantDb; Integrated Security=true;");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specialization>().HasData(
                new Specialization[]
                {
                    new Specialization { Id= 1, Name = "Salad"},
                    new Specialization {  Id =2,Name = "Meat"}
                }
            );
            modelBuilder.Entity<Cook>().HasData(
                new Cook[]
                {
                    new Cook {  Id = 1 , Name = "Jo", Surname = "Cook", SpecializationId = 1, Efficiency = 0},
                    new Cook { Id = 2,Name = "Cook", Surname = "Cook", Efficiency = 2, SpecializationId = 2}
                }
            );

            modelBuilder.Entity<Dish>().HasData(
                new Dish[]
                {
                    new Dish
                    {
                         Id = 1,Name = "Salad", Price = 100, SpecializationId = 1, Weight = 3,
                        CookingTime = new TimeSpan(0, 20, 0)
                    },
                    
                    new Dish
                    {
                      Id = 2,Name = "Meat", Price = 100, SpecializationId = 2, Weight = 3,
                    CookingTime = new TimeSpan(0, 20, 0)
                    }
                }

            );

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient[]
                {
                    new Ingredient
                    {
                        Id = 1, 
                        Name = "Salad"
                         
                    },
                    new Ingredient
                    {
                        Id = 2, 
                        Name = "Meat"
                         
                    }
                }
            );

            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient[]
                {
                    new DishIngredient
                    {  
                        Id=1, DishId = 1, IngredientId = 1
                    },
                    
                    new DishIngredient
                    {
                        Id=2,IngredientId = 2, DishId = 2
                    }
                }
            );

        }

        
    }
}