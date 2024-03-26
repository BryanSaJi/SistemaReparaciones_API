using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SistemaReparaciones_API.Context;

namespace SistemaReparaciones_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly SistemaReparacionesContext context;

        public LoginController(SistemaReparacionesContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [Route("Login")]
        public ActionResult Login(string usuario, string contrasenia)
        {

            try
            {
                var Exitoso = new SqlParameter()
                {
                    ParameterName = "Exitoso",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Direction = System.Data.ParameterDirection.Output
                };

                context.Database.ExecuteSqlRaw("sp_Login @Usuario , @Contrasenia, @Exitoso OUTPUT",
                    new SqlParameter("@Usuario", usuario),
                    new SqlParameter("@Contrasenia", contrasenia),
                    Exitoso
                );

                var result = (bool)Exitoso.Value;

                if (result)
                {
                    return Ok();
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            
        }

        [HttpGet]
        [Route("ObtenerUsuario")]
        public ActionResult getUsuario(string usuario, string contrasenia)
        {

            try
            {
                var Usuario = context.Usuarios.FromSqlRaw("sp_Usuario @User , @Contrasenia",
                new SqlParameter("@User", usuario),
                new SqlParameter("@Contrasenia", contrasenia)
                ).ToList();

                if (Usuario != null)
                {
                    return Ok(Usuario.FirstOrDefault());
                }
                else
                {
                    return NotFound();
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            
        }



    }
}
