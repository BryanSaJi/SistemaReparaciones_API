using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaReparaciones_API.Model
{
    public class Usuarios
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string apellido { get; set; }

        [Required]
        [StringLength(15)]
        public string cedula { get; set; }

        public DateTime fecha_nacimiento { get; set; }

        [ForeignKey("Rol_id")]
        public int rol_id { get; set; }

        [ForeignKey("Password_id")]
        public int password_id { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }
    }

}
