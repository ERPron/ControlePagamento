using Application.Interfaces;
using Application.Mapping;
using Domain.Interfaces;
using Domain.Services;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o contexto do Entity Framework Core
builder.Services.AddDbContext<AppDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(DomainToMappinDTO));
builder.Services.AddScoped<IDbSession, DbSession>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<IClienteService, ClienteService>();
builder.Services.AddTransient<IPagamentoService, PagamentoService>();

builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IPagamentoRepository, PagamentoRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
