using ContratacaoService.Api.Data;
using ContratacaoService.Domain.Entities;
using ContratacaoService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContratacaoService.Api.Repositories
{
    public class ContratacaoRepository : IContratacaoRepository
    {
        private readonly AppDbContext _context;

        public ContratacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Contratacao contratacao)
        {
            await _context.Contratacoes.AddAsync(contratacao);
            await _context.SaveChangesAsync();
        }

        public async Task<Contratacao?> GetByPropostaIdAsync(Guid propostaId)
        {
            return await _context.Contratacoes
                .FirstOrDefaultAsync(c => c.PropostaId == propostaId);
        }
    }
}