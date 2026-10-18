using FluentValidation;
using MangaStore.Api.MangaEndpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
var app = builder.Build();
MangaEndpoints.MapMangaEndpoints(app);

app.Run();