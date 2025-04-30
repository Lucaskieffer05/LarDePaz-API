using LarDePaz_API.Models.Constants;
using LarDePaz_API.Services;
using Microsoft.AspNetCore.Mvc;
using LarDePaz_API.Models.DTO;
using LarDePaz_API.Models.DTO.Parcela;
using Microsoft.AspNetCore.Authorization;

namespace LarDePaz_API.Controllers
{
    [Authorize(Policy = Policies.Admin)]
    public class ParcelaController(ParcelaService parcelaService) : BaseController
    {
        private readonly ParcelaService _parcelaService = parcelaService;

        [HttpGet]
        public async Task<BaseResponse<GetByZonaIdResponse>> GetByZonaId([FromQuery] GetByZonaIdRequest rq)
        {
            return await _parcelaService.GetByZonaId(rq);
        }
    }
}
