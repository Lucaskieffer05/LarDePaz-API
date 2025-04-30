namespace LarDePaz_API.Models.DTO.Manzana
{
    public class GetAllRequest : PaginateRequest
    {
    }

    public class GetAllResponse
    {
        public List<ManzanaDTO> Manzanas { get; set; } = [];
        public class ManzanaDTO
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = null!;
            public string? Descripcion { get; set; }
            public int NumFilasMaximas { get; set; }
            public int NumColumnasMaximas { get; set; }
            public int PrecioExpensa { get; set; }
            public DateTime CreatedAt { get; set; }
        }
    }
}
