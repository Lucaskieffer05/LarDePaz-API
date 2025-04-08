using Microsoft.AspNetCore.Mvc;
using LarDePaz_API.Models.DTO.Auth;
using LarDePaz_API.Models.DTO;
using LarDePaz_API.Services;

namespace LarDePaz_API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController(AuthService authService) : ControllerBase
    {
        private readonly AuthService _authService = authService;

        [HttpPost]
        public async Task<BaseResponse<LoginResponse>> Login([FromBody] LoginRequest rq)
        {
            return await _authService.Login(rq);
        }


        [HttpPost]
        public BaseResponse Logout()
        {
            return _authService.Logout();
        }
    }
}
