using MangaStore.Api.MangasDTO;
using FluentValidation;
using MangaStore.Api.Data;
using MangaStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MangaStore.Api.MangaEndpoints;


public static class MangaEndpoints
{
    public static void MapMangaEndpoints(WebApplication app)
    {
        app.MapGet("/mangas", async (MangaContext db) =>
        {
            return await db.mangas.Select(m => new MangasGetDTO(m.Id,m.Author,m.Name,m.Price)).ToListAsync();
        });
        
        app.MapPost("/mangas", async (MangasPostDTO dto,IValidator<MangasPostDTO> validator,MangaContext db) =>
        {
            if(dto == null)
            {
                return Results.BadRequest("Нема даних");
            }

            var validationResult = validator.Validate(dto);
            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }

            var manga = new Manga
            {
                Author = dto.Author,
                Name = dto.Name,
                Price = dto.Price
            };


            db.mangas.Add(manga);
            await db.SaveChangesAsync();
            return Results.Created();
        });
        app.MapPut("/mangas/{id}",async (int id,MangasPostDTO dto,IValidator<MangasPostDTO> validator,MangaContext db) =>
        {
            var manga = await db.mangas.FindAsync(id);
            if(manga == null)
            {
                return Results.StatusCode(404);
            }
            var validationResult = validator.Validate(dto);
            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }
            
            manga.Author = dto.Author;
            manga.Name = dto.Name;
            manga.Price = dto.Price;
            await db.SaveChangesAsync();

            return Results.Ok();

        });
        app.MapDelete("/mangas/{id}", async(int id,MangaContext db) =>
        {
            var manga = await db.mangas.FindAsync(id);
            if(manga == null)
            {
                return Results.StatusCode(404);
            }
            db.mangas.Remove(manga);
            await db.SaveChangesAsync();

            return Results.Ok();
        });
    }
}