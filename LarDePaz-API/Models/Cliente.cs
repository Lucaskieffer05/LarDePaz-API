using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LarDePaz_API.Models
{
    public class Cliente : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public string NombreApellido { get; set; } = null!;
        public string DNI { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Localidad { get; set; } = null!;
        public string Provincia { get; set; } = null!;
        public string Telefono1 { get; set; } = null!;
        public string? Telefono2 { get; set; }
        public string? Email { get; set; }
        public string? RedSocial { get; set; }

    }
}
