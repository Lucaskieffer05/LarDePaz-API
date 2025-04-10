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

        public int Fila { get; set; } 
        public int Columna { get; set; }

        [ForeignKey("ZonaId")]
        public virtual Zona? Zona { get; set; }

        public List<ParcelaContratoHistorial> ContratosHistorial { get; set; } = [];
    }
}
