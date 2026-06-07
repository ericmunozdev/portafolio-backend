using Portafolio.Application;
using Portafolio.Infrastructure;
using Portafolio.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Activa el explorador de endpoints (imprescindible para Minimal APIs)
builder.Services.AddEndpointsApiExplorer();

// Add extensions
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddDbContextExtensions(builder.Configuration);
builder.Services.AddSwaggerExtensions(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corspolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
