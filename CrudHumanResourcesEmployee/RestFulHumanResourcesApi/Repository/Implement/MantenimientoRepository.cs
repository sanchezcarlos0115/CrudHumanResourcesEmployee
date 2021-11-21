using Microsoft.EntityFrameworkCore;
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
        public List<PersonaDto> ConsultarEmpleados()
        {

            var ObjResponse = dbcontext.Persona.FromSqlRaw("exec HumanResources.uspObtenerEmpleados")
                                            .AsEnumerable().ToList();

            if (ObjResponse is null || !ObjResponse.Any())
            {
                throw new ApplicationException("ConsultarPersonas::No existen datos para mostrar");

            }

            return ObjResponse;
        }

        #endregion Personas

    }
}
