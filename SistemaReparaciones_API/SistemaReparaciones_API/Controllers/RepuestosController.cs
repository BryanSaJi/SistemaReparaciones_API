using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaReparaciones_API.Context;
using SistemaReparaciones_API.Model;



namespace SistemaReparaciones_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepuestosController : ControllerBase
    {

        private readonly SistemaReparacionesContext context;
        public RepuestosController(SistemaReparacionesContext context)
        {
            this.context = context;
        }


        // GET: api/<RepuestoController>
        [HttpGet]
        public IActionResult ObtenerRepuestos()
        {
            var repuestos = context.Repuestos.ToList();

            if (repuestos == null || !repuestos.Any())
            {
                return NotFound("No se encontraron repuestos");
            }

            return Ok(repuestos);
        }

        // GET api/<RepuestoController>/5
        [HttpGet("{id}")]
        public IActionResult ObtenerRepuesto(int id)
        {
            var repuesto = context.Repuestos.FirstOrDefault(r => r.id == id);

            if (repuesto == null)
            {
                return NotFound("Repuesto no encontrado");
            }

            return Ok(repuesto);
        }

        // POST api/<RepuestoController>
        [HttpPost]
        public IActionResult AgregarRepuesto([FromBody] Repuestos repuestos)
        {
            if (repuestos == null)
            {
                return BadRequest("Datos de repuesto no válidos");
            }

            try
            {
                context.Repuestos.Add(repuestos);
                context.SaveChanges();

                return Ok(new { Mensaje = "Repuesto agregado exitosamente", Repuestos = repuestos });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // PUT api/<RepuestoController>/5
        [HttpPut("{id}")]
        public IActionResult EditarRepuesto(int id, [FromBody] Repuestos repuestos)
        {
            if (repuestos == null)
            {
                return BadRequest("Datos de repuesto no válidos");
            }

            var repuestoExistente = context.Repuestos.Find(id);

            if (repuestoExistente == null)
            {
                return NotFound("Repuesto no encontrado");
            }

            try
            {
                // Actualizar las propiedades del repuesto existente con las del repuesto actualizado
                repuestoExistente.tipo_consola_id = repuestos.tipo_consola_id;
                repuestoExistente.tipo_repuesto_id = repuestos.tipo_repuesto_id;
                repuestoExistente.detalle = repuestos.detalle;
                repuestoExistente.fabricante_modelo = repuestos.fabricante_modelo;
                repuestoExistente.taller_id = repuestos.taller_id;

                // Guardar los cambios en la base de datos
                context.SaveChanges();

                return Ok(new { Mensaje = "Repuesto actualizado exitosamente", Repuestos = repuestoExistente });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // DELETE api/<RepuestoController>/5
        [HttpDelete("{id}")]
        public IActionResult EliminarRepuesto(int id)
        {
            var repuestoExistente = context.Repuestos.Find(id);

            if (repuestoExistente == null)
            {
                return NotFound("Repuesto no encontrado");
            }

            try
            {
                // Eliminar el repuesto de la base de datos
                context.Repuestos.Remove(repuestoExistente);
                context.SaveChanges();

                var repuestos = context.Repuestos.ToList();
                // Devolver una respuesta exitosa
                return Ok(new { Mensaje = "Repuesto eliminado exitosamente", Repuestos = repuestos });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

    }
}
