using RestFulHumanResourcesApi.Model;
using RestFulHumanResourcesApi.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestFulHumanResourcesApi.Repository.Interface
{
    public interface IMantenimientoRepository
    {
        #region Personas
        List<PersonaDto> ConsultarPersonas();
        List<PersonaDto> ConsultarEmpleadosLight();

        #endregion

        #region Empleados
        List<EmpleadoDto> ConsultarEmpleadosFull();
        EmpleadoDto ConsultarEmpleadoPorId(int id);
        int GuardarEmpleado(EmpleadoDto obj);
        int ActualizarEmpleado(EmpleadoDto obj);
        int EliminarEmpleado(int id);

        #endregion

        #region HistorialPagos

        List<HistorialPagoDto> ConsultarHistorialPagosFull();
        HistorialPagoDto ConsultarHistorialPagoPorId(int id, DateTime rateChangeDate);
        int GuardarHistorialPago(HistorialPagoDto obj);
        int ActualizarHistorialPago(HistorialPagoDto obj);
        int EliminarHistorialPago(int Id, DateTime RateChangeDate);


        #endregion

    }
}
