using ExceptionHandlingAndLogging.Api.Middleware;
using ExceptionHandlingAndLogging.Api.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();
    loggingBuilder.AddFile();
});

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