using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaReparaciones_API.Context;
using SistemaReparaciones_API.Model;


namespace SistemaReparaciones_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {


        private readonly SistemaReparacionesContext context;
        public UsuariosController(SistemaReparacionesContext context)
        {
            this.context = context;
        }



        // GET: api/<UsuarioController>
        [HttpGet]
        public IActionResult ObtenerUsuarios()
        {
            var usuarios = context.Usuarios.ToList();

            if (usuarios == null || !usuarios.Any())
            {
                return NotFound("No se encontraron usuarios");
            }

            return Ok(usuarios);
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public IActionResult ObtenerUsuario(int id)
        {
            var usuario = context.Usuarios.FirstOrDefault(u => u.id == id);

            if (usuario == null)
            {
                return NotFound("Usuario no encontrado");
            }

            return Ok(usuario);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public IActionResult AgregarUsuario([FromBody] Usuarios usuarios)
        {
            if (usuarios == null)
            {
                return BadRequest("Datos de usuario no válidos");
            }

            try
            {
                context.Usuarios.Add(usuarios);
                context.SaveChanges();

                return Ok(new { Mensaje = "Usuario agregado exitosamente", Usuarios = usuarios });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public IActionResult EditarUsuario(int id, [FromBody] Usuarios usuarios)
        {
            if (usuarios == null)
            {
                return BadRequest("Datos de usuario no válidos");
            }

            var usuarioExistente = context.Usuarios.Find(id);

            if (usuarioExistente == null)
            {
                return NotFound("Usuario no encontrado");
            }

            try
            {
                // Actualizar las propiedades del usuario existente con las del usuario actualizado
                usuarioExistente.nombre = usuarios.nombre;
                usuarioExistente.apellido = usuarios.apellido;
                usuarioExistente.cedula = usuarios.cedula;
                usuarioExistente.fecha_nacimiento = usuarios.fecha_nacimiento;
                usuarioExistente.rol_id = usuarios.rol_id;
                usuarioExistente.password_id = usuarios.password_id;
                usuarioExistente.username = usuarios.username;

                // Guardar los cambios en la base de datos
                context.SaveChanges();

                return Ok(new { Mensaje = "Usuario actualizado exitosamente", Usuarios = usuarioExistente });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            var usuarioExistente = context.Usuarios.Find(id);

            if (usuarioExistente == null)
            {
                return NotFound("Usuario no encontrado");
            }

            try
            {
                // Eliminar el usuario de la base de datos
                context.Usuarios.Remove(usuarioExistente);
                context.SaveChanges();

                var usuarios = context.Usuarios.ToList();
                // Devolver una respuesta exitosa
                return Ok(new { Mensaje = "Usuario eliminado exitosamente", Usuarios = usuarios });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

    }
}
