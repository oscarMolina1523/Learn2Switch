using Domain.Endpoint.Interfaces;
using Domain.Endpoint.Services;
using Infrastucture.Endpoint;
using Infrastucture.Endpoint.Repositories;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddSingleton<ISingletonSqlConnection>(SingletonSqlConnection.GetInstance());


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
