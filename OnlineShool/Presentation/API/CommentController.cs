using Microsoft.AspNetCore.Mvc;
using OnlineShool.Domain;
using OnlineShool.Presentation.API.DTOS.Comment;

namespace OnlineShool.Presentation.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        private readonly ICommentDomain _commentDomain;

        public CommentController(ICommentDomain commentDomain)
        {
            _commentDomain = commentDomain;
        }

        [HttpPost]
        public async Task<IActionResult> Create
            (
            [FromBody] CommentCreateDTO commentDTO
            )
        {
            var newComment = await _commentDomain.CreateCommentAsync(commentDTO.IdUser, commentDTO.Text, commentDTO.IdLesson, commentDTO.IdAnswer);                                
            return Ok(newComment);
        }


        [HttpPut]
        public async Task<IActionResult> Update
            (
            [FromBody] CommentUpdateDTO newCommentDTO
            )
        {
            
            var updateComment = await _commentDomain.UpdateCommentAsync(newCommentDTO.id, newCommentDTO.IdUser, newCommentDTO.Text, newCommentDTO.IdLesson, newCommentDTO.Date, newCommentDTO.IdAnswer);
            return Ok(updateComment);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll
            (
            )
        {
            var getComment = await _commentDomain.GetAllAsync();
            return Ok(getComment);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById
            (
            [FromQuery] int id
            )
        {
            var getComment = await _commentDomain.GetByIdAsync(id);
            return Ok(getComment);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete
        (
            [FromQuery] int id
        )
        {
            await _commentDomain.DeleteCommentAsync(id);
            return Ok();
        }
        
    }
}


