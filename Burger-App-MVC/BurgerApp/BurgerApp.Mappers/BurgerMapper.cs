using BurgerApp.Domain.Models;
using BurgerApp.ViewModels.BurgerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Mappers
{
    public static class BurgerMapper
    {
        public static BurgerViewModel ToBurgerViewModel(Burger burger)
        {
            return new BurgerViewModel
            {
                Id = burger.Id,
                BurgerName = burger.Name,
                Price = burger.Price,
                IsVegetarian = burger.IsVegetarian,
                IsVegan = burger.IsVegan,
                HasFries = burger.HasFries
            };
        }

        public static Burger ToBurger(BurgerViewModel burgerViewModel)
        {
            return new Burger
            {
                Id = burgerViewModel.Id,
                Name = burgerViewModel.BurgerName,
                Price = burgerViewModel.Price,
                IsVegetarian = burgerViewModel.IsVegetarian,
                IsVegan = burgerViewModel.IsVegan,
                HasFries = burgerViewModel.HasFries
            };
        }
    }
}
