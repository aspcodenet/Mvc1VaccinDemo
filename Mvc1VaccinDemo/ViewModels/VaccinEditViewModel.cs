using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mvc1VaccinDemo.ViewModels
{
    public class VaccinEditViewModel
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Supplier { get; set; }
        [MaxLength(50)]
        public string Namn { get; set; }
        public DateTime? EuOkStatus { get; set; }
        //

        public int Type { get; set; }

        public List<SelectListItem> Types { get; set; } = new List<SelectListItem>();


        [Required]
        [MaxLength(1000)]
        public string Comment { get; set; }
        
        [Range(1,1000000)]// 
        public int AntalDoser { get; set; }
    }
}