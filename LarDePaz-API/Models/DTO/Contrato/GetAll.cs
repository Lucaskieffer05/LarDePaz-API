using static LarDePaz_API.Models.DTO.Contrato.GetOneResponse;

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
            public int SaldoExpensas { get; set; }
            public int CantidadParcelas { get; set; }
            public string Estado { get; set; } = null!;

            public List<ParcelaDTO> Parcelas { get; set; } = [];
            public List<ExpensaDTO> Expensas { get; set; } = [];

            public class ParcelaDTO
            {
                public int Id { get; set; }
            }

            public class ExpensaDTO
            {
                public int Id { get; set; }
                public int Importe { get; set; }
                public int ImportePagado { get; set; }
                public string Estado { get; set; } = null!;
            }


        }

    }
}
