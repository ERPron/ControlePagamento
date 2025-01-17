using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _clienteService.GetAllAsync();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            var data = await _clienteService.GetByIdAsync(id);
            return Ok(data);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(ClienteDTO clienteDTO)
        {
            var data = await _clienteService.AddAsync(clienteDTO);
            return Ok(data);
        }
    }
}
