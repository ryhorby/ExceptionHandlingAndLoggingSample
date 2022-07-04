using ExceptionHandlingAndLogging.Api.Middleware;
using ExceptionHandlingAndLogging.Api.Repository;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Logger configuration
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<WeatherRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseErrorHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();