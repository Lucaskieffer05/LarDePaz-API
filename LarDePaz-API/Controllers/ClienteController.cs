using LarDePaz_API.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using LarDePaz_API.Services;
using LarDePaz_API.Models.Constants;
using Microsoft.AspNetCore.Authorization;
using LarDePaz_API.Models.DTO.Cliente;

namespace LarDePaz_API.Controllers
{
    [Authorize(Policy = Policies.Admin)]
    public class ClienteController(ClienteService clienteService) : BaseController
    {
        private readonly ClienteService _clienteService = clienteService;

        #region CRUD
        [HttpGet]
        public async Task<BaseResponse<GetAllResponse>> GetAll([FromQuery] GetAllRequest rq)
        {
            return await _clienteService.GetAll(rq);
        }

        [HttpGet]
        public async Task<BaseResponse<GetOneResponse>> GetOne([FromQuery] GetOneRequest rq)
        {
            return await _clienteService.GetOne(rq);
        }

        [HttpPost]
        public async Task<BaseResponse<CreateResponse>> Create([FromBody] CreateRequest rq)
        {
            return await _clienteService.Create(rq);
        }

        [HttpPost]
        public async Task<BaseResponse> Update([FromBody] UpdateRequest rq)
        {
            return await _clienteService.Update(rq);
        }

        [HttpPost]
        public async Task<BaseResponse> Delete([FromBody] DeleteRequest rq)
        {
            return await _clienteService.Delete(rq);
        }
        #endregion
    }
}
