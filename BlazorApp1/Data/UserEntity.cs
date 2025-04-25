namespace BlazorApp1.Data;

public class UserEntity
{
    public long id {get; set;}
    public string? name {get; set;}
    public string? phone {get; set;}

    public List<CommentEntity> Comments {get;set;}
}