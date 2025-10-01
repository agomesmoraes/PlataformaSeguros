using Microsoft.EntityFrameworkCore;
using PropostaService.Api.Data;
using PropostaService.Domain.Entities;
using PropostaService.Domain.Interfaces;

namespace PropostaService.Api.Repositories
{
    public class PropostaRepository : IPropostaRepository
    {
        private readonly AppDbContext _context;

        public PropostaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Proposta proposta)
        {
            await _context.Propostas.AddAsync(proposta);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Proposta>> GetAllAsync()
        {
            return await _context.Propostas.ToListAsync();
        }

        public async Task<Proposta?> GetByIdAsync(Guid id)
        {
            return await _context.Propostas.FindAsync(id);
        }

        public async Task UpdateAsync(Proposta proposta)
        {
            _context.Propostas.Update(proposta);
            await _context.SaveChangesAsync();
        }
    }
}