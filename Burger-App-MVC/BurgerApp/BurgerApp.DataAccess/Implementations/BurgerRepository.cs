using BurgerApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DataAccess.Implementations
{
    public class BurgerRepository : IRepository<Burger>
    {
        public void DeleteById(int id)
        {
            Burger burger = StaticDb.Burgers.FirstOrDefault(x => x.Id == id);
            if (burger == null)
            {
                throw new Exception($"Burger with id {id} was not found!");
            }
            StaticDb.Burgers.Remove(burger);
        }

        public List<Burger> GetAll()
        {
            return StaticDb.Burgers;
        }

        public Burger GetById(int id)
        {
            Burger burger = StaticDb.Burgers.FirstOrDefault(x => x.Id == id);
            if (burger == null)
            {
                throw new Exception($"Burger with id {id} was not found!");
            }
            return burger;
        }

        public int Insert(Burger entity)
        {
            entity.Id = StaticDb.Burgers.Count() + 1;
            StaticDb.Burgers.Add(entity);
            return entity.Id;
        }

        public void Update(Burger entity)
        {
            Burger burgerDb = StaticDb.Burgers.FirstOrDefault(x => x.Id == entity.Id);
            if (burgerDb == null)
            {
                throw new Exception($"Burger with id {entity.Id} was not found!");
            }

            int index = StaticDb.Burgers.FindIndex(x => x.Id == entity.Id);

            StaticDb.Burgers[index] = entity;
        }
    }
}
