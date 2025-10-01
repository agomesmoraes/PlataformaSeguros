using ContratacaoService.Api.Adapters;
using ContratacaoService.Api.Data;
using ContratacaoService.Api.Repositories;
using ContratacaoService.Application.Interfaces;
using ContratacaoService.Application.Services;
using ContratacaoService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("ContratacaoDb"));

builder.Services.AddScoped<IContratacaoRepository, ContratacaoRepository>();

builder.Services.AddHttpClient();
builder.Services.AddScoped<IPropostaServiceAdapter, PropostaServiceAdapter>();

builder.Services.AddScoped<IContratacaoAppService, ContratacaoAppService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();