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

        [HttpGet("FilterBySku")]
        public async Task<IActionResult> FilterBySku(string sku) 
        {
            var producto = await _postRepository.FilterBySku(sku);
            return Ok(producto);

        }

        [HttpGet("FilterByModelo")]
        public async Task<IActionResult> FilterByModelo(string modelo)
        {
            var productos = await _postRepository.FilterByModelo(modelo);
            return Ok(productos);
        }
    }
}
