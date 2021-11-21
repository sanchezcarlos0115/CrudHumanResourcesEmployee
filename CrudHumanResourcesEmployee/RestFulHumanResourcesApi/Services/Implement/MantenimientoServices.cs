﻿using RestFulHumanResourcesApi.Model;
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

        public List<PersonaType> ConsultarPermiso()
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

        public List<PersonaType> ConsultarEmpleados()
        {
            var objResp = Repositorio.ConsultarEmpleados();
            var lstPersonaType = (from item in objResp
                                  select new PersonaType
                                  {
                                      BusinessEntityId = item.BusinessEntityId,
                                      NameDescription = item.NameDescription
                                  }).ToList();

            return lstPersonaType;
        }

    }
}
