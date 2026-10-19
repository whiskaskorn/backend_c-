using Microsoft.EntityFrameworkCore;
using MangaStore.Api.Models;

namespace MangaStore.Api.Data;

public class MangaContext(DbContextOptions<MangaContext> options) : DbContext(options)
{
    public DbSet<Manga> mangas { get; set; }
}