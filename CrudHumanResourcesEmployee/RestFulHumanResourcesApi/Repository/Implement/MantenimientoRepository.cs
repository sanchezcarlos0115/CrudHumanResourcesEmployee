using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RestFulHumanResourcesApi.Model;
using RestFulHumanResourcesApi.Repository.Context;
using RestFulHumanResourcesApi.Repository.Dto;
using RestFulHumanResourcesApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestFulHumanResourcesApi.Repository.Implement
{
    public class MantenimientoRepository : IMantenimientoRepository
    {

        private readonly DatabaseContext dbcontext;

        public MantenimientoRepository(DatabaseContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        #region Personas
        /// <summary>
        /// Metodo consulta las personas que no estan registradas como empleados
        /// </summary>
        /// <returns>retorna las 200 primeras personas</returns>
        public List<PersonaDto> ConsultarPersonas()
        {
           
            var ObjResponse = dbcontext.Persona.FromSqlRaw("exec HumanResources.uspObtenerPersonas")
                                            .AsEnumerable().ToList();

            if (ObjResponse is null || !ObjResponse.Any())
            {
                throw new ApplicationException("ConsultarPersonas::No existen datos para mostrar");
               
            }
           
            return ObjResponse;
        }

        /// <summary>
        /// Metodo que consulta el listado de empleados registrados en la tabla
        /// Employee
        /// </summary>
        /// <returns></returns>
        public List<PersonaDto> ConsultarEmpleadosLight()
        {

            var ObjResponse = dbcontext.Persona.FromSqlRaw("exec HumanResources.uspObtenerEmpleadosLight")
                                            .AsEnumerable().ToList();

            if (ObjResponse is null || !ObjResponse.Any())
            {
                throw new ApplicationException("ConsultarPersonas::No existen datos para mostrar");

            }

            return ObjResponse;
        }

        #endregion Personas

        #region Empleados
        public List<EmpleadoDto> ConsultarEmpleadosFull()
        {

            var ObjResponse = dbcontext.Empleado.FromSqlRaw("exec HumanResources.uspObtenerEmpleadosFull")
                                            .AsEnumerable().ToList();

            if (ObjResponse is null || !ObjResponse.Any())
            {
                throw new ApplicationException("ConsultarEmpleadosFull::No existen datos para mostrar");

            }

            return ObjResponse;
        }

        public EmpleadoDto ConsultarEmpleadoPorId(int id)
        {
            var paramId = new SqlParameter("@Id", id);
            var ObjResponse = dbcontext.Empleado.FromSqlRaw("exec HumanResources.uspObtenerEmpleadoPorId @Id", paramId)
                                            .AsEnumerable().FirstOrDefault();

            return ObjResponse;
        }

        public int GuardarEmpleado(EmpleadoDto obj)
        {
           
            var BusinessEntityId = new SqlParameter("@BusinessEntityId", obj.BusinessEntityId);
            var NationalIdNumber = new SqlParameter("@NationalIdNumber", obj.NationalIdNumber);
            var LoginId = new SqlParameter("@LoginId", obj.LoginId);
            var JobTitle = new SqlParameter("@JobTitle", obj.JobTitle);
            var BirthDate = new SqlParameter("@BirthDate", obj.BirthDate);
            var MaritalStatus = new SqlParameter("@MaritalStatus", obj.MaritalStatus);
            var Gender = new SqlParameter("@Gender", obj.Gender);
            var HireDate = new SqlParameter("@HireDate", obj.HireDate);
            var VacationHours = new SqlParameter("@VacationHours", obj.VacationHours);
            var SickLeaveHours = new SqlParameter("@SickLeaveHours", obj.SickLeaveHours);
            
            try
            {
                var result = dbcontext.ResultadoProceso
                              .FromSqlRaw("exec HumanResources.usp_InsertarEmpleado @BusinessEntityId,@NationalIdNumber, @LoginId,@JobTitle,@BirthDate,@MaritalStatus,@Gender,@HireDate,@VacationHours,@SickLeaveHours",
                              BusinessEntityId, NationalIdNumber, LoginId, JobTitle, BirthDate, MaritalStatus, Gender, HireDate, VacationHours, SickLeaveHours).AsEnumerable().FirstOrDefault();

                if (result is null || result.Resultado < 1)
                {
                    throw new ApplicationException("ResultadoProceso:: No se ingreso ningun registro::");
                }

                return obj.BusinessEntityId;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("GuardarEmpleado::Exception::" + ex.Message);
            }

        }

        public int ActualizarEmpleado(EmpleadoDto obj)
        {

            var BusinessEntityId = new SqlParameter("@BusinessEntityId", obj.BusinessEntityId);
            var JobTitle = new SqlParameter("@JobTitle", obj.JobTitle);
            var BirthDate = new SqlParameter("@BirthDate", obj.BirthDate);
            var MaritalStatus = new SqlParameter("@MaritalStatus", obj.MaritalStatus);
            var Gender = new SqlParameter("@Gender", obj.Gender);
            var HireDate = new SqlParameter("@HireDate", obj.HireDate);
            var VacationHours = new SqlParameter("@VacationHours", obj.VacationHours);
            var SickLeaveHours = new SqlParameter("@SickLeaveHours", obj.SickLeaveHours);

            try
            {
                var result = dbcontext.ResultadoProceso
                              .FromSqlRaw("exec HumanResources.usp_ActualizarEmpleado @BusinessEntityId,@JobTitle,@BirthDate,@MaritalStatus,@Gender,@HireDate,@VacationHours,@SickLeaveHours",
                              BusinessEntityId, JobTitle, BirthDate, MaritalStatus, Gender, HireDate, VacationHours, SickLeaveHours).AsEnumerable().FirstOrDefault();

                if (result is null || result.Resultado < 1)
                {
                    throw new ApplicationException("ResultadoProceso:: No se pudo actualizar el registro::");
                }

                return obj.BusinessEntityId;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("ActualizarEmpleado::Exception::" + ex.Message);
            }

        }

        public int EliminarEmpleado(int id)
        {
            var Id = new SqlParameter("@Id", id);
            try
            {
                var result = dbcontext.ResultadoProceso
                              .FromSqlRaw("exec HumanResources.usp_EliminarEmpleadoPorId @Id", Id).AsEnumerable().FirstOrDefault();

                if (result is null || result.Resultado < 1)
                {
                    throw new ApplicationException("ResultadoProceso:: No se elimino ningun registro::");
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("GuardarEmpleado::Exception::" + ex.Message);
            }

        }



        #endregion

        #region HistorialPagos

        #endregion
    }
}
