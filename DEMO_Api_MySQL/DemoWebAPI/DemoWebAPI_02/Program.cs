/*
using DemoWebAPI_02.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddDbContext<f8dbContext>(options =>
{
    IConfiguration configuration = builder.Configuration;
    string connectionString = configuration.GetConnectionString("f8db");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

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
*/


using DemoWebAPI_02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection; // new 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// new 
/*
// Enable CORS for the API
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
*/
// end new 

// Configure the DbContext
builder.Services.AddDbContext<f8dbContext>(options =>
{
    IConfiguration configuration = builder.Configuration;
    string connectionString = configuration.GetConnectionString("f8db");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});


// new 3000
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
// end new 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable Swagger and Swagger UI for API documentation in development mode
    app.UseSwagger();
    app.UseSwaggerUI();
}

// new 
// CROS
app.UseCors();
// end new

// Redirect HTTP to HTTPS
app.UseHttpsRedirection();

// Enable authorization
app.UseAuthorization();

// Map API controllers
app.MapControllers();

app.Run();