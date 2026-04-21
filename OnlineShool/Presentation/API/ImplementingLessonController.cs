using Microsoft.AspNetCore.Mvc;
using OnlineShool.Domain;
using OnlineShool.Presentation.API.DTOS.ImplementingLesson;


namespace OnlineShool.Presentation.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImplementingLessonController : Controller
    {
        private readonly ILessonDomain _implementingLessonDomain;

        public ImplementingLessonController(ILessonDomain implementingLessonDomain)
        {
            _implementingLessonDomain = implementingLessonDomain;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ImplementingLessonCreateDTO implementingLessonDTO)
        {
            var newImplemLesson = await _implementingLessonDomain.CreateImplementingLessonAsync(implementingLessonDTO.IdUsers, implementingLessonDTO.IdLessons, implementingLessonDTO.IdStatusLessons, implementingLessonDTO.Description);
            return Ok(newImplemLesson);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ImplementingLessonUpdateDTO implementingLessonDTO)
        {
            var updateImplemLesson = await _implementingLessonDomain.UpdateImplementingLessonAsync(implementingLessonDTO.Id, implementingLessonDTO.IdUsers, implementingLessonDTO.IdLessons, implementingLessonDTO.IdStatusLessons, implementingLessonDTO.Description);
            return Ok(updateImplemLesson);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _implementingLessonDomain.DeleteImplementingLessonAsync(id);
            return Ok();
        }

        [HttpGet("GetByLeson")]
        public async Task<IActionResult> GetImplementingByLessons([FromQuery] int IdLessons)
        {
            var getImplemLesson = await _implementingLessonDomain.GetImplementingLessonByLessons(IdLessons);
            return Ok(getImplemLesson);
        }
        [HttpGet("GetByUser")]
        public async Task<IActionResult> GetImplementingByUser([FromQuery] int IdUser)
        {
            var getImplemLesson = await _implementingLessonDomain.GetImplementingLessonByUser(IdUser);
            return Ok(getImplemLesson);
        }
    }
}
