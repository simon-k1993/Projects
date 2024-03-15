using BurgerApp.Services.Interfaces;
using BurgerApp.ViewModels.BurgerViewModels;
using BurgerApp.ViewModels.OrderViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.Controllers
{
    public class BurgerController : Controller
    {
        public IOrderService _orderService;
        public IBurgerService _burgerService;

        public BurgerController(IOrderService orderService, IBurgerService burgerService)
        {
            _orderService = orderService;
            _burgerService = burgerService;
        }

        public IActionResult Index()
        {
            List<BurgerViewModel> viewModels = _burgerService.GetAllBurgers();

            return View(viewModels);

        }


        public IActionResult AddBurger()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBurger(BurgerViewModel burgerViewModel)
        {
            try
            {
                _burgerService.AddBurger(burgerViewModel);
                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("GeneralError");
            }

        }

        public IActionResult EditBurger(int id)
        {
            BurgerViewModel burger = _burgerService.GetBurgerById(id);
            if (burger == null)
            {
                return View("GeneralError");
            }

            BurgerFormViewModel burgerFormViewModel = new BurgerFormViewModel
            {
                Id = burger.Id,
                BurgerName = burger.BurgerName,
                Price = burger.Price,
                IsVegetarian = burger.IsVegetarian,
                IsVegan = burger.IsVegan,
                HasFries = burger.HasFries
            };

            return View(burgerFormViewModel);
        }

        [HttpPost]
        public IActionResult EditBurger(BurgerViewModel burgerViewModel)
        {
            try
            {
                _burgerService.UpdateBurger(burgerViewModel);
                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("GeneralError");
            }
        }

        public IActionResult DeleteBurger(int id)
        {
            _burgerService.DeleteBurger(id);
            return RedirectToAction("Index");
        }
    }
}
