using Microsoft.AspNetCore.Mvc;
using OnlineShool.Domain;
using OnlineShool.Presentation.API.DTOS.Comment;
using OnlineShool.Presentation.API.DTOS.StatusHw;
namespace OnlineShool.Presentation.API
{

    [ApiController]
    [Route("api/[controller]")]
    public class StatusHwController:Controller
    {
        private readonly IHomeWorkDomain _statusHwDomain;

        public StatusHwController(IHomeWorkDomain statusHwDomain)
        {
            _statusHwDomain = statusHwDomain;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StatusHwCreateDTO statusHwDTO)
        {
            var newStatus = await _statusHwDomain.CreateStatusHomeworkAsync(statusHwDTO.Name, statusHwDTO.Description);
            return Ok(newStatus);
        }

        [HttpPut]
        public async Task<IActionResult> Update
            (
            [FromBody]StatusHwUpdateDTO newstatusDTO
            )
        {

            var updateComment = await _statusHwDomain.UpdateStatusHomeworkAsync(newstatusDTO.Id, newstatusDTO.Name, newstatusDTO.Description);
            return Ok(updateComment);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete
        (
            [FromQuery] int id
        )
        {
            await _statusHwDomain.DeleteStatusHomeworkAsync(id);
            return Ok();
        }

    }
}
