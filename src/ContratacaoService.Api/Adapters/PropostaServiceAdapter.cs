using ContratacaoService.Domain.DTOs;
using ContratacaoService.Domain.Interfaces;
using System.Text.Json;

namespace ContratacaoService.Api.Adapters
{
    public class PropostaServiceAdapter : IPropostaServiceAdapter
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public PropostaServiceAdapter(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<PropostaStatusDto?> GetPropostaStatusAsync(Guid propostaId)
        {
            var propostaServiceUrl = _configuration["PropostaServiceUrl"];
            var requestUrl = $"{propostaServiceUrl}/api/propostas/{propostaId}";

            var httpClient = _httpClientFactory.CreateClient();

            try
            {
                var response = await httpClient.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    var contentStream = await response.Content.ReadAsStreamAsync();
                    
                    return await JsonSerializer.DeserializeAsync<PropostaStatusDto>(contentStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }

                return null;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Erro ao comunicar com PropostaService: {ex.Message}");
                return null;
            }
        }
    }
}