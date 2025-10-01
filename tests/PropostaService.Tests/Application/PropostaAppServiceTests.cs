using Moq;
using PropostaService.Application.DTOs;
using PropostaService.Application.Services;
using PropostaService.Domain.Entities;
using PropostaService.Domain.Interfaces;

namespace PropostaService.Tests.Application
{
    public class PropostaAppServiceTests
    {
        [Fact]
        public async Task CriarPropostaAsync_ComDadosValidos_DeveChamarAddAsyncDoRepositorio()
        {
            var request = new CriarPropostaRequest { NomeCliente = "Novo Cliente", Valor = 5000 };

            var mockRepository = new Mock<IPropostaRepository>();

            var appService = new PropostaAppService(mockRepository.Object);

            await appService.CriarPropostaAsync(request);

            mockRepository.Verify(repo => repo.AddAsync(It.IsAny<Proposta>()), Times.Once);
        }
    }
}