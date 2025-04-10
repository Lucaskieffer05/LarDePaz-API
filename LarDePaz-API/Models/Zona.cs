using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LarDePaz_API.Models
{
    public class Zona : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public int ManzanaId { get; set; }

        public int Numero { get; set; }
        public string? NombreDescriptivo { get; set; }
        public int PrecioCompra { get; set; }


        [ForeignKey("ManzanaId")]
        public virtual Manzana Manzana { get; set; } = null!;

        public List<Parcela> Parcelas { get; set; } = [];


    }
}
