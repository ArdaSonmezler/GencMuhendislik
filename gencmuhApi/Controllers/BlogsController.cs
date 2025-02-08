using gencmuhApi.Abstract;
using gencmuhApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace gencmuhApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpPost]
        public async Task<IActionResult> AddBlog([FromBody] Blog blog)
        {
            if (blog == null)
                return BadRequest("Geçersiz veri");
            blog.CreatedDate = DateTime.Now;
            await _blogService.AddAsync(blog);
            return CreatedAtAction(nameof(GetById), new { id = blog.Id }, blog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Blog blog)
        {
            if (blog == null || id != blog.Id)
                return BadRequest("Veri uyuşmuyor");
            blog.UpdatedDate = DateTime.Now;
            await _blogService.UpdateAsync(blog);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var blog = await _blogService.GetByIdAsync(id); // Blog’u bul
            if (blog is null)
                return NotFound(new { message = "Blog bulunamadı" });

            await _blogService.DeleteAsync(blog);
            return NoContent();                                  
        }

        [HttpGet]
        public async Task<IActionResult> ListAll()
        {
            var careers = await _blogService.AllListAsync();
            return Ok(careers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            if (blog == null)
                return NotFound("Kayıt bulunamadı");

            return Ok(blog);
        }
    }
}