namespace BlazorAppWebAssembly.Features.Users.DTO;

public class UserDto
{
    public long id { get; set; }
    public string? name { get; set; }
    public string? phone { get; set; }
    public object? comments { get; set; } // временно object? — чтобы избежать ошибки десериализации
}