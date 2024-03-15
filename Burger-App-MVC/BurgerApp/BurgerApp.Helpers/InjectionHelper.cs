using BurgerApp.DataAccess;
using BurgerApp.DataAccess.Implementations;
using BurgerApp.Domain.Models;
using BurgerApp.Services.Implementations;
using BurgerApp.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BurgerApp.Helpers
{
    public static class InjectionHelper
    {
        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IRepository<Burger>, BurgerRepository>();

        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IBurgerService, BurgerService>();
        }
    }
}
