using AppProject.Core.API.Bootstraps;

var builder = WebApplication.CreateBuilder(args);

builder.AddApiServices();

var app = builder.Build();

await app.InitializaDatabaseAsync();

app.UseApiPipeline();

app.Run();