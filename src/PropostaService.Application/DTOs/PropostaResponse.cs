namespace PropostaService.Application.DTOs
{
    public class PropostaResponse
    {
        public Guid Id { get; set; }
        public string NomeCliente { get; set; }
        public decimal Valor { get; set; }
        public string Status { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}