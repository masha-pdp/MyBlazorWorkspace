using BlazorApp1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorAppWebAssembly.Features.Comments.DTO;
using BlazorAppWebAssembly.Features.Comments.Validators;

namespace BlazorApp1.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly ApplicationContext _context;

    public CommentsController(ApplicationContext context)
    {
        _context = context;
    }
    
    
    // GET
    [HttpGet("by-userId/{userId:long}")]
    public async Task<IActionResult> GetComments(long userId)
    {
        var comments = await _context.CommentEntities.Where(c => c.userid == userId)
                                                            .ToListAsync();
        
        return Ok(comments);
    }
    
    [HttpGet("by-commentId/{commentId:long}")]
    public async Task<IActionResult> GetComment(long commentId)
    {
        var comment = await _context.CommentEntities.FirstOrDefaultAsync(c => c.id == commentId);
        
        return Ok(comment);
    }
    
    
    
    
    [HttpPost]
    public async Task<IActionResult> AddComment([FromBody] CommentDto commentDto)
    {
        var validationResult = new CommentDtoValidator().Validate(commentDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        }
        
        var res = await _context.UserEntities.AnyAsync(u => u.id == commentDto.userid);
        if (!res)
        {
            return BadRequest("User ID is not found.");
        }
        
        var comment = new CommentEntity()
        {
            userid = commentDto.userid,
            text = commentDto.text,
            date = commentDto.date
        };
    
        _context.CommentEntities.Add(comment);
        await _context.SaveChangesAsync();

        return Ok();
    }

    
    [HttpPut("update-comment")] 
    public async Task <IActionResult> UpdateComment([FromBody] CommentDto commentDto)
    {
        var comment = await _context.CommentEntities.FindAsync(commentDto.id);
        if (comment == null) return NotFound();
        comment.text = commentDto.text;
        comment.date = commentDto.date;
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{commentId}")]
    public async Task <IActionResult> DeleteComment(long commentId)
    {
        // var comment = await _context.CommentEntities.FindAsync(commentId);
        // if (comment == null) return NotFound();
        // _context.CommentEntities.Remove(comment);
        // await _context.SaveChangesAsync();
        
        int deletedCount = await _context.CommentEntities
            .Where(c => c.id == commentId)
            .ExecuteDeleteAsync();
        
        if (deletedCount == 0)
            return NotFound();
        
        return Ok();
    }
}