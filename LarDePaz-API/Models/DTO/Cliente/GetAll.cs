namespace LarDePaz_API.Models.DTO.Cliente
{

    public class GetAllRequest : PaginateRequest
    {
    }

    public class GetAllResponse
    {
        public List<Item> Clientes { get; set; } = [];
        public class Item
        {
            public int Id { get; set; }
            public string NombreApellido { get; set; } = null!;
            public string DNI { get; set; } = null!;
            public string Direccion { get; set; } = null!;
            public string Localidad { get; set; } = null!;
            public string Provincia { get; set; } = null!;
            public string Telefone { get; set; } = null!;
            public DateTime CreatedAt { get; set; }
        }
    }

    

}
