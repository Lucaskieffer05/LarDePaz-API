using LarDePaz_API.DAL.DB;
using LarDePaz_API.Models;
using LarDePaz_API.Models.Constants;
using LarDePaz_API.Models.DTO;
using LarDePaz_API.Models.DTO.Cliente;
using Microsoft.EntityFrameworkCore;
namespace LarDePaz_API.Services
{
    public class ClienteService(APIContext context)
    {
        private readonly APIContext _db = context;
        
        public async Task<BaseResponse<GetAllResponse>> GetAll(GetAllRequest rq)
        {
            var response = new BaseResponse<GetAllResponse>();

            var query = _db.Cliente.AsQueryable();

            query = OrderQuery(query, rq);

            response.Data = new GetAllResponse
            {
                Clientes = await query
                    .Skip(rq.Page * rq.PageSize)
                    .Take(rq.PageSize)
                    .Select(x => new GetAllResponse.Item
                    {
                        Id = x.Id,
                        NombreApellido = x.NombreApellido,
                        DNI = x.DNI,
                        Direccion = x.Direccion,
                        Localidad = x.Localidad,
                        Provincia = x.Provincia,
                        Telefone = x.Telefono1,
                        CreatedAt = x.CreatedAt
                    })
                    .ToListAsync()
            };

            return response;

        }


        




        private static IQueryable<Cliente> OrderQuery(IQueryable<Cliente> query, PaginateRequest rq)
        {
            return rq.ColumnSort switch
            {
                "nombreapellido" => rq.SortDirection == SortDirectionCode.ASC ? query.OrderBy(x => x.NombreApellido) : query.OrderByDescending(x => x.NombreApellido),
                "createdAt" => rq.SortDirection == SortDirectionCode.ASC ? query.OrderBy(x => x.CreatedAt) : query.OrderByDescending(x => x.CreatedAt),
                _ => query.OrderByDescending(x => x.NombreApellido),
            };
        }


    }
}
