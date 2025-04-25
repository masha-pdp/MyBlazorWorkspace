namespace BlazorAppWebAssembly.Features.Users.DTO;
using BlazorAppWebAssembly.Features.Comments.DTO;
public class UserDto
{
    public long id { get; set; }
    public string? name { get; set; }
    public string? phone { get; set; }
    public List<CommentDto>? comments { get; set; }
}