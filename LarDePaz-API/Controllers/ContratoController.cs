using LarDePaz_API.Models.Constants;
using LarDePaz_API.Models.DTO;
using LarDePaz_API.Services;
using Microsoft.AspNetCore.Authorization;
using LarDePaz_API.Models.DTO.Contrato;
using Microsoft.AspNetCore.Mvc;

namespace LarDePaz_API.Controllers
{
    [Authorize(Policy = Policies.Admin)]
    public class ContratoController (ContratoService contratoService) : BaseController
    {
        private readonly ContratoService _contratoService = contratoService;


        [HttpGet]
        public async Task<BaseResponse<GetAllResponse>> GetAll([FromQuery] GetAllRequest rq)
        {
            return await _contratoService.GetAll(rq);
        }

        [HttpGet]
        public async Task<BaseResponse<GetOneResponse>> GetOne([FromQuery] GetOneRequest rq)
        {
            return await _contratoService.GetOne(rq);
        }

        [HttpPost]
        public async Task<BaseResponse<CreateResponse>> Create([FromBody] CreateRequest rq)
        {
            return await _contratoService.Create(rq);
        }

        [HttpPost]
        public async Task<BaseResponse> Update([FromBody] UpdateRequest rq)
        {
            return await _contratoService.Update(rq);
        }

    }
}
