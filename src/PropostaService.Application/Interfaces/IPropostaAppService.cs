using PropostaService.Application.DTOs;

namespace PropostaService.Application.Interfaces
{
    public interface IPropostaAppService
    {
        Task<PropostaResponse> CriarPropostaAsync(CriarPropostaRequest request);
        Task<PropostaResponse?> GetByIdAsync(Guid id);
        Task<IEnumerable<PropostaResponse>> GetAllAsync();
        Task AprovarPropostaAsync(Guid id);
        Task RejeitarPropostaAsync(Guid id);
    }
}