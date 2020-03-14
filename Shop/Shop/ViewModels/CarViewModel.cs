using Shop.Core.Entities;
using System.Collections.Generic;

namespace Shop.ViewModels
{
    public class CarViewModel
    {
        public List<Car> Cars { get; set; }
        public string CurrentCategory { get; set; }
    }
}
