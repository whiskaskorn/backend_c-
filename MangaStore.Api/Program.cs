using FluentValidation;
using MangaStore.Api.Data;
using MangaStore.Api.MangaEndpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddDbContext<MangaContext>(options => options.UseNpgsql("Host=localhost; Port=5432; Database=mangastore; Username=postgres; Password=whiskas0212"));
var app = builder.Build();
MangaEndpoints.MapMangaEndpoints(app);

app.Run();