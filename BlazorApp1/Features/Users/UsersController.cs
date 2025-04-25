using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Data;
using Microsoft.EntityFrameworkCore;
using BlazorAppWebAssembly.Features;
using BlazorAppWebAssembly.Features.Comments.DTO;
using BlazorAppWebAssembly.Features.Users.DTO;

namespace BlazorApp1.Features.Users;

[ApiController]
[Route("api/[controller]")]
//[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ApplicationContextEntity _contextEntity;

    public UsersController(ApplicationContextEntity contextEntity)
    {
        _contextEntity = contextEntity;
    }
    
    
    // GET синхрогнно 
    // [HttpGet]
    // public IActionResult GetUsers()
    // {
    //     return Ok();
    // }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _contextEntity.usersEntity
            .AsNoTracking()
            .Include(u => u.Comments)
            .ToListAsync();

        var usersDto = users.Select(u => new UserDto
        {
            id = u.id,
            name = u.name,
            phone = u.phone,
            comments = u.Comments?.Select(c => new CommentDto
            {
                id = c.id,
                text = c.text,
                date = c.date,
            }).ToList()
        }).ToList();

        return Ok(usersDto);
    }
    
    //  TODO:
    //  get user name by id:
    //      name
    //  example: api/Users/12/name
    [HttpGet("{userId}/name")]
    public async Task<IActionResult> GetUserName(long userId)
    {
        var user = await _contextEntity.usersEntity
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.id == userId);
        if (user == null)
        {
            //  return NotFound();  //  404 - когда контроллер или экшн не найден
            return BadRequest("User not found");
        }
        
        return Ok(user.name);
    }
}