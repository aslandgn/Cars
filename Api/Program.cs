using Cars.Business;
using Cars.Core.EntityFramework;
using Cars.Core;
using Cars.Dal;
using Cars.Dal.Concrates;
using Cars.Dal.Interfaces;
using Microsoft.EntityFrameworkCore;
using Cars.Business.Concrates;
using Cars.Business.Interfaces;
using Microsoft.Extensions.Configuration;
using Serilog;
using Cars.Business.Utils;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var connectionString = builder.Configuration.GetConnectionString("CarDb");
builder.Services.AddDbContext<CarContext>(x => x.UseSqlServer(connectionString), ServiceLifetime.Transient);
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
Log.Logger = logger;
builder.Services.ConfigureDalServices();
builder.Services.ConfigureBusinessServices();
builder.Host.UseSerilog();
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//}
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.UseMiddleware<RequestMiddleware>();
app.MapControllers();

app.Run();

//enver
//uður


//doðancan aslan