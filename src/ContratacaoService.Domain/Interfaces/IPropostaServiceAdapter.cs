using ContratacaoService.Domain.DTOs;

namespace ContratacaoService.Domain.Interfaces
{
    public interface IPropostaServiceAdapter
    {
        Task<PropostaStatusDto?> GetPropostaStatusAsync(Guid propostaId);
    }
}