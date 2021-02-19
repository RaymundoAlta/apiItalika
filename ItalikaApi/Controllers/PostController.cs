using Italika.Core.Interfaces;
using Italika.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ItalikaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        public  PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postRepository.GetPosts();
            return Ok(posts);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPost(int Id)
        {
            var post = await _postRepository.GetPost(Id);
            return Ok(post);

        }

       


    }
}
