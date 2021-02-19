using Italika.Core.Entities;
using Italika.Core.Interfaces;
using Italika.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Italika.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ItalikaContext _context;
        public PostRepository(ItalikaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Productos>> GetPosts()
        {
            var posts = await _context.Productos.ToListAsync();
            return posts;
        }

        public async Task<Productos> GetPost(int Id)
        {
            var post = await _context.Productos.FirstOrDefaultAsync(x => x.Id == Id);
            return post;
        }

        public async Task<Productos> FilterBySku(string sku)
        {
            var producto = await _context.Productos.FirstOrDefaultAsync(x => x.Sku == sku);
            return producto;
        }

        public async Task<IEnumerable<Productos>> FilterByModelo(string modelo)
        {
            var productos = await _context.Productos.Where(x => x.Modelo == modelo).ToListAsync();
            return productos;
        }
    }
}
