using Microsoft.AspNetCore.Mvc;
using OnlineShool.Domain;




using OnlineShool.Presentation.API.DTOS.PurchasedCourse;

namespace OnlineShool.Presentation.API
{
    [ApiController]
    [Route("api/[controller]")]

    public class PurchasedCourseController: Controller
    {
        private readonly ICourseDomain _purchasedCourseDomain;
        public PurchasedCourseController(ICourseDomain purchasedCourseDomain)
        {
            _purchasedCourseDomain = purchasedCourseDomain;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody ] PurchasedCourseCreateDTO courseDTO)
        {
            var newPurchasedCourse = await _purchasedCourseDomain.CreatePurchasedCourseAsync(courseDTO.IdUser, courseDTO.IdCourses);
            return Ok(newPurchasedCourse);
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var getAll = await _purchasedCourseDomain.GetAllAsync();
            return Ok(getAll);
        }

        

        [HttpPut]
        public async Task<IActionResult> Update
            (
            [FromBody] PurchasedCourseUpdateDTO courseDTO
            )
        {

            var updateComment = await _purchasedCourseDomain.UpdatePurchasedCourseAsync(courseDTO.Id,courseDTO.IdUser, courseDTO.IdCourses);
            return Ok(updateComment);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _purchasedCourseDomain.DeletePurchasedCourseAsync(id);
            return Ok();
        }

    }
}
