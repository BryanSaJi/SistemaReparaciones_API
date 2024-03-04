using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaReparaciones_API.Context;
using SistemaReparaciones_API.Model;

namespace SistemaReparaciones_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaReparacionesController : ControllerBase
    {


        private readonly SistemaReparacionesContext context;
        public ColaReparacionesController(SistemaReparacionesContext context)
        {
            this.context = context;
        }



        // GET: api/<ColaReparacionController>
        [HttpGet]
        public IActionResult ObtenerColasReparacion()
        {
            var colasReparacion = context.Cola_Reparaciones.ToList();

            if (colasReparacion == null || !colasReparacion.Any())
            {
                return NotFound("No se encontraron colas de reparación");
            }

            return Ok(colasReparacion);
        }

        // GET api/<ColaReparacionController>/5
        [HttpGet("{id}")]
        public IActionResult ObtenerColaReparacion(int id)
        {
            var colaReparacion = context.Cola_Reparaciones.FirstOrDefault(c => c.id == id);

            if (colaReparacion == null)
            {
                return NotFound("Cola de reparación no encontrada");
            }

            return Ok(colaReparacion);
        }

        // POST api/<ColaReparacionController>
        [HttpPost]
        public IActionResult AgregarColaReparacion([FromBody] Cola_Reparaciones cola_Reparaciones)
        {
            if (cola_Reparaciones == null)
            {
                return BadRequest("Datos de cola de reparación no válidos");
            }

            try
            {
                context.Cola_Reparaciones.Add(cola_Reparaciones);
                context.SaveChanges();

                return Ok(new { Mensaje = "Cola de reparación agregada exitosamente", Cola_Reparaciones = cola_Reparaciones });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // PUT api/<ColaReparacionController>/5
        [HttpPut("{id}")]
        public IActionResult EditarColaReparacion(int id, [FromBody] Cola_Reparaciones cola_Reparaciones)
        {
            if (cola_Reparaciones == null)
            {
                return BadRequest("Datos de cola de reparación no válidos");
            }

            var colaReparacionExistente = context.Cola_Reparaciones.Find(id);

            if (colaReparacionExistente == null)
            {
                return NotFound("Cola de reparación no encontrada");
            }

            try
            {
                // Actualizar las propiedades de la cola de reparación existente con las de la cola de reparación actualizada
                colaReparacionExistente.local_id = cola_Reparaciones.local_id;
                colaReparacionExistente.cliente_id = cola_Reparaciones.cliente_id;
                colaReparacionExistente.maquina_id = cola_Reparaciones.maquina_id;
                colaReparacionExistente.estado_id = cola_Reparaciones.estado_id;
                colaReparacionExistente.estado_taller_id = cola_Reparaciones.estado_taller_id;

                // Guardar los cambios en la base de datos
                context.SaveChanges();

                return Ok(new { Mensaje = "Cola de reparación actualizada exitosamente", Cola_Reparaciones = colaReparacionExistente });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // DELETE api/<ColaReparacionController>/5
        [HttpDelete("{id}")]
        public IActionResult EliminarColaReparacion(int id)
        {
            var colaReparacionExistente = context.Cola_Reparaciones.Find(id);

            if (colaReparacionExistente == null)
            {
                return NotFound("Cola de reparación no encontrada");
            }

            try
            {
                // Eliminar la cola de reparación de la base de datos
                context.Cola_Reparaciones.Remove(colaReparacionExistente);
                context.SaveChanges();

                var colasReparacion = context.Cola_Reparaciones.ToList();
                // Devolver una respuesta exitosa
                return Ok(new { Mensaje = "Cola de reparación eliminada exitosamente", Cola_Reparaciones = colasReparacion });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

    }
}
