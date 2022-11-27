using DataServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OcorrencyAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidosController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _pedidoService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Pedido pedido)
        {
            if (pedido == null) return BadRequest(pedido);
            var result = await _pedidoService.SaveAsync(pedido);
            return Created($"api/Form/{result.IdPedido}", result);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] Pedido Pedido)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var oldModel = await _pedidoService.SearchAsync(Pedido.IdPedido);
            if (oldModel == null)
                return NotFound();
            await _pedidoService.SaveAsync(Pedido);
            return Ok(Pedido);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int pedidoId)
        {
            if (pedidoId == 0) return BadRequest("pedido inválido");
            var result = await _pedidoService.SearchAsync(pedidoId);
            if (result == null) NotFound("Pedido não encontrado");

            await _pedidoService.DeleteAsync(pedidoId);
            return Ok("pedido deletado com sucesso");
        }
    }
}
