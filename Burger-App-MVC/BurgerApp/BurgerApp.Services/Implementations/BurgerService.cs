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
    public class BurgerService : IBurgerService
    {
        private IRepository<Burger> _burgerRepository;

        public BurgerService(IRepository<Burger> burgerRepository)
        {
            _burgerRepository = burgerRepository;
        }

        public List<BurgerViewModel> GetAllBurgers()
        {
            List<Burger> burgers = _burgerRepository.GetAll();
            List<BurgerViewModel> burgerViewModels = burgers.Select(BurgerMapper.ToBurgerViewModel).ToList();
            return burgerViewModels;
        }

        public BurgerViewModel GetBurgerById(int id)
        {
            Burger burger = _burgerRepository.GetById(id);
            return BurgerMapper.ToBurgerViewModel(burger);
        }


        public void AddBurger(BurgerViewModel burgerViewModel)
        {
            Burger burger = BurgerMapper.ToBurger(burgerViewModel);
            int insertedId = _burgerRepository.Insert(burger);
            burgerViewModel.Id = insertedId;
        }


        public void DeleteBurger(int id)
        {
            Burger existingBurger = _burgerRepository.GetById(id);
            if (existingBurger == null)
            {
                throw new Exception($"Burger with id {id} was not found!");
            }

            _burgerRepository.DeleteById(id);
        }


        public void UpdateBurger(BurgerViewModel burgerViewModel)
        {
            Burger existingBurger = _burgerRepository.GetById(burgerViewModel.Id);
            if (existingBurger == null)
            {
                throw new Exception($"Burger with id {burgerViewModel.Id} was not found!");
            }

            Burger updatedBurger = BurgerMapper.ToBurger(burgerViewModel);
            _burgerRepository.Update(updatedBurger);
        }
    }
}
