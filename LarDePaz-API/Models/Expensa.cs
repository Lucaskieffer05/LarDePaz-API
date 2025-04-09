using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LarDePaz_API.Models
{
    public class Expensa : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public int ContratoExpensasHistorialId { get; set; }
        public int NumPeriodo { get; set; }
        public int YearPeriodo { get; set; }
        public int Importe { get; set; }
        public int ImportePagado { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public DateTime FechaPago { get; set; }
        public string Estado { get; set; } = null!;

        [ForeignKey("ContratoExpensasHistorialId")]
        public virtual ContratoExpensasHistorial ContratoExpensasHistorial { get; set; } = null!;

    }
}
