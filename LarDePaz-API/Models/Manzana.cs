using System.ComponentModel.DataAnnotations;
namespace LarDePaz_API.Models
{
    public class Manzana : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public string Nombre { get; set; } = null!;
        public int PrecioExpesa { get; set; }

        public List<ZonaParcela> ZonasPercelas { get; set; } = [];
    }
}
