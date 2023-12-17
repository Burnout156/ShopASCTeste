using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using ShopASCLibrary.Queries.Products;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Reflection;
using ShopASCLibrary.Commands.Products;
using ShopASCLibrary.Handlers.Query.ProductQuery;
using ShopASCLibrary.Data.Context;
using ShopASCLibrary.Handlers.Query.OrderQuery;
using ShopASCLibrary.Handlers.Command.OrderCommands;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddMediatR(typeof(ProductCommandHandlers).Assembly);
builder.Services.AddMediatR(typeof(ProductQueryHandlers).Assembly);
builder.Services.AddMediatR(typeof(OrderCommandHandlers).Assembly);
builder.Services.AddMediatR(typeof(OrderQueryHandlers).Assembly);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed((host) => true)
            .AllowCredentials());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
