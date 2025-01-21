using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentosController : ControllerBase
    {
        private readonly IPagamentoService _pagamentoService;
        public PagamentosController(IPagamentoService pagamentoService)
        {
            _pagamentoService = pagamentoService;
        }

        [HttpGet]
        [Route("GetByClienteIdAsync")]
        public async Task<IActionResult> GetByClienteIdAsync(string clienteId)
        {

            var data = await _pagamentoService.GetByClienteIdAsync(int.Parse(clienteId));
            return Ok(data);
        }

        [HttpGet]
        [Route("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var data = await _pagamentoService.GetByIdAsync(int.Parse(id));
            return Ok(data);
        }

        [HttpPost]
        [Route("AddAsync")]
        public async Task<IActionResult> AddAsync(PagamentoDTO pagamentoDTO)
        {
            var data = await _pagamentoService.AddAsync(pagamentoDTO);
            return Ok(data);
        }

        [HttpPost]
        [Route("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(PagamentoDTO pagamentoDTO)
        {
            var data = await _pagamentoService.UpdateAsync(pagamentoDTO);
            return Ok(data);
        }
    }
}
