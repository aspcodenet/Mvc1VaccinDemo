using System.Collections.Generic;

namespace Mvc1VaccinDemo.ViewModels
{
    public class FaserIndexViewModel : BaseViewModel
    {
        public string q { get; set; }

        public List<FasViewModel> Faser { get; set; } = new List<FasViewModel>();

    }
}