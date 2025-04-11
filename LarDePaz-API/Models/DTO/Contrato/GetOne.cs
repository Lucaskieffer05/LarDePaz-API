using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LarDePaz_API.Models.DTO.Contrato
{
    public class GetOneRequest
    {
        public int Id { get; set; }
    }

    public class GetOneResponse
    {
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

        public ClienteDTO Titular { get; set; } = null!;
        public CobradorDTO? Cobrador { get; set; } = null!;
        public ContratoCuotaHistorialDTO ContratoCuotaHistorial { get; set; } = null!;
        public ContratoExpensasHistorialDTO ContratoExpensasHistorial { get; set; } = null!;
        public List<ParcelaDTO> Parcelas { get; set; } = [];

        public class ClienteDTO
        {
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

        public class CobradorDTO
        {
            public int Id { get; set; }
            public string NombreApellido { get; set; } = null!;
            public string DNI { get; set; } = null!;
            public string? Telefono { get; set; }
            public string? ZonaDeCobro { get; set; }
        }

        public class ContratoCuotaHistorialDTO
        {
            public int Id { get; set; }
            public int ImporteTotalPagado { get; set; }
            public int ImporteTotalCuota { get; set; }
            public int Saldo { get; set; }
            public List<CuotaDTO> Cuotas { get; set; } = [];
            public class CuotaDTO
            {
                public int Id { get; set; }
                public string NumeroCuota { get; set; } = null!;
                public DateTime FechaEmitida { get; set; }
                public DateTime FechaVencimiento { get; set; }
                public DateTime FechaPago { get; set; }
                public int Importe { get; set; }
                public int importePagado { get; set; }
                public int ImporteInteres { get; set; }
                public int ImporteTotal { get; set; }
                public string Estado { get; set; } = null!;
            }
        }

        public class ContratoExpensasHistorialDTO
        {
            public int Id { get; set; }
            public int ImporteTotalPagado { get; set; }
            public int ImporteTotalExpensa { get; set; }
            public int Saldo { get; set; }
            public List<ExpensaDTO> Expensas { get; set; } = [];
            public class ExpensaDTO
            {
                public int Id { get; set; }
                public int NumPeriodo { get; set; }
                public int YearPeriodo { get; set; }
                public int Importe { get; set; }
                public int ImportePagado { get; set; }
                public DateTime FechaDesde { get; set; }
                public DateTime FechaHasta { get; set; }
                public DateTime FechaPago { get; set; }
                public string Estado { get; set; } = null!;
            }
        }

        public class ParcelaDTO
        {
            public int Id { get; set; }
            public int Fila { get; set; }
            public int Columna { get; set; }
            public ZonaDTO Zona { get; set; } = null!;

            public class ZonaDTO
            {
                public int Numero { get; set; }
                public string? NombreDescriptivo { get; set; }
                public MonzanaDTO Manzana { get; set; } = null!;

                public class MonzanaDTO
                {
                    public string Nombre { get; set; } = null!;
                    public string? Descripcion { get; set; }
                }
            }
        }


    }
}
