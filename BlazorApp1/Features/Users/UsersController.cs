using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Features.Users;

[ApiController]
[Route("api/[controller]")]
//[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ApplicationContext _context;

    public UsersController(ApplicationContext context)
    {
        _context = context;
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
        var users = await _context.users.ToListAsync();
        return Ok(users);
    }
}