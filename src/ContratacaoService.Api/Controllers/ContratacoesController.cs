using ContratacaoService.Application.DTOs;
using ContratacaoService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContratacaoService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContratacoesController : ControllerBase
    {
        private readonly IContratacaoAppService _appService;

        public ContratacoesController(IContratacaoAppService appService)
        {
            _appService = appService;
        }

        [HttpPost]
        public async Task<IActionResult> ContratarProposta([FromBody] ContratarPropostaRequest request)
        {
            try
            {
                var response = await _appService.ContratarPropostaAsync(request);
                return Ok(response);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Ocorreu um erro interno: {ex.Message}" });
            }
        }
    }
}