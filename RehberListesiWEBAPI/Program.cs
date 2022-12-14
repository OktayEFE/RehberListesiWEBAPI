using Microsoft.EntityFrameworkCore;
using RehberListesiWEBAPI.Controllers;
using RehberListesiWEBAPI.Models.Context;
using RehberListesiWEBAPI.Models.Mapping;

var builder = WebApplication.CreateBuilder(args);

//Data Base Configure Service
builder.Services.AddDbContext<Context>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase"));
});

//Mapping Profil Configure service
builder.Services.AddAutoMapper(typeof(MapProfile).Assembly);


// Add services to the container.

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

