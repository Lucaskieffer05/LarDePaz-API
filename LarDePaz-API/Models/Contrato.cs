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
        public int ContratoCuotaHistorialId { get; set; }
        public int ContratoExpensasHistorialId { get; set; }

        //Campos para el COtitular
        public string NombreCoTitular { get; set; } = null!;
        public string DNICoTitular { get; set; } = null!;
        public string DireccionCoTitular { get; set; } = null!;
        public string LocalidadCoTitular { get; set; } = null!;
        public string ProvinciaCoTitular { get; set; } = null!;
        public string TelefonoCoTitular { get; set; } = null!;
        public string? TelefonoCoTitular2 { get; set; }
        public string? EmailCoTitular { get; set; }
        public string? RedSocialCoTitular { get; set; }

        //Campos para el Segundo Titular
        public string? NombreSegundoTitular { get; set; }
        public string? DNISegundoTitular { get; set; }
        public string? DireccionSegundoTitular { get; set; }
        public string? LocalidadSegundoTitular { get; set; }
        public string? ProvinciaSegundoTitular { get; set; }
        public string? TelefonoSegundoTitular { get; set; }
        public string? TelefonoSegundoTitular2 { get; set; }
        public string? EmailSegundoTitular { get; set; }
        public string? RedSocialSegundoTitular { get; set; }


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

        [ForeignKey("TitularId")]
        public virtual Cliente Titular { get; set; } = null!;

        [ForeignKey("CobradorId")]
        public virtual Cobrador? Cobrador { get; set; }

        [ForeignKey("ContratoCuotaHistorialId")]
        public virtual ContratoCuotaHistorial ContratoCuotaHistorial { get; set; } = null!;

        [ForeignKey("ContratoExpensasHistorialId")]
        public virtual ContratoExpensasHistorial ContratoExpensasHistorial { get; set; } = null!;

        public List<Parcela> Parcelas { get; set; } = [];


    }
}
