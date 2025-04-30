using LarDePaz_API.DAL.DB;
using LarDePaz_API.Models.DTO;
using LarDePaz_API.Models.DTO.Zona;
using Microsoft.EntityFrameworkCore;

namespace LarDePaz_API.Services
{
    public class ZonaService(APIContext context)
    {
        private readonly APIContext _db = context;

        public async Task<BaseResponse<GetByManzanaIdResponse>> GetByManzanaId(GetByManzanaIdRequest rq)
        {
            var response = new BaseResponse<GetByManzanaIdResponse>();

            var query = _db.Zona.AsQueryable();

            response.Data = new GetByManzanaIdResponse
            {
                Zonas = await query
                    .Where(z => z.ManzanaId == rq.ManzanaId)
                    .Select(z => new ZonaDTO
                    {
                        Id = z.Id,
                        Numero = z.Numero,
                        NombreDescriptivo = z.NombreDescriptivo,
                        PrecioCompra = z.PrecioCompra
                    })
                    .ToListAsync()

            };

            return response;
        }
    }
}
