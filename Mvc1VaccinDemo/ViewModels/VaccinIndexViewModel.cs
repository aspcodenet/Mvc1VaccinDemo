using System.Collections.Generic;

namespace Mvc1VaccinDemo.ViewModels
{
    public class VaccinIndexViewModel
    {
        public string SearchWord { get; set; }
        public List<VaccinViewModel> Vacciner { get; set; } = new List<VaccinViewModel>();
    }

    public class VaccinViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Supplier { get; set; }
    }
}