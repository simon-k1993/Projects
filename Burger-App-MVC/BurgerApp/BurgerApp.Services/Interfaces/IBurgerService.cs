using BurgerApp.ViewModels.BurgerViewModels;
using BurgerApp.ViewModels.OrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Services.Interfaces
{
    public interface IBurgerService
    {
        List<BurgerViewModel> GetAllBurgers();
        BurgerViewModel GetBurgerById(int id);
        void AddBurger(BurgerViewModel burgerViewModel);
        void UpdateBurger(BurgerViewModel burgerViewModel);
        void DeleteBurger(int id);
    }
}
