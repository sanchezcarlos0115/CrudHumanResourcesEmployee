using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HumanResourcesWebApp.Models
{
    public class HistorialPagoType
    {
        [Required]
        public int BusinessEntityId { get; set; }

        [Required]
        public DateTime RateChangeDate { get; set; }
        [Required]
        public decimal Rate { get; set; }
        [Required]
        public short PayFrequency { get; set; }
    }
}