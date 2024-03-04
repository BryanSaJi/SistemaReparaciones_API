using Microsoft.EntityFrameworkCore;
using SistemaReparaciones_API.Model;
//using SistemaReparaciones_API.Model;


namespace SistemaReparaciones_API.Context
{
    public class SistemaReparacionesContext:DbContext
    {

        public SistemaReparacionesContext(DbContextOptions<SistemaReparacionesContext> options) : base(options)
        {

        }


       
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Passwords> Passwords { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Tipo_Local> Tipo_Local { get; set; }
        public DbSet<Locales> Locales { get; set; }
        public DbSet<Tipos_Repuesto> Tipos_Repuesto { get; set; }
        public DbSet<Tipos_Consola> Tipos_Consola { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Estado_Taller> Estado_Taller { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Maquinas> Maquinas { get; set; }
        public DbSet<Cola_Reparaciones> Cola_Reparaciones { get; set; }
        public DbSet<Repuestos> Repuestos { get; set; }


    }
}
