using ContratacaoService.Application.DTOs;
using ContratacaoService.Application.Interfaces;
using ContratacaoService.Domain.Entities;
using ContratacaoService.Domain.Interfaces;

namespace ContratacaoService.Application.Services
{
    public class ContratacaoAppService : IContratacaoAppService
    {
        private readonly IContratacaoRepository _contratacaoRepository;
        private readonly IPropostaServiceAdapter _propostaServiceAdapter;

        public ContratacaoAppService(
            IContratacaoRepository contratacaoRepository,
            IPropostaServiceAdapter propostaServiceAdapter)
        {
            _contratacaoRepository = contratacaoRepository;
            _propostaServiceAdapter = propostaServiceAdapter;
        }

        public async Task<ContratacaoResponse> ContratarPropostaAsync(ContratarPropostaRequest request)
        {
            var existente = await _contratacaoRepository.GetByPropostaIdAsync(request.PropostaId);
            if (existente != null)
            {
                throw new InvalidOperationException("Esta proposta já foi contratada.");
            }

            var propostaStatusDto = await _propostaServiceAdapter.GetPropostaStatusAsync(request.PropostaId);

            if (propostaStatusDto == null)
            {
                throw new KeyNotFoundException("Proposta não encontrada no serviço de propostas.");
            }

            if (propostaStatusDto.Status != "Aprovada")
            {
                throw new InvalidOperationException($"Não é possível contratar uma proposta com status '{propostaStatusDto.Status}'.");
            }

            var novaContratacao = new Contratacao(request.PropostaId);

            await _contratacaoRepository.AddAsync(novaContratacao);

            return new ContratacaoResponse
            {
                Id = novaContratacao.Id,
                PropostaId = novaContratacao.PropostaId,
                DataContratacao = novaContratacao.DataContratacao
            };
        }
    }
}