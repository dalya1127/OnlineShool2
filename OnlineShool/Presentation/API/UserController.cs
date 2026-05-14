using Microsoft.AspNetCore.Mvc;
using OnlineShool.Domain;
using OnlineShool.Infrastructura.Sql_Server.Models;
using OnlineShool.Presentation.API.DTOS.User;
namespace OnlineShool.Presentation.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserDomain _userDomain;
        private readonly IRoleDomain _roleDomain;

        public UserController(IUserDomain userDomain, IRoleDomain roleDomain)
        {
            _userDomain = userDomain;
            _roleDomain = roleDomain;
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Authorization
            (
            [FromBody] UserAuthorizationDTO userDTO
            )
        {
            var result = await _userDomain.AuthorizationUserAsync(userDTO.Login, userDTO.Password);
            if (result == null) return Unauthorized();
            return Ok(result);
        }




        [HttpPost("Registration")]
        public async Task<IActionResult> Create
            (
            [FromBody] UserCreateDTO userDTO
            )
        {

            try
            {

                var newUser = await _userDomain.CreateUserAsync(
                    userDTO.FirstName,
                    userDTO.LastName,
                    userDTO.IdRole,
                    userDTO.Login,
                    userDTO.Email,
                    userDTO.Password,
                    userDTO.Patronymic);

                return Ok(ConvertDomainToResponse(newUser));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update
            (
            [FromBody] UserUpdateDTO userDTO
            )
        {
            var newUser = await _userDomain.UpdateUserAsync(
                userDTO.id,
                userDTO.FirstName,
                userDTO.LastName,
                userDTO.Patronymic,
                userDTO.Login,
                userDTO.Email,
                userDTO.Password,
                userDTO.IdRole
                );
            return Ok(newUser);


        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var getAll = await _userDomain.GetAllAsync();
            return Ok(getAll);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var getById = await _userDomain.GetByIdAsync(id);
            return Ok(getById);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete
        (
            [FromQuery] int id
        )

        {
            await _userDomain.DeleteUserAsync(id);
            return Ok();
        }

        private UserResponseDTO ConvertDomainToResponse(UserDomain userDomain)
        {
            return new UserResponseDTO()
            {
                FirstName = userDomain.FirstName,
                LastName = userDomain.LastName,
                Login = userDomain.Login,
                Email = userDomain.Email,
                Patronymic = userDomain.Patronymic
            };
        }       
    };
        

    }

