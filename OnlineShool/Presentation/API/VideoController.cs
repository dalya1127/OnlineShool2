using Microsoft.AspNetCore.Mvc;

using OnlineShool.Domain;


using OnlineShool.Presentation.API.DTOS.Video;
namespace OnlineShool.Presentation.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoController : Controller
    {
        private readonly IVideoDomain _videoDomain;
        public VideoController(IVideoDomain videoDomain)
        {
            _videoDomain = videoDomain;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VideoCreateDTO videoCreateDTO)
        {
            var newVideo = await _videoDomain.CreateVideoAsync(videoCreateDTO.Name, videoCreateDTO.LinkFile, videoCreateDTO.Description);
            return Ok(newVideo);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] VideoUpdateDTO videoUpdateDTO)
        {
            var updateVideo = await _videoDomain.UpdateVideoAsync(videoUpdateDTO.id, videoUpdateDTO.Name, videoUpdateDTO.LinkFile, videoUpdateDTO.Description);
                return Ok(updateVideo);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var getById = await _videoDomain.GetById(id);
            return Ok(getById);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var getById = await _videoDomain.GetAll();
            return Ok(getById);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _videoDomain.DeleteVideoAsync(id);
            return Ok();
        }
    }
}
