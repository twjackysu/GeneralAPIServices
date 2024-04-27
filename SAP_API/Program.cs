using DotnetSdkUtilities.Factory.ResponseFactory;
using SAP_API.Common;
using SAP_API.Configuration;
using SAP_API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IApiResponseFactory, ApiResponseFactory>();
builder.Services.AddScoped<IMyResponseFactory, MyResponseFactory>();

builder.Services.AddOptions().Configure<Settings>(builder.Configuration.GetSection("Settings"));
var app = builder.Build();

app.UseMiddleware<ValidateHeaderMiddleware>();
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
