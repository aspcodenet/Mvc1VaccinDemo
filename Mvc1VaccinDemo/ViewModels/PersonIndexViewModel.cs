using System.Collections.Generic;

namespace Mvc1VaccinDemo.ViewModels
{
    public class PersonIndexViewModel : BaseViewModel

    {
    public string q { get; set; }
    public List<PersonViewModel> Personer { get; set; } = new List<PersonViewModel>();
    }
}