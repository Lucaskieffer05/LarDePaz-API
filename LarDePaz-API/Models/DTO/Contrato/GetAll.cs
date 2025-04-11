namespace LarDePaz_API.Models.DTO.Contrato
{
    public class GetAllRequest : PaginateRequest
    {
    }

    public class GetAllResponse
    {
        public List<ContratoDTO> Contratos { get; set; } = [];

        public class ContratoDTO
        {
            public int Id { get; set; }
            public int CobradorId { get; set; }
            public int TitularId { get; set; }
            public string NombreCoTitular { get; set; } = null!;
            public string? NombreSegundoTitular { get; set; }
            public DateTime FechaContrato { get; set; }
            public int Saldo { get; set; }
            public int CantidadParcelas { get; set; }
            public string Estado { get; set; } = null!;
        }

    }
}
