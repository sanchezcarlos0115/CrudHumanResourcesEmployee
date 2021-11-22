using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HumanResourcesWebApp.Models
{
    public class HistorialPagoType
    {
        private const string FORMATO_FECHA = "dd/MM/yyyy";

        [Required]
        public int BusinessEntityId { get; set; }

        [Required]
        public DateTime RateChangeDate { get; set; }

        public string RateChangeDateInen
        {
            get
            {
                if (RateChangeDate.Equals(DateTime.MinValue))
                {
                    return string.Empty;
                }
                else
                {
                    return RateChangeDate.ToString(FORMATO_FECHA);
                }
            }
        }


        [Required]
        public decimal Rate { get; set; }
        [Required]
        public short PayFrequency { get; set; }

        public string PayFrequencyFormat
        {
            get
            {
                if (PayFrequency.ToString().Equals("1"))
                {
                    return "Mensual";
                }
                else
                {
                    return "Quincenal"; 
                }
            }
        }


    }
}