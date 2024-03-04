using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaReparaciones_API.Context;
using SistemaReparaciones_API.Model;

namespace SistemaReparaciones_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaquinasController : ControllerBase
    {



        private readonly SistemaReparacionesContext context;
        public MaquinasController(SistemaReparacionesContext context)
        {
            this.context = context;
        }


        // GET: api/<MaquinaController>
        [HttpGet]
        public IActionResult ObtenerMaquinas()
        {
            var maquinas = context.Maquinas.ToList();

            if (maquinas == null || !maquinas.Any())
            {
                return NotFound("No se encontraron máquinas");
            }

            return Ok(maquinas);
        }

        // GET api/<MaquinaController>/5
        [HttpGet("{id}")]
        public IActionResult ObtenerMaquina(int id)
        {
            var maquina = context.Maquinas.FirstOrDefault(m => m.id == id);

            if (maquina == null)
            {
                return NotFound("Máquina no encontrada");
            }

            return Ok(maquina);
        }

        // POST api/<MaquinaController>
        [HttpPost]
        public IActionResult AgregarMaquina([FromBody] Maquinas maquinas)
        {
            if (maquinas == null)
            {
                return BadRequest("Datos de máquina no válidos");
            }

            try
            {
                context.Maquinas.Add(maquinas);
                context.SaveChanges();

                return Ok(new { Mensaje = "Máquina agregada exitosamente", Maquinas = maquinas });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // PUT api/<MaquinaController>/5
        [HttpPut("{id}")]
        public IActionResult EditarMaquina(int id, [FromBody] Maquinas maquinas)
        {
            if (maquinas == null)
            {
                return BadRequest("Datos de máquina no válidos");
            }

            var maquinaExistente = context.Maquinas.Find(id);

            if (maquinaExistente == null)
            {
                return NotFound("Máquina no encontrada");
            }

            try
            {
                // Actualizar las propiedades de la máquina existente con las de la máquina actualizada
                maquinaExistente.tipo_consola_id = maquinas.tipo_consola_id;
                maquinaExistente.detalle1 = maquinas.detalle1;
                maquinaExistente.detalle2 = maquinas.detalle2;
                maquinaExistente.serial = maquinas.serial;
                maquinaExistente.estado_fisico = maquinas.estado_fisico;

                // Guardar los cambios en la base de datos
                context.SaveChanges();

                return Ok(new { Mensaje = "Máquina actualizada exitosamente", Maquinas = maquinaExistente });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // DELETE api/<MaquinaController>/5
        [HttpDelete("{id}")]
        public IActionResult EliminarMaquina(int id)
        {
            var maquinaExistente = context.Maquinas.Find(id);

            if (maquinaExistente == null)
            {
                return NotFound("Máquina no encontrada");
            }

            try
            {
                // Eliminar la máquina de la base de datos
                context.Maquinas.Remove(maquinaExistente);
                context.SaveChanges();

                var maquinas = context.Maquinas.ToList();
                // Devolver una respuesta exitosa
                return Ok(new { Mensaje = "Máquina eliminada exitosamente", Maquinas = maquinas });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
