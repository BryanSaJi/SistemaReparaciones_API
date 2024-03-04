using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaReparaciones_API.Model
{
    public class Clientes
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string apellido1 { get; set; }

        [Required]
        [StringLength(50)]
        public string apellido2 { get; set; }

        [Required]
        [StringLength(15)]
        public string cedula { get; set; }

        [StringLength(20)]
        public string telefono1 { get; set; }

        [StringLength(20)]
        public string telefono2 { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        public DateTime fecha_ingreso { get; set; }
    }
}
