using System.Collections.Generic;

namespace Mvc1VaccinDemo.ViewModels
{
    public class VaccinIndexViewModel : BaseViewModel
    {
        public string q { get; set; }
        public List<VaccinViewModel> Vacciner { get; set; } = new List<VaccinViewModel>();
    }
}