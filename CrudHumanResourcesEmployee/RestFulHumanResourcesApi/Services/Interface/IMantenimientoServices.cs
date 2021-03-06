using RestFulHumanResourcesApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestFulHumanResourcesApi.Services.Interface
{
    public interface IMantenimientoServices
    {
        #region Personas
        List<PersonaType> ConsultarPersonas();
        List<PersonaType> ConsultarEmpleadosLight();
        #endregion

        #region Empleados
        List<EmpleadoType> ConsultarEmpleadosFull();
        EmpleadoType ConsultarEmpleadoPorId(int id);
        int GuardarEmpleado(EmpleadoType obj);
        int ActualizarEmpleado(EmpleadoType obj);
        int EliminarEmpleado(int id);

        #endregion

        #region Historial Pagos
        List<HistorialPagoType> ConsultarHistorialPagosFull();
        HistorialPagoType ConsultarHistorialPagoPorId(int id, DateTime rateChangeDate);
        int GuardarHistorialPago(HistorialPagoType obj);
        int ActualizarHistorialPago(HistorialPagoType obj);
        int EliminarHistorialPago(int id, DateTime rateChangeDate);

        #endregion


    }
}
