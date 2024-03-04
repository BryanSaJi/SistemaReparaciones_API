using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaReparaciones_API.Context;
using SistemaReparaciones_API.Model;


namespace SistemaReparaciones_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordsController : ControllerBase
    {

        private readonly SistemaReparacionesContext context;
        public PasswordsController(SistemaReparacionesContext context)
        {
            this.context = context;
        }


        // GET: api/<PasswordController>
        [HttpGet]
        public IActionResult ObtenerPasswords()
        {
            var passwords = context.Passwords.ToList();

            if (passwords == null || !passwords.Any())
            {
                return NotFound("No se encontraron contraseñas");
            }

            return Ok(passwords);
        }

        // GET api/<PasswordController>/5
        [HttpGet("{id}")]
        public IActionResult ObtenerPassword(int id)
        {
            var password = context.Passwords.FirstOrDefault(p => p.id == id);

            if (password == null)
            {
                return NotFound("Contraseña no encontrada");
            }

            return Ok(password);
        }

        // POST api/<PasswordController>
        [HttpPost]
        public IActionResult AgregarPassword([FromBody] Passwords passwords)
        {
            if (passwords == null)
            {
                return BadRequest("Datos de contraseña no válidos");
            }

            try
            {
                context.Passwords.Add(passwords);
                context.SaveChanges();

                return Ok(new { Mensaje = "Contraseña agregada exitosamente", Passwords = passwords });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // PUT api/<PasswordController>/5
        [HttpPut("{id}")]
        public IActionResult EditarPassword(int id, [FromBody] Passwords passwords)
        {
            if (passwords == null)
            {
                return BadRequest("Datos de contraseña no válidos");
            }

            var passwordExistente = context.Passwords.Find(id);

            if (passwordExistente == null)
            {
                return NotFound("Contraseña no encontrada");
            }

            try
            {
                // Actualizar las propiedades de la contraseña existente con las de la contraseña actualizada
                passwordExistente.password = passwords.password;

                // Guardar los cambios en la base de datos
                context.SaveChanges();

                return Ok(new { Mensaje = "Contraseña actualizada exitosamente", Passwords = passwordExistente });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // DELETE api/<PasswordController>/5
        [HttpDelete("{id}")]
        public IActionResult EliminarPassword(int id)
        {
            var passwordExistente = context.Passwords.Find(id);

            if (passwordExistente == null)
            {
                return NotFound("Contraseña no encontrada");
            }

            try
            {
                // Eliminar la contraseña de la base de datos
                context.Passwords.Remove(passwordExistente);
                context.SaveChanges();

                var passwords = context.Passwords.ToList();
                // Devolver una respuesta exitosa
                return Ok(new { Mensaje = "Contraseña eliminada exitosamente", Passwords = passwords });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


    }
}
