using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestFulHumanResourcesApi.Model
{
    public class ResultadoProceso
    {
        [Key]
        public int Resultado
        {
            get; set;
        }
    }
}
