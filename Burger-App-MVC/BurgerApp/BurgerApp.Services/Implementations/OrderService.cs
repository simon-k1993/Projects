using BurgerApp.DataAccess;
using BurgerApp.DataAccess.Implementations;
using BurgerApp.Domain.Models;
using BurgerApp.Mappers;
using BurgerApp.Services.Interfaces;
using BurgerApp.ViewModels.BurgerViewModels;
using BurgerApp.ViewModels.OrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> _orderRepository;
        private IRepository<Burger> _burgerRepository;

        public OrderService(IRepository<Order> orderRepository, IRepository<Burger> burgerRepository)
        {
            _orderRepository = orderRepository;
            _burgerRepository = burgerRepository;
        }

        public List<OrderViewModel> GetAllOrders()
        {
            List<Order> orders = _orderRepository.GetAll();
            List<OrderViewModel> orderViewModels = orders.Select(order => OrderMapper.ToOrderViewModel(order)).ToList();
            return orderViewModels;
        }

        public OrderViewModel GetOrderById(int id)
        {
            Order order = _orderRepository.GetById(id);
            if (order == null)
            {

                throw new Exception($"Order with id {id} was not found!");
            }

            return OrderMapper.ToOrderViewModel(order);
        }



        public void DeleteOrder(int id)
        {
            Order existingOrder = _orderRepository.GetById(id);
            if (existingOrder == null)
            {
                throw new Exception($"Order with id {id} was not found!");
            }

            _orderRepository.DeleteById(id);
        }

        public void CreateOrder(OrderViewModel orderViewModel)
        {
            if (orderViewModel == null)
            {
                throw new Exception("Model cannot be null");
            }

            Burger burgerDb = StaticDb.Burgers.FirstOrDefault(x => x.Name == orderViewModel.BurgerName);

            if (burgerDb == null)
            {
                throw new Exception($"The Burger was not found");
            }

            Order order = OrderMapper.ToOrder(orderViewModel);
            int insertedId = _orderRepository.Insert(order);
            orderViewModel.Id = insertedId;
        }

        public void UpdateOrder(OrderViewModel orderViewModel)
        {
            Order existingOrder = _orderRepository.GetById(orderViewModel.Id);
            if (existingOrder == null)
            {
                throw new Exception($"Order with id {orderViewModel.Id} was not found!");
            }

            Order updatedOrder = OrderMapper.ToOrder(orderViewModel);
            _orderRepository.Update(updatedOrder);
        }
    }
}
