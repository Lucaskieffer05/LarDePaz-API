using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LarDePaz_API.Models
{
    public class Cuota : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public int ContratoId { get; set; }
        public string NumeroCuota { get; set; } = null!;
        public DateTime FechaEmitida { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime FechaPago { get; set; }
        public int Importe { get; set; }
        public int ImportePagado { get; set; }
        public int ImporteInteres { get; set; }
        public string Estado { get; set; } = null!;

        [ForeignKey("ContratoId")]
        public virtual Contrato Contrato { get; set; } = null!;
    }
}
