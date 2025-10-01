using System.ComponentModel.DataAnnotations;

namespace PropostaService.Application.DTOs
{
    public class CriarPropostaRequest
    {
        [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do cliente deve ter entre 3 e 100 caracteres.")]
        public string NomeCliente { get; set; }

        [Range(1, 1000000, ErrorMessage = "O valor da proposta deve ser entre 1 e 1.000.000.")]
        public decimal Valor { get; set; }
    }
}