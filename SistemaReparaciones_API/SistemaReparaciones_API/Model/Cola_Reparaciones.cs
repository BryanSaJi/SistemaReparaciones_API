using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaReparaciones_API.Model
{
    public class Cola_Reparaciones
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [ForeignKey("local_id")]
        public int local_id { get; set; }

        [ForeignKey("cliente_id")]
        public int cliente_id { get; set; }

        [ForeignKey("maquina_id")]
        public int maquina_id { get; set; }

        [ForeignKey("estado_id")]
        public int estado_id { get; set; }

        [ForeignKey("estado_Taller_id")]
        public int estado_taller_id { get; set; }


    }
}
