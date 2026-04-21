using Microsoft.AspNetCore.Mvc;
using OnlineShool.Infrastructura.Instructions;
using OnlineShool.Domain;
using OnlineShool.Presentation.API.DTOS.Homework;


namespace OnlineShool.Presentation.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeworkController : Controller
    {
        private readonly IHomeWorkDomain _homeWorkDomain;
        public HomeworkController(IHomeWorkDomain homeWorkDomain)
        {
            _homeWorkDomain = homeWorkDomain;
        }

        [HttpPost]
        public async Task <IActionResult> Create([FromBody] HomeworkCreateDTO hwDTO)
        {
            var newHw = await _homeWorkDomain.CreateHomeworkAsync(hwDTO.Name, hwDTO.LinkFile, hwDTO.Description);
            return Ok(newHw);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] HomeworkUpdateDTO hwDTO)
        {
            var updateHw = await _homeWorkDomain.UpdateHomeworkAsync(hwDTO.Id, hwDTO.Name, hwDTO.LinkFile, hwDTO.Description);
            return Ok(updateHw);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _homeWorkDomain.DeleteHomeworkAsync(id);
            return Ok();
        }
    }
}
