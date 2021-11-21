using Microsoft.AspNetCore.Mvc;
using RestFulHumanResourcesApi.Model;
using RestFulHumanResourcesApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RestFulHumanResourcesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IMantenimientoServices serv;

        public PersonaController(IMantenimientoServices serv)
        {
            this.serv = serv;
        }

        /// <summary>
        /// Consulta las 200 primeras personas que no se encuentran registradas
        /// como empleados
        /// </summary>
        /// <returns>Listado de personas</returns>
        //[HttpGet("persona")]
        [HttpGet]
        [ProducesResponseType(200,Type = typeof(List<PersonaType>))]
        [ProducesResponseType(400)]
        public IActionResult GetPersonas()
        {
            var lstReg = serv.ConsultarPersonas();
            return Ok(lstReg);
        }

        /// <summary>
        /// Consulta empleados registrados para ser utilizados en el crud de
        /// historial de pago
        /// </summary>
        /// <returns>retorna listado de empleados</returns>
        [HttpGet("empleados")]
        [ProducesResponseType(200, Type = typeof(List<PersonaType>))]
        [ProducesResponseType(400)]
        public IActionResult GetEmpleadosLight()
        {

            var lstReg = serv.ConsultarEmpleadosLight();
            return Ok(lstReg);
        }

    }
}
