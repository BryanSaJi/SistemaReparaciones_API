using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaReparaciones_API.Context;
using SistemaReparaciones_API.Model;


namespace SistemaReparaciones_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalesController : ControllerBase
    {

        private readonly SistemaReparacionesContext context;
        public LocalesController(SistemaReparacionesContext context)
        {
            this.context = context;
        }


        // GET: api/<LocalController>
        [HttpGet]
        public IActionResult ObtenerLocales()
        {
            var locales = context.Locales.ToList();

            if (locales == null || !locales.Any())
            {
                return NotFound("No se encontraron locales");
            }

            return Ok(locales);
        }

        // GET api/<LocalController>/5
        [HttpGet("{id}")]
        public IActionResult ObtenerLocal(int id)
        {
            var local = context.Locales.FirstOrDefault(l => l.id == id);

            if (local == null)
            {
                return NotFound("Local no encontrado");
            }

            return Ok(local);
        }

        // POST api/<LocalController>
        [HttpPost]
        public IActionResult AgregarLocal([FromBody] Locales locales)
        {
            if (locales == null)
            {
                return BadRequest("Datos de local no válidos");
            }

            try
            {
                context.Locales.Add(locales);
                context.SaveChanges();

                return Ok(new { Mensaje = "Local agregado exitosamente", Locales = locales });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // PUT api/<LocalController>/5
        [HttpPut("{id}")]
        public IActionResult EditarLocal(int id, [FromBody] Locales locales)
        {
            if (locales == null)
            {
                return BadRequest("Datos de local no válidos");
            }

            var localExistente = context.Locales.Find(id);

            if (localExistente == null)
            {
                return NotFound("Local no encontrado");
            }

            try
            {
                // Actualizar las propiedades del local existente con las del local actualizado
                localExistente.nombre = locales.nombre;
                localExistente.direccion = locales.direccion;
                localExistente.telefono = locales.telefono;
                localExistente.tipo_local_id = locales.tipo_local_id;
                localExistente.usuario_id = locales.usuario_id;

                // Guardar los cambios en la base de datos
                context.SaveChanges();

                return Ok(new { Mensaje = "Local actualizado exitosamente", Locales = localExistente });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // DELETE api/<LocalController>/5
        [HttpDelete("{id}")]
        public IActionResult EliminarLocal(int id)
        {
            var localExistente = context.Locales.Find(id);

            if (localExistente == null)
            {
                return NotFound("Local no encontrado");
            }

            try
            {
                // Eliminar el local de la base de datos
                context.Locales.Remove(localExistente);
                context.SaveChanges();

                var locales = context.Locales.ToList();
                // Devolver una respuesta exitosa
                return Ok(new { Mensaje = "Local eliminado exitosamente", Locales = locales });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
