using LarDePaz_API.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using LarDePaz_API.Services;

namespace LarDePaz_API.Controllers
{
    public class ClienteController(ClienteService clienteService) : BaseController
    {
        private readonly ClienteService _clienteService = clienteService;

        
    }
}
