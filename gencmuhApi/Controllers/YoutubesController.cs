using System.Net;
using gencmuhApi.Abstract;
using gencmuhApi.ExceptionHandler;
using gencmuhApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace gencmuhApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    public class YoutubesController : ControllerBase
    {
        private readonly IYoutubeService _youtubeService;

        public YoutubesController(IYoutubeService youtubeService)
        {
            _youtubeService = youtubeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddYoutubeAsync([FromBody]Youtube youtube){
            if(youtube is null)
                return BadRequest("Youtube video bilgileri boş olamaz!");
            
            var youtubeVideoId = await _youtubeService.AddAsync(youtube);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id){
            try
            {
                var youtubeVideo = _youtubeService.GetById(id);
                return Ok(youtubeVideo);
            }
            catch(NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Sunucu hatası.", error = ex.Message });
            }
        }
    }
}