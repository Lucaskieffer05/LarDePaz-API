using LarDePaz_API.DAL.DB;
using LarDePaz_API.Models.DTO;
using LarDePaz_API.Models.DTO.Parcela;
using Microsoft.EntityFrameworkCore;

namespace LarDePaz_API.Services
{
    public class ParcelaService(APIContext context)
    {
        private readonly APIContext _db = context;
        public async Task<BaseResponse<GetByZonaIdResponse>> GetByZonaId(GetByZonaIdRequest rq)
        {
            var response = new BaseResponse<GetByZonaIdResponse>();
            var query = _db.Parcela.AsQueryable();
            response.Data = new GetByZonaIdResponse
            {
                Parcelas = await query
                    .Where(p => (p.ZonaId == rq.ZonaId && p.ContratoId == null))
                    .Select(p => new ParcelaDTO
                    {
                        Id = p.Id,
                        Fila = p.Fila,
                        Columna = p.Columna
                    })
                    .ToListAsync()
            };
            return response;
        }
    }
}
