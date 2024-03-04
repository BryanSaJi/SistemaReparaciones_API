using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaReparaciones_API.Context;
using SistemaReparaciones_API.Model;


namespace SistemaReparaciones_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {

        private readonly SistemaReparacionesContext context;
        public RolesController(SistemaReparacionesContext context)
        {
            this.context = context;
        }


        // GET: api/<RolController>
        [HttpGet]
        public IActionResult ObtenerRoles()
        {
            var roles = context.Roles.ToList();

            if (roles == null || !roles.Any())
            {
                return NotFound("No se encontraron roles");
            }

            return Ok(roles);
        }

        // GET api/<RolController>/5
        [HttpGet("{id}")]
        public IActionResult ObtenerRol(int id)
        {
            var rol = context.Roles.FirstOrDefault(r => r.id == id);

            if (rol == null)
            {
                return NotFound("Rol no encontrado");
            }

            return Ok(rol);
        }

        // POST api/<RolController>
        [HttpPost]
        public IActionResult AgregarRol([FromBody] Roles roles)
        {
            if (roles == null)
            {
                return BadRequest("Datos de rol no válidos");
            }

            try
            {
                context.Roles.Add(roles);
                context.SaveChanges();

                return Ok(new { Mensaje = "Rol agregado exitosamente", Roles = roles });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // PUT api/<RolController>/5
        [HttpPut("{id}")]
        public IActionResult EditarRol(int id, [FromBody] Roles roles)
        {
            if (roles == null)
            {
                return BadRequest("Datos de rol no válidos");
            }

            var rolExistente = context.Roles.Find(id);

            if (rolExistente == null)
            {
                return NotFound("Rol no encontrado");
            }

            try
            {
                // Actualizar las propiedades del rol existente con las del rol actualizado
                rolExistente.rol = roles.rol;

                // Guardar los cambios en la base de datos
                context.SaveChanges();

                return Ok(new { Mensaje = "Rol actualizado exitosamente", Roles = rolExistente });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // DELETE api/<RolController>/5
        [HttpDelete("{id}")]
        public IActionResult EliminarRol(int id)
        {
            var rolExistente = context.Roles.Find(id);

            if (rolExistente == null)
            {
                return NotFound("Rol no encontrado");
            }

            try
            {
                // Eliminar el rol de la base de datos
                context.Roles.Remove(rolExistente);
                context.SaveChanges();

                var roles = context.Roles.ToList();
                // Devolver una respuesta exitosa
                return Ok(new { Mensaje = "Rol eliminado exitosamente", Roles = roles });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
