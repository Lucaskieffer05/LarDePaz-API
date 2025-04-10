using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LarDePaz_API.Models
{
    public class Parcela : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public int ZonaId { get; set; }

        public string Fila { get; set; } = null!;
        public string Columna { get; set; } = null!;

        [ForeignKey("ZonaId")]
        public virtual Zona? Zona { get; set; }

        public List<ParcelaContratoHistorial> ContratosHistorial { get; set; } = [];
    }
}
