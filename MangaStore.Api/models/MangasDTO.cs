namespace MangaStore.Api.MangasDTO;

public class MangasGetDTO
{
    public int Id {get;}
    public string? Author {get;}
    public string? Name {get;}
    public float Price {get;}
}

public class MangasPostDTO
{
    public int Id {get;set;}
    public string? Author {get;set;}
    public string? Name {get;set;}
    public float Price {get;set;}

    public MangasPostDTO(int id,string? author,string? name,float price)
    {
        Id = id;
        Author = author;
        Name = name;
        Price = price;
    }
}