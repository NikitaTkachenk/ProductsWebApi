using FluentValidation;
using FluentValidation.AspNetCore;
using Products_WebApi.DTO.Requests;
using Products_WebApi.ProductValidators;
using DataAccess;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddDataBase();  //  Х мого класу Екстеншен. (Контейнера)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi.

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IValidator<CreateProductRequest>, CreateProductRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateProductRequest>, UpdateProductRequestValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();