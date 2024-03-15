using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BurgerApp.ViewModels.OrderViewModels
{
    public class OrderFormViewModel
    {

        [Display(Name = "Fullname")]
        public string FullName { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Is Delivered")]
        public bool IsDelivered { get; set; }

        [Display(Name = "Burger Name")]
        public string BurgerName { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }
        public int Id { get; set; }
    }
}
