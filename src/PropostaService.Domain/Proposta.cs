namespace PropostaService.Domain.Entities
{
    public class Proposta
    {
        public Guid Id { get; private set; }
        public string NomeCliente { get; private set; }
        public decimal Valor { get; private set; }
        public StatusProposta Status { get; private set; }
        public DateTime DataCriacao { get; private set; }

        private Proposta() { }

        public Proposta(string nomeCliente, decimal valor)
        {
            if (string.IsNullOrWhiteSpace(nomeCliente))
                throw new ArgumentException("O nome do cliente não pode ser vazio.", nameof(nomeCliente));

            if (valor <= 0)
                throw new ArgumentException("O valor da proposta deve ser positivo.", nameof(valor));

            Id = Guid.NewGuid();
            NomeCliente = nomeCliente;
            Valor = valor;
            Status = StatusProposta.EmAnalise;
            DataCriacao = DateTime.UtcNow;
        }

        public void Aprovar()
        {
            if (Status != StatusProposta.EmAnalise)
            {
                throw new InvalidOperationException("Só é possível aprovar uma proposta que está em análise.");
            }
            Status = StatusProposta.Aprovada;
        }

        public void Rejeitar()
        {
            if (Status != StatusProposta.EmAnalise)
            {
                throw new InvalidOperationException("Só é possível rejeitar uma proposta que está em análise.");
            }
            Status = StatusProposta.Rejeitada;
        }
    }
}