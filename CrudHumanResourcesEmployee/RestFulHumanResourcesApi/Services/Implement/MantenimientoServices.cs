using RestFulHumanResourcesApi.Model;
using RestFulHumanResourcesApi.Repository.Dto;
using RestFulHumanResourcesApi.Repository.Interface;
using RestFulHumanResourcesApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestFulHumanResourcesApi.Services.Implement
{
    public class MantenimientoServices : IMantenimientoServices
    {
        readonly IMantenimientoRepository Repositorio;

        public MantenimientoServices(IMantenimientoRepository Repositorio)
        {
            this.Repositorio = Repositorio;
        }

        #region Personas
        public List<PersonaType> ConsultarPersonas()
        {
            var objResp = Repositorio.ConsultarPersonas();
            var lstPersonaType = (from item in objResp
                                select new PersonaType
                                {
                                     BusinessEntityId = item.BusinessEntityId,
                                      NameDescription = item.NameDescription
                                }).ToList();

            return lstPersonaType;
        }

        public List<PersonaType> ConsultarEmpleadosLight()
        {
            var objResp = Repositorio.ConsultarEmpleadosLight();
            var lstPersonaType = (from item in objResp
                                  select new PersonaType
                                  {
                                      BusinessEntityId = item.BusinessEntityId,
                                      NameDescription = item.NameDescription
                                  }).ToList();

            return lstPersonaType;
        }

        #endregion

        #region Empleados

        public List<EmpleadoType> ConsultarEmpleadosFull()
        {
            var objResp = Repositorio.ConsultarEmpleadosFull();
            var lstEmpleadoType = (from item in objResp
                                  select new EmpleadoType
                                  {
                                      BusinessEntityId = item.BusinessEntityId,
                                      NameDescription = item.NameDescription,
                                      NationalIdNumber = item.NationalIdNumber,
                                      LoginId = item.LoginId,
                                      JobTitle = item.JobTitle,
                                      BirthDate = item.BirthDate,
                                      MaritalStatus = item.MaritalStatus,
                                      Gender = item.Gender,
                                      HireDate = item.HireDate,
                                      VacationHours = item.VacationHours,
                                      SickLeaveHours = item.SickLeaveHours
                                  }).ToList();

            return lstEmpleadoType;
        }


        public EmpleadoType ConsultarEmpleadoPorId(int id)
        {
            var objResp = Repositorio.ConsultarEmpleadoPorId(id);
            if (objResp !=null)
            {
                return new EmpleadoType
                {
                    BusinessEntityId = objResp.BusinessEntityId,
                    NameDescription = objResp.NameDescription,
                    NationalIdNumber = objResp.NationalIdNumber,
                    LoginId = objResp.LoginId,
                    JobTitle = objResp.JobTitle,
                    BirthDate = objResp.BirthDate,
                    MaritalStatus = objResp.MaritalStatus,
                    Gender = objResp.Gender,
                    HireDate = objResp.HireDate,
                    VacationHours = objResp.VacationHours,
                    SickLeaveHours = objResp.SickLeaveHours
                };
            }
            return new EmpleadoType();
        }


        public int GuardarEmpleado(EmpleadoType obj)
        {

            var objEmpleadodto =  new EmpleadoDto
            {
                BusinessEntityId = obj.BusinessEntityId,
                NameDescription = obj.NameDescription,
                NationalIdNumber = obj.NationalIdNumber,
                LoginId = obj.LoginId,
                JobTitle = obj.JobTitle,
                BirthDate = obj.BirthDate,
                MaritalStatus = obj.MaritalStatus,
                Gender = obj.Gender,
                HireDate = obj.HireDate,
                VacationHours = obj.VacationHours,
                SickLeaveHours = obj.SickLeaveHours
            };

            var objResp = Repositorio.GuardarEmpleado(objEmpleadodto);
           
            return objResp;
        }

        #endregion

    }
}
