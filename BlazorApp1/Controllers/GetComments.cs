using BlazorApp1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Controllers;
[ApiController]
[Route("api[controller]")]
public class CommentsController : ControllerBase
{
    private readonly ApplicationContext _context;

    public CommentsController(ApplicationContext context)
    {
        _context = context;
    }
    
    
    // GET
    [HttpGet]
    public async Task<IActionResult> GetComments(long userId)
    {
        var comments = await _context.comments.Where(c => c.userid == userId)
                                                            .ToListAsync();
        
        return Ok(comments);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddComment(long userId, string commentText)
    {
        var comment = new Comment()
        {
            userid = userId,
            text = commentText,
            date = DateTime.UtcNow
        };
        _context.comments.Add(comment);
        await _context.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPut("{commentId}")] 
    public async Task <IActionResult> UpdateComment([FromForm]long commentId, [FromForm]string commentText)
    {
        var comment = await _context.comments.FindAsync(commentId);
        if (comment == null) return NotFound();
        comment.text = commentText;
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{commentId}")]
    public async Task <IActionResult> DeleteComment(long commentId)
    {
        var comment = await _context.comments.FindAsync(commentId);
        if (comment == null) return NotFound();
        _context.comments.Remove(comment);
        await _context.SaveChangesAsync();
        return Ok();
    }
}