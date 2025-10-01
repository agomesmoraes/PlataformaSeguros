using PropostaService.Application.DTOs;
using PropostaService.Application.Interfaces;
using PropostaService.Domain.Entities;
using PropostaService.Domain.Interfaces;

namespace PropostaService.Application.Services
{
    public class PropostaAppService : IPropostaAppService
    {
        private readonly IPropostaRepository _propostaRepository;

        public PropostaAppService(IPropostaRepository propostaRepository)
        {
            _propostaRepository = propostaRepository;
        }

        public async Task<PropostaResponse> CriarPropostaAsync(CriarPropostaRequest request)
        {
            var proposta = new Proposta(request.NomeCliente, request.Valor);

            await _propostaRepository.AddAsync(proposta);

            return MapPropostaToResponse(proposta);
        }

        public async Task AprovarPropostaAsync(Guid id)
        {
            var proposta = await _propostaRepository.GetByIdAsync(id);

            if (proposta == null)
                throw new KeyNotFoundException("Proposta não encontrada.");

            proposta.Aprovar();

            await _propostaRepository.UpdateAsync(proposta);
        }

        public async Task RejeitarPropostaAsync(Guid id)
        {
            var proposta = await _propostaRepository.GetByIdAsync(id);
            if (proposta == null)
                throw new KeyNotFoundException("Proposta não encontrada.");

            proposta.Rejeitar();

            await _propostaRepository.UpdateAsync(proposta);
        }

        public async Task<IEnumerable<PropostaResponse>> GetAllAsync()
        {
            var propostas = await _propostaRepository.GetAllAsync();
            return propostas.Select(MapPropostaToResponse);
        }

        public async Task<PropostaResponse?> GetByIdAsync(Guid id)
        {
            var proposta = await _propostaRepository.GetByIdAsync(id);
            return proposta == null ? null : MapPropostaToResponse(proposta);
        }

        private PropostaResponse MapPropostaToResponse(Proposta proposta)
        {
            return new PropostaResponse
            {
                Id = proposta.Id,
                NomeCliente = proposta.NomeCliente,
                Valor = proposta.Valor,
                Status = proposta.Status.ToString(),
                DataCriacao = proposta.DataCriacao
            };
        }
    }
}