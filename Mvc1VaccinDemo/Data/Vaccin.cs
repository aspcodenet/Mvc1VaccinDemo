using System;
using System.ComponentModel.DataAnnotations;

namespace Mvc1VaccinDemo.Data
{


    public class Vaccin
    {
        public int Id { get; set; }

        public enum VaccinType
        {
            Unknown,
            mRNA,
            Vector
        }

        [MaxLength(100)]
        public string Supplier { get; set; }
        [MaxLength(50)]
        public string Namn { get; set; }
        public DateTime ?EuOkStatus { get; set; } //Om NULL = inte godkänt  2020-01-07
        public VaccinType Type { get; set; }
    }
}