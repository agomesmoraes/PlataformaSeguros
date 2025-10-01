# Plataforma de Seguros - Teste Técnico

Este projeto é uma implementação de um sistema de gerenciamento de propostas de seguro, desenvolvido como parte de um teste técnico. A solução utiliza uma arquitetura de microserviços e segue as melhores práticas de desenvolvimento de software.

## Arquitetura e Tecnologias

A solução foi construída utilizando os seguintes princípios e tecnologias:

- **Linguagem:** C# com .NET 9 
- **Arquitetura Principal:** Arquitetura Hexagonal (Ports & Adapters)
- **Padrões:** Domain-Driven Design (DDD), SOLID, Clean Architecture
- **Abordagem:** Microserviços
  - `PropostaService`: Responsável por todo o ciclo de vida da proposta.
  - `ContratacaoService`: Responsável por efetivar a contratação de propostas aprovadas.
- **Comunicação:** A comunicação entre os serviços é feita via API REST síncrona.
- **Banco de Dados:** Entity Framework Core com provedor In-Memory (atuando como dados mocados).
- **Testes:** Testes de Unidade com xUnit e Moq para validar as camadas de Domínio e Aplicação.

## Como Executar a Solução

### Pré-requisitos
- .NET 9 SDK

### Executando com o Visual Studio
1. Clone este repositório.
2. Abra o arquivo de solução (`.sln`) no Visual Studio.
3. Configure a solução para iniciar múltiplos projetos:
   - Clique com o botão direito na Solução > `Definir Projetos de Inicialização...`.
   - Selecione `Vários projetos de inicialização`.
   - Marque a ação `Iniciar` para `PropostaService.Api` e `ContratacaoService.Api`.
4. Pressione F5 ou o botão "Play" para iniciar a aplicação.
5. Duas janelas de console e duas abas do Swagger serão abertas, uma para cada serviço.

### Executando via Linha de Comando
1. Clone este repositório.
2. Abra um terminal na pasta raiz da solução.
3. Inicie o `PropostaService`:
   ```bash
   cd src/PropostaService.Api
   dotnet run

## Autor

Desenvolvido por **André Luiz Gomes de Moraes**

- **GitHub:** [agomesmoraes](https://github.com/agomesmoraes)
- **LinkedIn:** [André Moraes](https://www.linkedin.com/in/andr%C3%A9-moraes-68819718/)