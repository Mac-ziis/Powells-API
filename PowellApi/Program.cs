using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PowellApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PowellApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PowellApiContext")));
builder.Services.AddControllers();

// Add services to the container.

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
