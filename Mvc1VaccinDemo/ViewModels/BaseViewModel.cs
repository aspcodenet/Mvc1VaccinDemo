using System.Collections.Generic;

namespace Mvc1VaccinDemo.ViewModels
{
    public class BaseViewModel
    {
        public List<FasViewModel> AllaFaser { get; set; } = new List<FasViewModel>();

        public class FasViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }


    }
}