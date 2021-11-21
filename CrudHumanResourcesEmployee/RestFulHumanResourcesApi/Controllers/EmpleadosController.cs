using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestFulHumanResourcesApi.Model;
using RestFulHumanResourcesApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Net;
using System.Threading.Tasks;


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

        // PUT api/<EmpleadosController>/5
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

            

            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE api/<EmpleadosController>/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteEmpleado(int id)
        {

            //Productos productos = db.Productos.Find(id);
            //if (productos == null)
            //{
            //    return NotFound();
            //}

            //db.Productos.Remove(productos);
            //db.SaveChanges();

            //return Ok(productos);
            return Ok("Ok");
        }
    }
}
