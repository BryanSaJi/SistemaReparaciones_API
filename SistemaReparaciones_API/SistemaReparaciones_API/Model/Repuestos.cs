using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaReparaciones_API.Model
{
    public class Repuestos
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [ForeignKey("tipo_consola_id")]
        public int tipo_consola_id { get; set; }

        [ForeignKey("tipo_repuesto_id")]
        public int tipo_repuesto_id { get; set; }

        [StringLength(300)]
        public string detalle { get; set; }

        [StringLength(100)]
        public string fabricante_modelo { get; set; }

        [ForeignKey("taller_id")]
        public int taller_id { get; set; }

    }
}
