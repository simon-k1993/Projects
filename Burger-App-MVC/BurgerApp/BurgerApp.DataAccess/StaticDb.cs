using BurgerApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DataAccess
{
    public class StaticDb
    {
        public static List<Burger> Burgers = new List<Burger>
        {
            new Burger()
            {
               Id = 1,
               Name = "Spicy Chicken",
               Price = 180,
               IsVegetarian = false,
               IsVegan = false,
               HasFries = true
            },

            new Burger()
            {
               Id = 2,
               Name = "Bacon Burger",
               Price = 250,
               IsVegetarian = false,
               IsVegan = false,
               HasFries = true
            },

            new Burger()
            {
               Id = 3,
               Name = "Special Burger",
               Price = 400,
               IsVegetarian = false,
               IsVegan = false,
               HasFries = true
            },

            new Burger()
            {
               Id = 4,
               Name = "Vege Burger",
               Price = 270,
               IsVegetarian = true,
               IsVegan = false,
               HasFries = false
            },

        };

        public static List<Order> Orders = new List<Order>
        {
            new Order
            {
                Id = 1,
                BurgerId = 1,
                FullName = "Toso Malerot",
                Address = "Adresa broj 1",
                IsDelivered = false,
                Burger = Burgers.FirstOrDefault(x => x.Id == 1),
                Location = "Skopje"
            },

            new Order
            {
                Id = 2,
                BurgerId = 2,
                FullName = "Cacko Konopiski",
                Address = "Adresa broj 2",
                IsDelivered = true,
                Burger = Burgers.FirstOrDefault(x => x.Id == 2),
                Location = "Kavadarci"
            },

            new Order
            {
                Id = 3,
                BurgerId = 3,
                FullName = "Mile Panika",
                Address = "Adresa broj 3",
                IsDelivered = true,
                Burger = Burgers.FirstOrDefault(x => x.Id == 2),
                Location = "Bitola"
            }
        };


    }
}
