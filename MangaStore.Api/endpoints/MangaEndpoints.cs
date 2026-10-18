using MangaStore.Api.MangasDTO;
using FluentValidation;

namespace MangaStore.Api.MangaEndpoints;


public static class MangaEndpoints
{
    private static List<MangasPostDTO> mangas  = new List<MangasPostDTO>
    {
        new MangasPostDTO(1,"Miura","Berserk",20.00f)
    };
    public static void MapMangaEndpoints(WebApplication app)
    {
        app.MapGet("/mangas", () => mangas);
        app.MapPost("/mangas", (MangasPostDTO manga,IValidator<MangasPostDTO> validator) =>
        {
            if(manga == null)
            {
                return Results.BadRequest("Нема даних");
            }

            var validationResult = validator.Validate(manga);
            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }
            mangas.Add(manga);
            return Results.Created();
        });
        app.MapPut("/mangas/{id}",(int id,MangasPostDTO manga,IValidator<MangasPostDTO> validator) =>
        {
            var index = mangas.FindIndex(x => x.Id == id);
            if(index == -1)
            {
                return Results.StatusCode(404);
            }
            var validationResult = validator.Validate(manga);
            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }
            mangas[index] = new MangasPostDTO(manga.Id,manga.Author,manga.Name,manga.Price);
            return Results.StatusCode(200);

        });
        app.MapDelete("/mangas/{id}",(int id) =>
        {
            var manga = mangas.Find(x => x.Id == id);
            if(manga == null)
            {
                return Results.StatusCode(404);
            }
        mangas.Remove(manga);
        return Results.StatusCode(200);
        });
    }
}