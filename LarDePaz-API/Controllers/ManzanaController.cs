using LarDePaz_API.Models.Constants;
using LarDePaz_API.Services;
using Microsoft.AspNetCore.Mvc;
using LarDePaz_API.Models.DTO;
using LarDePaz_API.Models.DTO.Manzana;
using Microsoft.AspNetCore.Authorization;

namespace LarDePaz_API.Controllers
{
    [Authorize(Policy = Policies.Admin)]
    public class ManzanaController(ManzanaService manzanaService) : BaseController
    {
        private readonly ManzanaService _manzanaService = manzanaService;

        [HttpGet]
        public async Task<BaseResponse<GetAllResponse>> GetAll([FromQuery] GetAllRequest rq)
        {
            return await _manzanaService.GetAll(rq);
        }

    }
}
