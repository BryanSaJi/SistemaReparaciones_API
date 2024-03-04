using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaReparaciones_API.Context;
using SistemaReparaciones_API.Model;

namespace SistemaReparaciones_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        private readonly SistemaReparacionesContext context;
        public ClientesController(SistemaReparacionesContext context)
        {
            this.context = context;
        }


        // GET: api/<ClienteController>
        [HttpGet]
        public IActionResult ObtenerClientes()
        {
            var clientes = context.Clientes.ToList();

            if (clientes == null || !clientes.Any())
            {
                return NotFound("No se encontraron clientes");
            }

            return Ok(clientes);
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public IActionResult ObtenerCliente(int id)
        {
            var cliente = context.Clientes.FirstOrDefault(c => c.id == id);

            if (cliente == null)
            {
                return NotFound("Cliente no encontrado");
            }

            return Ok(cliente);
        }

        // POST api/<ClienteController>
        [HttpPost]
        public IActionResult AgregarCliente([FromBody] Clientes clientes)
        {
            if (clientes == null)
            {
                return BadRequest("Datos de cliente no válidos");
            }

            try
            {
                context.Clientes.Add(clientes);
                context.SaveChanges();

                return Ok(new { Mensaje = "Cliente agregado exitosamente", Cliente = clientes });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public IActionResult EditarCliente(int id, [FromBody] Clientes clientes)
        {
            if (clientes == null)
            {
                return BadRequest("Datos de cliente no válidos");
            }

            var clienteExistente = context.Clientes.Find(id);

            if (clienteExistente == null)
            {
                return NotFound("Cliente no encontrado");
            }

            try
            {
                // Actualizar las propiedades del cliente existente con las del cliente actualizado
                clienteExistente.nombre = clientes.nombre;
                clienteExistente.apellido1 = clientes.apellido1;
                clienteExistente.apellido2 = clientes.apellido2;
                clienteExistente.cedula = clientes.cedula;
                clienteExistente.telefono1 = clientes.telefono1;
                clienteExistente.telefono2 = clientes.telefono2;
                clienteExistente.email = clientes.email;
                clienteExistente.fecha_ingreso = clientes.fecha_ingreso;

                // Guardar los cambios en la base de datos
                context.SaveChanges();

                return Ok(new { Mensaje = "Cliente actualizado exitosamente", Cliente = clienteExistente });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public IActionResult EliminarCliente(int id)
        {
            var clienteExistente = context.Clientes.Find(id);

            if (clienteExistente == null)
            {
                return NotFound("Cliente no encontrado");
            }

            try
            {
                // Eliminar el cliente de la base de datos
                context.Clientes.Remove(clienteExistente);
                context.SaveChanges();

                var clientes = context.Clientes.ToList();
                // Devolver una respuesta exitosa
                return Ok(new { Mensaje = "Cliente eliminado exitosamente", Clientes = clientes });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

    }
}
