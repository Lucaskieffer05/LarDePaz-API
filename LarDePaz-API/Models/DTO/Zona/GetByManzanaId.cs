namespace LarDePaz_API.Models.DTO.Zona
{
    public class GetByManzanaIdRequest
    {
        public int ManzanaId { get; set; }
    }

    public class GetByManzanaIdResponse
    {
        public List<ZonaDTO> Zonas { get; set; } = new();
    }

    public class ZonaDTO
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string? NombreDescriptivo { get; set; }
        public int PrecioCompra { get; set; }
    }
}
