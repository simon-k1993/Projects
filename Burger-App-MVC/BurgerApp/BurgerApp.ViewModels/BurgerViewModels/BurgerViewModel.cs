using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.ViewModels.BurgerViewModels
{
    public class BurgerViewModel
    {
        public int Id { get; set; }
        public string BurgerName { get; set; }
        public decimal Price { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsVegan { get; set; }
        public bool HasFries { get; set; }

    }
}
