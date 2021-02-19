using Italika.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Italika.Core.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Productos>> GetPosts();

        Task<Productos> GetPost(int Id);

        Task<Productos> FilterBySku(string sku);

        Task<IEnumerable<Productos>> FilterByModelo(string modelo);
    }
}
