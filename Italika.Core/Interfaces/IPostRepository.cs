using Italika.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Italika.Core.Entities.ViewModel;

namespace Italika.Core.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<vmProductos>> GetPosts();

        Task<vmProductos> GetPost(int Id);

        Task<vmProductos> FilterBySku(string sku);

        Task<IEnumerable<vmProductos>> FilterByModelo(string modelo);

        Task<bool> InsertProduct(Productos producto);

        Task<bool> sp_Inser_Producto(Productos producto, string connstr);

        Task<bool> EditProduct(Productos producto);

        Task<bool> DeleteProduct(int id);
    }
}
