namespace BlazorAppWebAssembly.Features.Comments.DTO;

public class CommentDto
{
    public long id { get; set; }
    public string text { get; set; }
    
    public long userid { get; set; }
    public DateTime date { get; set; }
}