namespace MangaStore.Api.Models;

public class Manga
{
    public int Id { get; set; }
    public string? Author { get; set; }
    public string? Name { get; set; }
    public float Price { get; set; }
}