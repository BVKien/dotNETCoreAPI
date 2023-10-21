using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using DemoWebAPI_03.Repositories.Implementations;
using DemoWebAPI_03.Repositories.Interfaces;
using DemoWebAPI_03.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure the DbContext
builder.Services.AddDbContext<f8dbContext>(options =>
{
    IConfiguration configuration = builder.Configuration;
    string connectionString = configuration.GetConnectionString("f8db");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Config repository
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

// Config Cors reactjs default port 3000
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials(); // Allow credentials (cookies, authorization headers)
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CROS - Config Cors reactjs default port 3000
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();