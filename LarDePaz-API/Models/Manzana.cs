using System.ComponentModel.DataAnnotations;
namespace LarDePaz_API.Models
{
    public class Manzana : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int NumFilasMaximas { get; set; }
        public int NumColumnasMaximas { get; set; }
        public int PrecioExpesa { get; set; }

        public List<Zona> Zonas { get; set; } = [];
    }
}
