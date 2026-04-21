using Microsoft.AspNetCore.Mvc;
using OnlineShool.Domain;
using OnlineShool.Presentation.API.DTOS.LinksVideoLesson;


namespace OnlineShool.Presentation.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class LinksVideoLessonsController : Controller
    {
        private readonly IVideoDomain _linkVideoLessons;
        public LinksVideoLessonsController(IVideoDomain linkVideoLessons)
        {
            _linkVideoLessons = linkVideoLessons;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LinksVideoLessonCreateDTO linkDTO)
        {
            var newLink = await _linkVideoLessons.CreateLinksVideoLessonAsync(linkDTO.IdLessons, linkDTO.IdVideos);
            return Ok(newLink);
        }

        [HttpPut]
        public async Task <IActionResult> Update([FromBody] LinksVideoLessonUpdateDTO linkDTO)
        {
            var updateLink = await _linkVideoLessons.UpdateLinksVideoLessonAsync(linkDTO.Id, linkDTO.IdVideos,linkDTO.IdLessons);
            return Ok(updateLink);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetLinksVideoLessonByLessons([FromQuery] string type, [FromQuery] int? IdLessons = null, [FromQuery] int? IdVideos = null )
        {
            if (type == "lesson" && IdLessons != null) 
            {
                var getLink = await _linkVideoLessons.GetLinksVideoLessonByLesson((int)IdLessons);
                return Ok(getLink);
            }
            else if (type == "video" && IdVideos != null)
            {
                var getLink = await _linkVideoLessons.GetLinksVideoLessonByLesson((int)IdVideos);
                return Ok(getLink);
            }
            else
            {
                return StatusCode(StatusCodes.Status502BadGateway,
                    new { error = "Bad Gateway от upstream" });
            }
            
        }



    }
}
