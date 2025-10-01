# Estágio 1: Build da Aplicação
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia os arquivos .csproj e restaura as dependências
COPY ["src/ContratacaoService.Api/ContratacaoService.Api.csproj", "src/ContratacaoService.Api/"]
COPY ["src/ContratacaoService.Application/ContratacaoService.Application.csproj", "src/ContratacaoService.Application/"]
COPY ["src/ContratacaoService.Domain/ContratacaoService.Domain.csproj", "src/ContratacaoService.Domain/"]
# Dependência implícita do PropostaService (por causa da solução)
COPY ["src/PropostaService.Domain/PropostaService.Domain.csproj", "src/PropostaService.Domain/"]
RUN dotnet restore "src/ContratacaoService.Api/ContratacaoService.Api.csproj"

# Copia todo o resto do código fonte e publica a aplicação
COPY . .
WORKDIR "/src/src/ContratacaoService.Api"
RUN dotnet publish "ContratacaoService.Api.csproj" -c Release -o /app/publish

# Estágio 2: Imagem Final
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "ContratacaoService.Api.dll"]