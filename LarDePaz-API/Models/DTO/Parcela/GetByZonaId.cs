namespace LarDePaz_API.Models.DTO.Parcela
{
    public class GetByZonaIdRequest
    {
        public int ZonaId { get; set; }
    }
    public class GetByZonaIdResponse
    {
        public List<ParcelaDTO> Parcelas { get; set; } = new(); 
    }
    public class ParcelaDTO
    {
        public int Id { get; set; }
        public int Fila { get; set; }
        public int Columna { get; set; }
    }
}
