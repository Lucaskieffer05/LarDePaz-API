using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LarDePaz_API.Models
{
    public class Contrato : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public int CobradorId { get; set; }
        public int TitularId { get; set; }
        public int CoTitularId { get; set; }
        public int SegundoTitularId { get; set; }
        public int ContratoCuotaHistorialId { get; set; }
        public int ContratoExpensasHistorialId { get; set; }
        public string LugarPago { get; set; } = null!;
        public string DireccionPago { get; set; } = null!;
        public string LocalidadPago { get; set; } = null!;
        public string ProvinciaPago { get; set; } = null!;
        public string? Tarjeta { get; set; }
        public DateTime FechaContrato { get; set; } = DateTime.Now;
        public int Saldo { get; set; }
        public int CantidadCuotas { get; set; }
        public int CuotasEmitidas { get; set; }
        public int PagoAcumulado { get; set; }
        public int CantidadParcelas { get; set; }
        public string Estado { get; set; } = null!;

        [ForeignKey("CobradorId")]
        public virtual Cobrador Cobrador { get; set; } = null!;

        [ForeignKey("TitularId")]
        public virtual Cliente Titular { get; set; } = null!;

        [ForeignKey("CoTitularId")]
        public virtual Cliente CoTitular { get; set; } = null!;

        [ForeignKey("SegundoTitularId")]
        public virtual Cliente SegundoTitular { get; set; } = null!;

        [ForeignKey("ContratoCuotaHistorialId")]
        public virtual ContratoCuotaHistorial ContratoCuotaHistorial { get; set; } = null!;

        [ForeignKey("ContratoExpensasHistorialId")]
        public virtual ContratoExpensasHistorial ContratoExpensasHistorial { get; set; } = null!;

        public List<Parcela> Parcelas { get; set; } = [];


    }
}
