using BurgerApp.Services.Interfaces;
using BurgerApp.ViewModels.BurgerViewModels;
using BurgerApp.ViewModels.OrderViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.Controllers
{
    public class OrderController : Controller
    {
        public IOrderService _orderService;
        public IBurgerService _burgerService;

        public OrderController(IOrderService orderService, IBurgerService burgerService)
        {
            _orderService = orderService;
            _burgerService = burgerService;
        }

        public IActionResult Index()
        {
            List<OrderViewModel> viewModels = _orderService.GetAllOrders();

            return View(viewModels);

        }

        public IActionResult DeleteOrder(int id)
        {
            _orderService.DeleteOrder(id);
            return RedirectToAction("Index");
        }


        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrder(OrderViewModel orderViewModel)
        {
            try
            {
                _orderService.CreateOrder(orderViewModel);
                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("GeneralError");
            }

        }

        public IActionResult EditOrder(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditOrder(OrderViewModel orderViewModel)
        {
            try
            {
                _orderService.UpdateOrder(orderViewModel);
                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("GeneralError");
            }
        }

    }
}
