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

       /// <summary>
       /// Metodo que obtiene un historial de pago por el codigo y fecha cambio
       /// </summary>
       /// <param name="id"></param>
       /// <param name="rateChangeDate"></param>
       /// <returns></returns>
        [HttpGet("{id:int}/{rateChangeDate:DateTime}", Name = "GetHistorialPago")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HistorialPagoType))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetHistorialPago(int id,DateTime rateChangeDate)
        {
            var histpago = serv.ConsultarHistorialPagoPorId(id,rateChangeDate);
            if (histpago.BusinessEntityId == 0)
            {
                return NotFound();
            }
            return Ok(histpago);
        }


        /// <summary>
        /// Metodo que guarda el historial de pago
        /// </summary>
        /// <param name="hist">objeto historial de pago</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PostEmpleado([FromBody] HistorialPagoType hist)
        {
            if (hist == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var codigo = serv.GuardarHistorialPago(hist);

            return CreatedAtRoute("GetHistorialPago", new { id = codigo, rateChangeDate = hist.RateChangeDate }, hist);
        }


      /// <summary>
      /// Metodo que actualiza un historial de pago de empleado
      /// </summary>
      /// <param name="id">id empleado</param>
      /// <param name="rateChangeDate">fecha de cambio</param>
      /// <param name="histpago">objeto historial de pago</param>
      /// <returns></returns>
        [HttpPut("{id:int}/{rateChangeDate:DateTime}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult PutEmpleado(int id,DateTime rateChangeDate, [FromBody] HistorialPagoType histpago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != histpago.BusinessEntityId)
            {
                return BadRequest();
            }
            if (rateChangeDate != histpago.RateChangeDate)
            {
                return BadRequest();
            }

            serv.ActualizarHistorialPago(histpago);

            return StatusCode(StatusCodes.Status204NoContent);
        }


        /// <summary>
        /// Metodo que elimina el historial de pago
        /// </summary>
        /// <param name="id">id empleado</param>
        /// <param name="rateChangeDate"> fecha cambio</param>
        /// <returns></returns>
        [HttpDelete("{id:int}/{rateChangeDate:DateTime}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteHistorialPagos(int id,DateTime rateChangeDate)
        {
            var histpago = serv.ConsultarHistorialPagoPorId(id,rateChangeDate);
            if (histpago == null)
            {
                return NotFound();
            }
           
            var codigo = serv.EliminarHistorialPago(id, rateChangeDate);
            return Ok(codigo);
        }

       


    }
}
