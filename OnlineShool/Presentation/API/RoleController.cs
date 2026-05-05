using Microsoft.AspNetCore.Mvc;
using OnlineShool.Presentation.API.DTOS.Role;







namespace OnlineShool.Presentation.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController: Controller
    {
        private readonly IRoleDomain _roleDomain;
        public RoleController(IRoleDomain roleDomain)
        {
            _roleDomain = roleDomain;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RoleCreateDTO roleDTO)
        {
            var newRole = await _roleDomain.CreateRolesAsync(roleDTO.Name, roleDTO.Description);
            return Ok(newRole);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RoleUpdateDTO roleDTO)
        {
            await _roleDomain.UpdateRolesAsync(roleDTO.Id, roleDTO.Name, roleDTO.Description);
            return Ok();
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleDomain.GetAllAsync();
            return Ok(roles);
        }


        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery]int id)
        {
            var roles = await _roleDomain.GetRolesById(id);
            return Ok(roles);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _roleDomain.DeleteRolesAsync(id);
            return Ok();
        }
    }
}
