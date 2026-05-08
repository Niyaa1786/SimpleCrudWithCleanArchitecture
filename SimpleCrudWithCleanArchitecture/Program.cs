using Microsoft.AspNetCore.Mvc;
using Scalar.AspNetCore;
using Serilog;
using Serilog.Events;
using SimpleCrud.Api.Handlers;
using SimpleCrud.Api.Responses;
using SimpleCrud.Application;
using SimpleCrud.Infrastructure;
using System.Text.Json;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddSerilog();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    });

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddExceptionHandler<ExceptionHandler>();
builder.Services.AddProblemDetails();


var app = builder.Build();

app.UseSerilogRequestLogging();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler();

app.Run();
