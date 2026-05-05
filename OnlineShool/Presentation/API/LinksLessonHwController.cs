using Microsoft.AspNetCore.Mvc;
using OnlineShool.Domain;
using OnlineShool.Presentation.API.DTOS.LinksLessonHw;


namespace OnlineShool.Presentation.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class LinksLessonHwController: Controller
    {
        private readonly ILessonDomain _linkLessonHw;

        public LinksLessonHwController(ILessonDomain linkLessonHw)
        {
            _linkLessonHw = linkLessonHw;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LinksLessonHwCreateDTO linkDTO)
        {
            var newLink = await _linkLessonHw.CreateLinksLessonsHomeWorkAsync(linkDTO.IdHomework, linkDTO.IdLessons);
            return Ok(newLink); 
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] LinksLessonHwUpdateDTO linkDTO)
        {
            var updateLink = await _linkLessonHw.UpdateLinksLessonsHomeWorkAsync(linkDTO.Id,linkDTO.IdHomework ,linkDTO.IdLessons);
            return Ok(updateLink);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _linkLessonHw.DeleteLinksLessonsHomeWorkAsync(id);
            return Ok();
        }

        [HttpGet("GetByLesson")]
        public async Task<IActionResult> GetLinksLessonsHomeWorkByLesson(int IdLessons)
        {
            var newLink = await _linkLessonHw.GetLinksLessonsHomeWorkByLesson(IdLessons);
            return Ok(newLink);
        }

        [HttpGet("GetByHomework")]
        public async Task<IActionResult> GetLinksLessonsHomeWorkByHomeWork(int IdHomework)
        {
            var newLink = await _linkLessonHw.GetLinksLessonsHomeWorkByHomeWork(IdHomework);
            return Ok(newLink);
        }

    }
}
