namespace BlazorApp1.Data;

public class User
{
    public long id {get; set;}
    public string? name {get; set;}
    public string? phone {get; set;}

    public List<Comment> Comments {get;set;}
}