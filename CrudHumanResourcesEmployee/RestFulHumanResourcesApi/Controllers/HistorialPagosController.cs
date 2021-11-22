using Microsoft.AspNetCore.Http;
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
    public class HistorialPagosController : ControllerBase
    {
        private readonly IMantenimientoServices serv;
        public HistorialPagosController(IMantenimientoServices serv)
        {
            this.serv = serv;
        }

        /// <summary>
        /// Obtiene todos los historiales de pagos registrados
        /// </summary>
        /// <returns>Listado de historial pagos</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<HistorialPagoType>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetHistorialPagos()
        {
            var lstReg = serv.ConsultarHistorialPagosFull();
            return Ok(lstReg);
        }




    }
}
