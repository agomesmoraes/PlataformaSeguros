using Microsoft.AspNetCore.Mvc;
using PropostaService.Application.DTOs;
using PropostaService.Application.Interfaces;

namespace PropostaService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropostasController : ControllerBase
    {
        private readonly IPropostaAppService _propostaAppService;

        public PropostasController(IPropostaAppService propostaAppService)
        {
            _propostaAppService = propostaAppService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarProposta([FromBody] CriarPropostaRequest request)
        {
            var propostaResponse = await _propostaAppService.CriarPropostaAsync(request);
            
            return CreatedAtAction(nameof(GetPropostaById), new { id = propostaResponse.Id }, propostaResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPropostas()
        {
            var propostas = await _propostaAppService.GetAllAsync();
            return Ok(propostas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPropostaById(Guid id)
        {
            var proposta = await _propostaAppService.GetByIdAsync(id);
            if (proposta == null)
            {
                return NotFound();
            }
            return Ok(proposta);
        }

        [HttpPut("{id}/aprovar")]
        public async Task<IActionResult> AprovarProposta(Guid id)
        {
            try
            {
                await _propostaAppService.AprovarPropostaAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/rejeitar")]
        public async Task<IActionResult> RejeitarProposta(Guid id)
        {
            try
            {
                await _propostaAppService.RejeitarPropostaAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}