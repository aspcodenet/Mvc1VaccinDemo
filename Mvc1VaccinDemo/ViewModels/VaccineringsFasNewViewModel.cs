using System.ComponentModel.DataAnnotations;

namespace Mvc1VaccinDemo.ViewModels
{
    public class VaccineringsFasNewViewModel
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string Comment { get; set; }

    }
}