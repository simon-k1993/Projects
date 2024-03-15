using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BurgerApp.ViewModels.BurgerViewModels
{
    public class BurgerFormViewModel
    {
        [Display(Name = "Burger name")]
        public string BurgerName { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Is Vegetarian")]
        public bool IsVegetarian { get; set; }

        [Display(Name = "Is Vegan")]
        public bool IsVegan { get; set; }

        [Display(Name = "Has Fries")]
        public bool HasFries { get; set; }
        public int Id { get; set; }
    }
}
