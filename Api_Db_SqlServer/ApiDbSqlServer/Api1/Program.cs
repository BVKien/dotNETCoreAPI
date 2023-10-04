using Api1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/*
// Configure DbContext
Services.AddDbContext<ApiDBContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("YourConnectionString")));
*/

// bổ xung instance của ApiDBContext vào container của web server
builder.Services.AddDbContext<ApiDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApiDB")));



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
