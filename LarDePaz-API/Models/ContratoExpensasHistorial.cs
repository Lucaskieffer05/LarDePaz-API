using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LarDePaz_API.Models
{
    public class ContratoExpensasHistorial : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public int ImporteTotalPagado { get; set; }
        public int ImporteTotalExpensa { get; set; }
        public int Saldo { get; set; }

        public List<Expensa> Expensas { get; set; } = [];
    }
}
