using DotnetSdkUtilities.Factory.ResponseFactory;
using Microsoft.OpenApi.Models;
using SAP_API.Common;
using SAP_API.Configuration;
using SAP_API.Middlewares;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.ToString());
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "SAP API",
        Description = "Convert SOAP api body from xml to json",
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddScoped<IApiResponseFactory, ApiResponseFactory>();
builder.Services.AddScoped<IMyResponseFactory, MyResponseFactory>();

builder.Services.AddOptions().Configure<Settings>(builder.Configuration.GetSection("Settings"));
var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<ValidateHeaderMiddleware>();
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
