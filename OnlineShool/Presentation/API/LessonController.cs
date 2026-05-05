using Microsoft.AspNetCore.Mvc;
using OnlineShool.Domain;
using OnlineShool.Presentation.API.DTOS.Lesson;




namespace OnlineShool.Presentation.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonController: Controller
    {
        private readonly ILessonDomain _lessonDomain;
        public LessonController(ILessonDomain lessonDomain)
        {
            _lessonDomain = lessonDomain;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LessonCreateDTO lessonDTO)
        {
            var newLesson = await _lessonDomain.CreateLessonAsync(lessonDTO.IdCourses, lessonDTO.Name, lessonDTO.NumberLessons, lessonDTO.LinkFile, lessonDTO.LinkPic, lessonDTO.Description);
            return Ok(newLesson);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] LessonUpdateDTO lessonDTO)
        {
            var updateLesson = await _lessonDomain.UpdateLessonAsync(lessonDTO.Id, lessonDTO.IdCourses,lessonDTO.Name,lessonDTO.NumberLessons, lessonDTO.LinkFile, lessonDTO.LinkPic, lessonDTO.Description);      
            return Ok(updateLesson);
        }

        [HttpGet("GetByCourse")]
        public async Task<IActionResult> GetByCourse([FromQuery] int courseId)
        {
            var getByCourse = await _lessonDomain.GetByCourseIdAsync(courseId);
            return Ok(getByCourse);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var getAll = await _lessonDomain.GetAllAsync();
            return Ok(getAll);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery]int id)
        {
            var getById = await _lessonDomain.GetByIdAsync(id);
            return Ok(getById);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _lessonDomain.DeleteLessonAsync(id);
            return Ok();
        }
    }
}
