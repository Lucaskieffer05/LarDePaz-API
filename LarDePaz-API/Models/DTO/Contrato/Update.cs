namespace LarDePaz_API.Models.DTO.Contrato
{
    public class UpdateRequest
    {
        public int Id { get; set; }
        public int CobradorId { get; set; }
        public int TitularId { get; set; }

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
        public DateTime FechaContrato { get; set; }
    }
}
