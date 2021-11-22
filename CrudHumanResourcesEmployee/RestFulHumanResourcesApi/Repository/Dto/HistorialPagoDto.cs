using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestFulHumanResourcesApi.Repository.Dto
{
    public class HistorialPagoDto
    {
        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }

        [Column("RateChangeDate")]
        public DateTime RateChangeDate { get; set; }
        [Column("Rate")]
        public decimal Rate { get; set; }
        [Column("PayFrequency")]
        public byte PayFrequency { get; set; }
    }
}
