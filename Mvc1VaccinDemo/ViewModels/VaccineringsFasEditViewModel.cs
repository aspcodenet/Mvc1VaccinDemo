using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Data.SqlClient;

namespace Mvc1VaccinDemo.ViewModels
{
    public class VaccineringsFasEditViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Skriv in ett namn dumsnut")]
        [MaxLength(30, ErrorMessage = "Maxlängd uppnådd")]
        [MinLength(2, ErrorMessage = "Du har völ ett längre namn än så???")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Skriv in kommentar tack")]
        public string Comment { get; set; }





        [EmailAddress]
        public string Epost { get; set; }

        [EmailAddress]
        [Compare("Epost", ErrorMessage = "Måste vara samma som EMail")]
        public string Epostigen { get; set; }



        [Range(2010,2030,ErrorMessage = "Mata in ett tal mellan 2010 och 2030 tack")]
        public int Year { get; set; }

        [Range(1,12)]
        public int Month { get; set; }

        [Range(1, 31)]
        public int Day { get; set; }

    }
}