using System.ComponentModel.DataAnnotations;

namespace ContratacaoService.Application.DTOs
{
    public class ContratarPropostaRequest
    {
        [Required(ErrorMessage = "O ID da proposta é obrigatório.")]
        public Guid PropostaId { get; set; }
    }
}