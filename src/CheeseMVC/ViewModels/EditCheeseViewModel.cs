using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Models;

namespace CheeseMVC.ViewModels
{
    public class EditCheeseViewModel : AddCheeseViewModel
    {
        public int CheeseId { get; set; }

        public EditCheeseViewModel(IEnumerable<CheeseCategory> categories) : base(categories)
        {
        }

        public EditCheeseViewModel() { }

    }
}
