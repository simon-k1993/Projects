using BurgerApp.Domain.Models;
using BurgerApp.ViewModels.BurgerViewModels;
using BurgerApp.ViewModels.OrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Mappers
{
    public static class OrderMapper
    {
        public static OrderViewModel ToOrderViewModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                FullName = order.FullName,
                Address = order.Address,
                IsDelivered = order.IsDelivered,
                BurgerName = order.Burger.Name,
                Location = order.Location
            };
        }

        public static Order ToOrder(OrderViewModel orderViewModel)
        {
            return new Order
            {
                Id = orderViewModel.Id,
                FullName = orderViewModel.FullName,
                Address = orderViewModel.Address,
                IsDelivered = orderViewModel.IsDelivered,
                Burger = new Burger
                {
                    Name = orderViewModel.BurgerName
                },
                Location = orderViewModel.Location
            };
        }

    }
}
