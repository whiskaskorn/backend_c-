namespace MangaStore.Api.MangasDTO;

public class MangasGetDTO
{
    public int Id {get;set;}
    public string? Author {get;set;}
    public string? Name {get;set;}
    public float Price {get;set;}
    public MangasGetDTO(int id,string? author,string? name,float price)
    {
        Id = id;
        Author = author;
        Name = name;
        Price = price;
    }
}

public class MangasPostDTO
{
    public string? Author {get;set;}
    public string? Name {get;set;}
    public float Price {get;set;}

    public MangasPostDTO(string? author,string? name,float price)
    {
        Author = author;
        Name = name;
        Price = price;
    }
}