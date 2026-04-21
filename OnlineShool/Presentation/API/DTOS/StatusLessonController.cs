using Microsoft.AspNetCore.Mvc;
using OnlineShool.Domain;
using OnlineShool.Presentation.API.DTOS.StatusLesson;

namespace OnlineShool.Presentation.API.DTOS
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusLessonController:Controller
    {
        private readonly ILessonDomain _statusLesson;

        public StatusLessonController(ILessonDomain statusLesson)
        {
            _statusLesson = statusLesson;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StatusLessonCreateDTO statusDTO)
        {
            var newStatus = await _statusLesson.CreateStatusLessonsAsync(statusDTO.Name, statusDTO.Description);
            return Ok(newStatus);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] StatusLessonUpdateDTO statusDTO)
        {
            var newStatus = await _statusLesson.UpdateStatusLessonsAsync(statusDTO.Id,statusDTO.Name, statusDTO.Description);
            return Ok(newStatus);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]  int id)
        {
            await _statusLesson.DeleteStatusLessonsAsync(id);
            return Ok();
        }
    }
}
