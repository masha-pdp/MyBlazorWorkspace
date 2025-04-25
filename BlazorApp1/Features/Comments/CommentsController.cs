using BlazorApp1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly ApplicationContextEntity _contextEntity;

    public CommentsController(ApplicationContextEntity contextEntity)
    {
        _contextEntity = contextEntity;
    }
    
    
    // GET
    [HttpGet]
    public async Task<IActionResult> GetComments(long userId)
    {
        var comments = await _contextEntity.commentsEntity.Where(c => c.userid == userId)
                                                            .ToListAsync();
        
        return Ok(comments);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddComment(long userId, string commentText)
    {
        var comment = new CommentEntity()
        {
            userid = userId,
            text = commentText,
            date = DateTime.UtcNow
        };
        _contextEntity.commentsEntity.Add(comment);
        await _contextEntity.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPut("{commentId}")] 
    public async Task <IActionResult> UpdateComment([FromForm]long commentId, [FromForm]string commentText)
    {
        var comment = await _contextEntity.commentsEntity.FindAsync(commentId);
        if (comment == null) return NotFound();
        comment.text = commentText;
        await _contextEntity.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{commentId}")]
    public async Task <IActionResult> DeleteComment(long commentId)
    {
        var comment = await _contextEntity.commentsEntity.FindAsync(commentId);
        if (comment == null) return NotFound();
        _contextEntity.commentsEntity.Remove(comment);
        await _contextEntity.SaveChangesAsync();
        return Ok();
    }
}