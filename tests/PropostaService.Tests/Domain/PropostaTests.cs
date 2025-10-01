using PropostaService.Domain.Entities;

namespace PropostaService.Tests.Domain
{
    public class PropostaTests
    {
        [Fact]
        public void Aprovar_QuandoPropostaEstaEmAnalise_DeveAlterarStatusParaAprovada()
        {
            var proposta = new Proposta("Cliente Teste", 1000);

            proposta.Aprovar();

            Assert.Equal(StatusProposta.Aprovada, proposta.Status);
        }

        [Fact]
        public void Aprovar_QuandoPropostaJaEstaAprovada_DeveLancarExcecao()
        {
            var proposta = new Proposta("Cliente Teste", 1000);
            proposta.Aprovar(); // Aprovando uma primeira vez

            var exception = Assert.Throws<InvalidOperationException>(() => proposta.Aprovar());

            Assert.Equal("Só é possível aprovar uma proposta que está em análise.", exception.Message);
        }
    }
}