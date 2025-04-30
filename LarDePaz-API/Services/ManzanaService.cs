using LarDePaz_API.DAL.DB;
using LarDePaz_API.Models.DTO;
using LarDePaz_API.Models.DTO.Manzana;
using Microsoft.EntityFrameworkCore;

namespace LarDePaz_API.Services
{
    public class ManzanaService(APIContext context)
    {
        private readonly APIContext _db = context;

        public async Task<BaseResponse<GetAllResponse>> GetAll(GetAllRequest rq)
        {
            var response = new BaseResponse<GetAllResponse>();

            var query = _db.Manzana.AsQueryable();

            response.Data = new GetAllResponse
            {
                Manzanas = await query
                    .Select(x => new GetAllResponse.ManzanaDTO
                    {
                        Id = x.Id,
                        Nombre = x.Nombre,
                        Descripcion = x.Descripcion,
                        NumFilasMaximas = x.NumFilasMaximas,
                        NumColumnasMaximas = x.NumColumnasMaximas,
                        PrecioExpensa = x.PrecioExpesa,
                        CreatedAt = x.CreatedAt
                    })
                    .ToListAsync()
            };
            return response;
        }

    }
}
