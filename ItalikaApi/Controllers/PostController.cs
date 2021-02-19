using Italika.Core.Entities;
using Italika.Core.Interfaces;
using Italika.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace ItalikaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IConfiguration config;
        private string connstr;
       
        private readonly IPostRepository _postRepository;
        public  PostController(IPostRepository postRepository, IConfiguration _configuration)
        {
            _postRepository = postRepository;
            config = _configuration;
            connstr = string.IsNullOrEmpty(config.GetConnectionString("Italika")) ? config.GetConnectionString("Italika") : "Server=Ray; Database=Italika; Integrated Security= True";
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

        [HttpPost("Insert")]
        public async Task<IActionResult> InsertProduct(Productos producto) 
        {
            var response = await _postRepository.InsertProduct(producto);
            return Ok(response);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateProduct(Productos producto)
        {
            var response = await _postRepository.EditProduct(producto);
            return Ok(response);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteProduct(Productos productos)
        {
            var response = false;
            if (productos.Id > 0)
            {
                response = await _postRepository.DeleteProduct(productos.Id);
            }
            
            return Ok(response);
        }

        [HttpPost("SPInsert")]
        public async Task<IActionResult> SPInsertProduct(Productos producto)
        {
            var response = await _postRepository.sp_Inser_Producto(producto, connstr);
            return Ok(response);
        }

    }
}
