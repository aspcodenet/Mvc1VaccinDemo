using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Mvc1VaccinDemo.ViewModels
{
    public class VaccineringsFasEditViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

    }
}