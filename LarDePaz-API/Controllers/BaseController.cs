using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace LarDePaz_API.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]

    public class BaseController : ControllerBase
    {
    }
        
}
