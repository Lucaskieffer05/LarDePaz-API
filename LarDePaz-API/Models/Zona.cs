using System.ComponentModel.DataAnnotations;
namespace LarDePaz_API.Models
{
    public class Zona : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
    }
}
