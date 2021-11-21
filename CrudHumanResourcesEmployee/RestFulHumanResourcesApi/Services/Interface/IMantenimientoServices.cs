using RestFulHumanResourcesApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestFulHumanResourcesApi.Services.Interface
{
    public interface IMantenimientoServices
    {
        List<PersonaType> ConsultarPermiso();
        List<PersonaType> ConsultarEmpleados();
    }
}
