using LarDePaz_API.Models.Constants;
using LarDePaz_API.Models.DTO.Zona;
using LarDePaz_API.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using LarDePaz_API.Services;
using Microsoft.AspNetCore.Authorization;

namespace LarDePaz_API.Controllers
{
    [Authorize(Policy = Policies.Admin)]
    public class ZonaController(ZonaService zonaService) : BaseController
    {
        private readonly ZonaService _zonaService = zonaService;

        [HttpGet]
        public async Task<BaseResponse<GetByManzanaIdResponse>> GetByManzanaId([FromQuery] GetByManzanaIdRequest rq)
        {
            return await _zonaService.GetByManzanaId(rq);
        }
    }
}
