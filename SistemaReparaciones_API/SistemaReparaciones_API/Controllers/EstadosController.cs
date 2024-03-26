using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaReparaciones_API.Context;
using SistemaReparaciones_API.Model;

namespace SistemaReparaciones_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {


        private readonly SistemaReparacionesContext context;
        public EstadosController(SistemaReparacionesContext context)
        {
            this.context = context;
        }


         
        /*
         --------------------------------------------------------------------------------------------------------
         -----------------------------------------------  Estado ------------------------------------------------
         */


        // GET: api/<EstadoController>
        [HttpGet]
        public IActionResult ObtenerEstados()
        {
            var estados = context.Estados.ToList();

            if (estados == null || !estados.Any())
            {
                return NotFound("No se encontraron estados");
            }

            return Ok(estados);
        }

        // GET api/<EstadoController>/5
        [HttpGet("{id}")]
        public IActionResult ObtenerEstado(int id)
        {
            var estado = context.Estados.FirstOrDefault(e => e.id == id);

            if (estado == null)
            {
                return NotFound("Estado no encontrado");
            }

            return Ok(estado);
        }

        // POST api/<EstadoController>
        [HttpPost]
        public IActionResult AgregarEstado([FromBody] Estado estado)
        {
            if (estado == null)
            {
                return BadRequest("Datos de estado no válidos");
            }

            try
            {
                context.Estados.Add(estado);
                context.SaveChanges();

                return Ok(new { Mensaje = "Estado agregado exitosamente", Estado = estado });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // PUT api/<EstadoController>/5
        [HttpPut("{id}")]
        public IActionResult EditarEstado(int id, [FromBody] Estado estado)
        {
            if (estado == null)
            {
                return BadRequest("Datos de estado no válidos");
            }

            var estadoExistente = context.Estados.Find(id);

            if (estadoExistente == null)
            {
                return NotFound("Estado no encontrado");
            }

            try
            {
                // Actualizar las propiedades del estado existente con las del estado actualizado
                estadoExistente.nombre_estado = estado.nombre_estado;

                // Guardar los cambios en la base de datos
                context.SaveChanges();

                return Ok(new { Mensaje = "Estado actualizado exitosamente", Estado = estadoExistente });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // DELETE api/<EstadoController>/5
        [HttpDelete("{id}")]
        public IActionResult EliminarEstado(int id)
        {
            var estadoExistente = context.Estados.Find(id);

            if (estadoExistente == null)
            {
                return NotFound("Estado no encontrado");
            }

            try
            {
                // Eliminar el estado de la base de datos
                context.Estados.Remove(estadoExistente);
                context.SaveChanges();

                var estados = context.Estados.ToList();
                // Devolver una respuesta exitosa
                return Ok(new { Mensaje = "Estado eliminado exitosamente", Estados = estados });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }





        /*
         --------------------------------------------------------------------------------------------------------
         ------------------------------------------  Estado Taller ----------------------------------------------
         */




        // GET: api/<EstadoTallerController>
        [HttpGet("Estado_Taller/")]
        public IActionResult ObtenerEstadosTaller()
        {
            var estadosTaller = context.Estado_Taller.ToList();

            if (estadosTaller == null || !estadosTaller.Any())
            {
                return NotFound("No se encontraron estados de taller");
            }

            return Ok(estadosTaller);
        }

        // GET api/<EstadoTallerController>/5
        [HttpGet("Estado_Taller/{id}")]
        public IActionResult ObtenerEstadoTaller(int id)
        {
            var estadoTaller = context.Estado_Taller.FirstOrDefault(e => e.id == id);

            if (estadoTaller == null)
            {
                return NotFound("Estado de taller no encontrado");
            }

            return Ok(estadoTaller);
        }

        // POST api/<EstadoTallerController>
        [HttpPost("Estado_Taller/")]
        public IActionResult AgregarEstadoTaller([FromBody] Estado_Taller estado_Taller)
        {
            if (estado_Taller == null)
            {
                return BadRequest("Datos de estado de taller no válidos");
            }

            try
            {
                context.Estado_Taller.Add(estado_Taller);
                context.SaveChanges();

                return Ok(new { Mensaje = "Estado de taller agregado exitosamente", Estado_Taller = estado_Taller });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // PUT api/<EstadoTallerController>/5
        [HttpPut("Estado_Taller/{id}")]
        public IActionResult EditarEstadoTaller(int id, [FromBody] Estado_Taller estado_Taller)
        {
            if (estado_Taller == null)
            {
                return BadRequest("Datos de estado de taller no válidos");
            }

            var estadoTallerExistente = context.Estado_Taller.Find(id);

            if (estadoTallerExistente == null)
            {
                return NotFound("Estado de taller no encontrado");
            }

            try
            {
                // Actualizar las propiedades del estado de taller existente con las del estado de taller actualizado
                estadoTallerExistente.nombre_estado = estado_Taller.nombre_estado;

                // Guardar los cambios en la base de datos
                context.SaveChanges();

                return Ok(new { Mensaje = "Estado de taller actualizado exitosamente", EstadoTaller = estadoTallerExistente });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // DELETE api/<EstadoTallerController>/5
        [HttpDelete("Estado_Taller/{id}")]
        public IActionResult EliminarEstadoTaller(int id)
        {
            var estadoTallerExistente = context.Estado_Taller.Find(id);

            if (estadoTallerExistente == null)
            {
                return NotFound("Estado de taller no encontrado");
            }

            try
            {
                // Eliminar el estado de taller de la base de datos
                context.Estado_Taller.Remove(estadoTallerExistente);
                context.SaveChanges();

                var estadosTaller = context.Estado_Taller.ToList();
                // Devolver una respuesta exitosa
                return Ok(new { Mensaje = "Estado de taller eliminado exitosamente", EstadosTaller = estadosTaller });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
