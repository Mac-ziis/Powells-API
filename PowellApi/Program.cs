using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PowellApi.Models;
using PowellApi.Repository;
using PowellApi.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<PowellApiContext>(dbContextOptions => dbContextOptions
    .UseMySql(
    builder.Configuration["ConnectionStrings:DefaultConnection"],
    ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"]
    )
    )
);

builder.Services.AddScoped<IBookRepository, BookRepository>();

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
else
{
    app.UseHttpsRedirection();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
