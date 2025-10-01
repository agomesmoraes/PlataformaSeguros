using ContratacaoService.Application.DTOs;

namespace ContratacaoService.Application.Interfaces
{
    public interface IContratacaoAppService
    {
        Task<ContratacaoResponse> ContratarPropostaAsync(ContratarPropostaRequest request);
    }
}