using Microsoft.AspNetCore.Mvc;
using OnlineShool.Domain;
using OnlineShool.Presentation.API.DTOS.Course;




namespace OnlineShool.Presentation.API
{

    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        private readonly ICourseDomain _courseDomain;

        public CourseController(ICourseDomain courseDomain)
        {
            _courseDomain = courseDomain;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CourseCreateDTO courseDTO)
        {
            var newCourse = await _courseDomain.CreateAsync(courseDTO.Name,
                                                            courseDTO.Description,
                                                            courseDTO.LinkPic);
            return Ok(newCourse);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CourseUpdateDTO courseDTO)
        {
            var updateCourse = await _courseDomain.UpdateAsync(courseDTO.Id,
                                                               courseDTO.LinkPic, 
                                                               courseDTO.Name, 
                                                               courseDTO.Description);
            return Ok(updateCourse);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _courseDomain.GetAllCourseAsync();
            return Ok(courses);
        }

        
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _courseDomain.DeleteCourseAsync(id);
            return Ok();
        }
    }
}
