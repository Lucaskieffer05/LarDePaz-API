using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LarDePaz_API.Models
{
    public class Cobrador : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public int ZonaId { get; set; }

        public string NombreApellido { get; set; } = null!;
        public string DNI { get; set; } = null!;
        public string? Telefono { get; set; }
        public string? ZonaDeCobro { get; set; }
    }
}
