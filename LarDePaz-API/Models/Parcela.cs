using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LarDePaz_API.Models
{
    public class Parcela : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public int ZonaParcelaId { get; set; }
        public string Fila { get; set; } = null!;
        public string Columna { get; set; } = null!;

        [ForeignKey("ZonaParcelaId")]
        public virtual ZonaParcela ZonaParcela { get; set; } = null!;

        public List<ParcelaContratoHistorial> ContratosHistorial { get; set; } = [];
    }
}
