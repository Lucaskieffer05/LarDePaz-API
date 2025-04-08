using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LarDePaz_API.Models
{
    public class ParcelaContratoHistorial : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public int ParcelaId { get; set; }
        public int ContratoId { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        [ForeignKey("ParcelaId")]
        public virtual Parcela Parcela { get; set; } = null!;

        [ForeignKey("ContratoId")]
        public virtual Contrato Contrato { get; set; } = null!;
    }
}
