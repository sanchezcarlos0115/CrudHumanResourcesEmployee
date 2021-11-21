using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestFulHumanResourcesApi.Repository.Dto
{
    public class PersonaDto
    {
        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }

        [Column("NameDescription")]
        public string NameDescription { get; set; }
    }
}
