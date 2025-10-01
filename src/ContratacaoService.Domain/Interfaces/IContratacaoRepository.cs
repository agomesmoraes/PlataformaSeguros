using ContratacaoService.Domain.Entities;

namespace ContratacaoService.Domain.Interfaces
{
    public interface IContratacaoRepository
    {
        Task AddAsync(Contratacao contratacao);
        Task<Contratacao?> GetByPropostaIdAsync(Guid propostaId);
    }
}