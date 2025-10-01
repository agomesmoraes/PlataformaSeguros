# Estágio 1: Build da Aplicação
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia os arquivos .csproj e restaura as dependências primeiro (otimização de cache)
COPY ["src/PropostaService.Api/PropostaService.Api.csproj", "src/PropostaService.Api/"]
COPY ["src/PropostaService.Application/PropostaService.Application.csproj", "src/PropostaService.Application/"]
COPY ["src/PropostaService.Domain/PropostaService.Domain.csproj", "src/PropostaService.Domain/"]
RUN dotnet restore "src/PropostaService.Api/PropostaService.Api.csproj"

# Copia todo o resto do código fonte e publica a aplicação
COPY . .
WORKDIR "/src/src/PropostaService.Api"
RUN dotnet publish "PropostaService.Api.csproj" -c Release -o /app/publish

# Estágio 2: Imagem Final
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Define a porta que o contêiner vai expor
EXPOSE 8080
# Define o comando para iniciar a API quando o contêiner rodar
ENTRYPOINT ["dotnet", "PropostaService.Api.dll"]