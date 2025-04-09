using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LarDePaz_API.Models
{
    public class ContratoExpensasHistorial : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public int ContratoId { get; set; }
        public int ImporteTotalPagado { get; set; }
        public int ImporteTotalExpensa { get; set; }
        public int Saldo { get; set; }

        [ForeignKey("ContratoId")]
        public virtual Contrato Contrato { get; set; } = null!;

        public List<Expensa> Expensas { get; set; } = [];
    }
}
