using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaReparaciones_API.Model
{
    public class Maquinas
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [ForeignKey("tipo_consola_id")]
        public int tipo_consola_id { get; set; }

        [StringLength(100)]
        public string detalle1 { get; set; }

        [StringLength(300)]
        public string detalle2 { get; set; }

        [StringLength(50)]
        public string serial { get; set; }

        [StringLength(300)]
        public string estado_fisico { get; set; }

    }
}
