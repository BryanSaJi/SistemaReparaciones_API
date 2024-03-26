using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaReparaciones_API.Context;
using SistemaReparaciones_API.Model;


namespace SistemaReparaciones_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposController : ControllerBase
    {


        private readonly SistemaReparacionesContext context;
        public TiposController(SistemaReparacionesContext context)
        {
            this.context = context;
        }



        /*
        --------------------------------------------------------------------------------------------------------
        ---------------------------------------------  Tipo Local ----------------------------------------------
        */



        // GET: api/<TipoLocalController>
        [HttpGet]
        public IActionResult ObtenerTiposLocales()
        {
            var tiposLocales = context.Tipo_Local.ToList();

            if (tiposLocales == null || !tiposLocales.Any())
            {
                return NotFound("No se encontraron tipos de locales");
            }

            return Ok(tiposLocales);
        }

        // GET api/<TipoLocalController>/5
        [HttpGet("{id}")]
        public IActionResult ObtenerTipoLocal(int id)
        {
            var tipoLocal = context.Tipo_Local.FirstOrDefault(t => t.id == id);

            if (tipoLocal == null)
            {
                return NotFound("Tipo de local no encontrado");
            }

            return Ok(tipoLocal);
        }

        // POST api/<TipoLocalController>
        [HttpPost]
        public IActionResult AgregarTipoLocal([FromBody] Tipo_Local tipo_Local)
        {
            if (tipo_Local == null)
            {
                return BadRequest("Datos de tipo de local no válidos");
            }

            try
            {
                context.Tipo_Local.Add(tipo_Local);
                context.SaveChanges();

                return Ok(new { Mensaje = "Tipo de local agregado exitosamente", Tipo_Local = tipo_Local });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // PUT api/<TipoLocalController>/5
        [HttpPut("{id}")]
        public IActionResult EditarTipoLocal(int id, [FromBody] Tipo_Local tipo_Local)
        {
            if (tipo_Local == null)
            {
                return BadRequest("Datos de tipo de local no válidos");
            }

            var tipoLocalExistente = context.Tipo_Local.Find(id);

            if (tipoLocalExistente == null)
            {
                return NotFound("Tipo de local no encontrado");
            }

            try
            {
                // Actualizar las propiedades del tipo de local existente con las del tipo de local actualizado
                tipoLocalExistente.nombre_tipo = tipo_Local.nombre_tipo;

                // Guardar los cambios en la base de datos
                context.SaveChanges();

                return Ok(new { Mensaje = "Tipo de local actualizado exitosamente", Tipo_Local = tipoLocalExistente });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // DELETE api/<TipoLocalController>/5
        [HttpDelete("{id}")]
        public IActionResult EliminarTipoLocal(int id)
        {
            var tipoLocalExistente = context.Tipo_Local.Find(id);

            if (tipoLocalExistente == null)
            {
                return NotFound("Tipo de local no encontrado");
            }

            try
            {
                // Eliminar el tipo de local de la base de datos
                context.Tipo_Local.Remove(tipoLocalExistente);
                context.SaveChanges();

                var tiposLocales = context.Tipo_Local.ToList();
                // Devolver una respuesta exitosa
                return Ok(new { Mensaje = "Tipo de local eliminado exitosamente", TiposLocales = tiposLocales });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }




        /*
        --------------------------------------------------------------------------------------------------------
        ------------------------------------------  Tipos Consola ----------------------------------------------
        */


        // GET: api/<TipoConsolaController>
        [HttpGet("TiposConsola/")]
        public IActionResult ObtenerTiposConsola()
        {
            var tiposConsola = context.Tipos_Consola.ToList();

            if (tiposConsola == null || !tiposConsola.Any())
            {
                return NotFound("No se encontraron tipos de consola");
            }

            return Ok(tiposConsola);
        }

        // GET api/<TipoConsolaController>/5
        [HttpGet("TiposConsola/{id}")]
        public IActionResult ObtenerTipoConsola(int id)
        {
            var tipoConsola = context.Tipos_Consola.FirstOrDefault(t => t.id == id);

            if (tipoConsola == null)
            {
                return NotFound("Tipo de consola no encontrado");
            }

            return Ok(tipoConsola);
        }

        // POST api/<TipoConsolaController>
        [HttpPost("TiposConsola/")]
        public IActionResult AgregarTipoConsola([FromBody] Tipos_Consola tipos_Consola)
        {
            if (tipos_Consola == null)
            {
                return BadRequest("Datos de tipo de consola no válidos");
            }

            try
            {
                context.Tipos_Consola.Add(tipos_Consola);
                context.SaveChanges();

                return Ok(new { Mensaje = "Tipo de consola agregado exitosamente", Tipos_Consola = tipos_Consola });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // PUT api/<TipoConsolaController>/5
        [HttpPut("TiposConsola/{id}")]
        public IActionResult EditarTipoConsola(int id, [FromBody] Tipos_Consola tipos_Consola)
        {
            if (tipos_Consola == null)
            {
                return BadRequest("Datos de tipo de consola no válidos");
            }

            var tipoConsolaExistente = context.Tipos_Consola.Find(id);

            if (tipoConsolaExistente == null)
            {
                return NotFound("Tipo de consola no encontrado");
            }

            try
            {
                // Actualizar las propiedades del tipo de consola existente con las del tipo de consola actualizado
                tipoConsolaExistente.nombre_consola = tipos_Consola.nombre_consola;

                // Guardar los cambios en la base de datos
                context.SaveChanges();

                return Ok(new { Mensaje = "Tipo de consola actualizado exitosamente", Tipos_Consola = tipoConsolaExistente });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // DELETE api/<TipoConsolaController>/5
        [HttpDelete("TiposConsola/{id}")]
        public IActionResult EliminarTipoConsola(int id)
        {
            var tipoConsolaExistente = context.Tipos_Consola.Find(id);

            if (tipoConsolaExistente == null)
            {
                return NotFound("Tipo de consola no encontrado");
            }

            try
            {
                // Eliminar el tipo de consola de la base de datos
                context.Tipos_Consola.Remove(tipoConsolaExistente);
                context.SaveChanges();

                var tiposConsola = context.Tipos_Consola.ToList();
                // Devolver una respuesta exitosa
                return Ok(new { Mensaje = "Tipo de consola eliminado exitosamente", Tipos_Consola = tiposConsola });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }





        /*
        --------------------------------------------------------------------------------------------------------
        ------------------------------------------  Tipos Repuesto ---------------------------------------------
        */



        // GET: api/<TipoRepuestoController>
        [HttpGet("TipoRepuesto/")]
        public IActionResult ObtenerTiposRepuesto()
        {
            var tiposRepuesto = context.Tipos_Repuesto.ToList();

            if (tiposRepuesto == null || !tiposRepuesto.Any())
            {
                return NotFound("No se encontraron tipos de repuesto");
            }

            return Ok(tiposRepuesto);
        }

        // GET api/<TipoRepuestoController>/5
        [HttpGet("TipoRepuesto/{id}")]
        public IActionResult ObtenerTipoRepuesto(int id)
        {
            var tipoRepuesto = context.Tipos_Repuesto.FirstOrDefault(t => t.id == id);

            if (tipoRepuesto == null)
            {
                return NotFound("Tipo de repuesto no encontrado");
            }

            return Ok(tipoRepuesto);
        }

        // POST api/<TipoRepuestoController>
        [HttpPost("TipoRepuesto/")]
        public IActionResult AgregarTipoRepuesto([FromBody] Tipos_Repuesto tipos_Repuesto)
        {
            if (tipos_Repuesto == null)
            {
                return BadRequest("Datos de tipo de repuesto no válidos");
            }

            try
            {
                context.Tipos_Repuesto.Add(tipos_Repuesto);
                context.SaveChanges();

                return Ok(new { Mensaje = "Tipo de repuesto agregado exitosamente", Tipos_Repuesto = tipos_Repuesto });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // PUT api/<TipoRepuestoController>/5
        [HttpPut("TipoRepuesto/{id}")]
        public IActionResult EditarTipoRepuesto(int id, [FromBody] Tipos_Repuesto tipoRepuesto)
        {
            if (tipoRepuesto == null)
            {
                return BadRequest("Datos de tipo de repuesto no válidos");
            }

            var tipoRepuestoExistente = context.Tipos_Repuesto.Find(id);

            if (tipoRepuestoExistente == null)
            {
                return NotFound("Tipo de repuesto no encontrado");
            }

            try
            {
                // Actualizar las propiedades del tipo de repuesto existente con las del tipo de repuesto actualizado
                tipoRepuestoExistente.nombre_tipo = tipoRepuesto.nombre_tipo;

                // Guardar los cambios en la base de datos
                context.SaveChanges();

                return Ok(new { Mensaje = "Tipo de repuesto actualizado exitosamente", Tipos_Repuesto = tipoRepuestoExistente });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // DELETE api/<TipoRepuestoController>/5
        [HttpDelete("TipoRepuesto/{id}")]
        public IActionResult EliminarTipoRepuesto(int id)
        {
            var tipoRepuestoExistente = context.Tipos_Repuesto.Find(id);

            if (tipoRepuestoExistente == null)
            {
                return NotFound("Tipo de repuesto no encontrado");
            }

            try
            {
                // Eliminar el tipo de repuesto de la base de datos
                context.Tipos_Repuesto.Remove(tipoRepuestoExistente);
                context.SaveChanges();

                var tiposRepuesto = context.Tipos_Repuesto.ToList();
                // Devolver una respuesta exitosa
                return Ok(new { Mensaje = "Tipo de repuesto eliminado exitosamente", Tipos_Repuesto = tiposRepuesto });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }



    }
}
