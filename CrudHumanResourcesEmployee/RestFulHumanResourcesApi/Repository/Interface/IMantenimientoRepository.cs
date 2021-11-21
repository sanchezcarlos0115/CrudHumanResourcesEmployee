using RestFulHumanResourcesApi.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestFulHumanResourcesApi.Repository.Interface
{
    public interface IMantenimientoRepository
    {

        List<PersonaDto> ConsultarPersonas();
        List<PersonaDto> ConsultarEmpleadosLight();
    }
}
