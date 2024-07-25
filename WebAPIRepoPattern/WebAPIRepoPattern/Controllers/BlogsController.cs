using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIRepoPattern.Repos;

namespace WebAPIRepoPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlog _blogRepo;
        public BlogsController(IBlog blogRepo)
        {
                _blogRepo = blogRepo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_blogRepo.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var blog=_blogRepo.GetById(id);
            if(blog!=null)
            {
                return Ok(blog);
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var blog = _blogRepo.Delete(id);
            if (blog ==0)
            {
                return  NotFound();
            }
            return NoContent();
        }
    }
}
