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
    public class OcorrenciasController : ControllerBase
    {
        private readonly IOcorrenciaService _ocorrencyService;

        public OcorrenciasController(IOcorrenciaService ocorrencyService)
        {
            _ocorrencyService = ocorrencyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _ocorrencyService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]Ocorrencia ocorrência)
        {
            if (ocorrência == null) return BadRequest(ocorrência);
            var result = await _ocorrencyService.SaveAsync(ocorrência);
            return Created($"api/Form/{result.IdOcorrencia}", result);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] Ocorrencia ocorrencia)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var oldModel = await _ocorrencyService.SearchAsync(ocorrencia.IdOcorrencia);
            if (oldModel == null)
                return NotFound();
            await _ocorrencyService.SaveAsync(ocorrencia);
            return Ok(ocorrencia);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int ocorrenciId)
        {
            if (ocorrenciId == 0) return BadRequest("Ocorrência inválida");
            var result = await _ocorrencyService.SearchAsync(ocorrenciId);
            if (result == null) NotFound("Ocorrencia não encontrada");

            await _ocorrencyService.DeleteAsync(ocorrenciId);
            return Ok("Ocorrência deletada com sucesso");
        }
    }
}
