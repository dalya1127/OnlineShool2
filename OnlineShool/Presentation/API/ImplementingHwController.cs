using Microsoft.AspNetCore.Mvc;
using OnlineShool.Domain;

using OnlineShool.Presentation.API.DTOS.ImplementingHw;



namespace OnlineShool.Presentation.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImplementingHwController: Controller
    {
        private readonly IHomeWorkDomain _implementingHwDomain;
        public ImplementingHwController(IHomeWorkDomain implementingHwDomain)
        {
            _implementingHwDomain = implementingHwDomain;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ImplementingHwCreateDTO implementingHwCreateDTO)
        {
            var newImplemeting = await _implementingHwDomain.CreateImplementingHomeworkAsync(implementingHwCreateDTO.IdUser, implementingHwCreateDTO.IdHomeWork, implementingHwCreateDTO.IdStatusHomeWork, implementingHwCreateDTO.LinkFile, implementingHwCreateDTO.Score);
            return Ok(newImplemeting);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ImplementingUpdateDTO implementingUpdateDTO)
        {
            var updateImplementing = await _implementingHwDomain.UpdateImplementingHomeworkAsync(implementingUpdateDTO.Id, implementingUpdateDTO.IdUser, implementingUpdateDTO.IdHomeWork, implementingUpdateDTO.IdStatusHomeWork, implementingUpdateDTO.LinkFile, implementingUpdateDTO.Score);
            return Ok(updateImplementing);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _implementingHwDomain.DeleteImplementingHomeworkAsync(id);
            return Ok();
        }

        [HttpGet("GetByUser")]
        public async Task<IActionResult> GetImplementingByUser([FromQuery] int IdUser)
        {
            var getImplementing = await _implementingHwDomain.GetImplementingHomeworkByUser(IdUser);
            return Ok(getImplementing);
        }

        [HttpGet("GetByHomework")]
        public async Task<IActionResult> GetImplementingByHomework([FromQuery] int IdHomework)
        {
            var getImplementing = await _implementingHwDomain.GetImplementingHomeworkByHomework(IdHomework);
            return Ok(getImplementing);
        }

    }
}
