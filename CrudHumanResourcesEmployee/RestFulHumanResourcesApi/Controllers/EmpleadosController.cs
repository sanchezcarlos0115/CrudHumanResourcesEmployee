using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestFulHumanResourcesApi.Model;
using RestFulHumanResourcesApi.Services.Interface;
using System.Collections.Generic;



namespace RestFulHumanResourcesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {

        private readonly IMantenimientoServices serv;
        public EmpleadosController(IMantenimientoServices serv)
        {
            this.serv = serv;
        }

        /// <summary>
        /// Obtiene todos los empleados registrados
        /// </summary>
        /// <returns>Listado de empleados</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EmpleadoType>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetEmpleados()
        {
            var lstReg = serv.ConsultarEmpleadosFull();
            return Ok(lstReg);
        }

        /// <summary>
        /// Metodo que obtiene un empleado por su id
        /// </summary>
        /// <param name="id">id de empleado</param>
        /// <returns>retorna un empleado</returns>
        [HttpGet("{id:int}",Name = "GetEmpleado")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmpleadoType))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetEmpleado(int id)
        {
            var empleado = serv.ConsultarEmpleadoPorId(id);
            if (empleado.BusinessEntityId == 0)
            {
                return NotFound();
            }
            return Ok(empleado);
        }
       
        /// <summary>
        /// Metodo que guarda un empleado
        /// </summary>
        /// <param name="empleado">objeto empleado</param>
        /// <returns>retorna el empleado nuevo</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PostEmpleado([FromBody] EmpleadoType empleado)
        {
            if (empleado == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var idEmpleado = serv.GuardarEmpleado(empleado);

            return CreatedAtRoute("GetEmpleado", new { id = idEmpleado }, empleado);
        }

        /// <summary>
        /// Metodo que actualiza un empleado
        /// </summary>
        /// <param name="id">id empleado</param>
        /// <param name="empleado">objeto empleado actualizar</param>
        /// <returns>ok</returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult PutEmpleado(int id, [FromBody] EmpleadoType empleado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empleado.BusinessEntityId)
            {
                return BadRequest();
            }

            serv.ActualizarEmpleado(empleado);

            return StatusCode(StatusCodes.Status204NoContent);
        }

        /// <summary>
        /// Metodo que inactiva un empleado
        /// </summary>
        /// <param name="id">id empleado</param>
        /// <returns>codigo empleado</returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteEmpleado(int id)
        {
            var empleado = serv.ConsultarEmpleadoPorId(id);
            if (empleado == null)
            {
                return NotFound();
            }
            var codigo = serv.EliminarEmpleado(id);
            return Ok(codigo);
        }
    }
}
