using Italika.Core.Entities;
using Italika.Core.Entities.ViewModel;
using Italika.Core.Interfaces;
using Italika.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

        public async Task<IEnumerable<vmProductos>> GetPosts()
        {
            var posts = await _context.Productos.ToListAsync();
            var list = new List<vmProductos>();

            foreach (var producto in posts)
            {
                var obj = new vmProductos();
                obj.Id = producto.Id;
                obj.Modelo = producto.Modelo;
                obj.Fert = producto.Fert;
                obj.Sku = producto.Sku;
                obj.Tipo = producto.Tipo;
                obj.NumeroSerie = producto.NumeroSerie;
                obj.Fechar = producto.Fechar.ToString("yyyy-MM-dd");

                list.Add(obj);
            }

            return list;
        }

        public async Task<vmProductos> GetPost(int Id)
        {
            var producto = await _context.Productos.FirstOrDefaultAsync(x => x.Id == Id);
            var obj = new vmProductos();

            obj.Id = producto.Id;
            obj.Modelo = producto.Modelo;
            obj.Fert = producto.Fert;
            obj.Sku = producto.Sku;
            obj.Tipo = producto.Tipo;
            obj.NumeroSerie = producto.NumeroSerie;
            obj.Fechar = producto.Fechar.ToString("yyyy-MM-dd");            

            return obj;
        }

        public async Task<vmProductos> FilterBySku(string sku)
        {
            var producto = await _context.Productos.FirstOrDefaultAsync(x => x.Sku == sku);
            var obj = new vmProductos();

            obj.Id = producto.Id;
            obj.Modelo = producto.Modelo;
            obj.Fert = producto.Fert;
            obj.Sku = producto.Sku;
            obj.Tipo = producto.Tipo;
            obj.NumeroSerie = producto.NumeroSerie;
            obj.Fechar = producto.Fechar.ToString("yyyy-MM-dd");

            return obj;
        }

        public async Task<IEnumerable<vmProductos>> FilterByModelo(string modelo)
        {
            var productos = await _context.Productos.Where(x => x.Modelo == modelo).ToListAsync();
            var list = new List<vmProductos>();

            foreach (var producto in productos)
            {
                var obj = new vmProductos();
                obj.Id = producto.Id;
                obj.Modelo = producto.Modelo;
                obj.Fert = producto.Fert;
                obj.Sku = producto.Sku;
                obj.Tipo = producto.Tipo;
                obj.NumeroSerie = producto.NumeroSerie;
                obj.Fechar = producto.Fechar.ToString("yyyy-MM-dd");

                list.Add(obj);
            }

            return list;           
        }

        public async Task<bool> InsertProduct(Productos producto)
        {
            bool response = false;
            try
            {
                await _context.Productos.AddAsync(producto);
                await _context.SaveChangesAsync();
                response = true;
            }
            catch (Exception ex)
            {

            }
            
            return response;
        }

        public async Task<bool> EditProduct(Productos producto)
        {
            bool response = false;
            try
            {
                var obj = _context.Productos.Find(producto.Id);
                obj.Modelo = producto.Modelo;
                obj.Fert = producto.Fert;
                obj.Sku = producto.Sku;
                obj.Tipo = producto.Tipo;
                obj.NumeroSerie = producto.NumeroSerie;
                obj.Fechar = producto.Fechar;

                _context.Update(obj);
                await _context.SaveChangesAsync();

                response = true;
            }
            catch (Exception ex)
            {

            }

            return response;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            bool response = false;
            try
            {
                var obj = _context.Productos.Find(id);
                _context.Productos.Remove(obj);
                await _context.SaveChangesAsync();

                response = true;
            }
            catch (Exception ex)
            {

            }

            return response;
        }

        public async Task<bool> sp_Inser_Producto(Productos producto, string connectionStr) 
        {
            bool response = false;
            SqlConnection conn = null;            

            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = connectionStr;
                conn.Open();

                var cmd = new SqlCommand();
                cmd.CommandText = "sp_Insert_Productos";
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@sku",producto.Sku));
                cmd.Parameters.Add(new SqlParameter("@fert", producto.Fert));
                cmd.Parameters.Add(new SqlParameter("@tipo", producto.Tipo));
                cmd.Parameters.Add(new SqlParameter("@modelo", producto.Modelo));
                cmd.Parameters.Add(new SqlParameter("@numeroserie", producto.NumeroSerie));
                cmd.Parameters.Add(new SqlParameter("@fechar", producto.Fechar));
                await cmd.ExecuteNonQueryAsync();

                response = true;
            }
            catch (Exception ex)
            {   
            }
            finally
            {
                if (conn!=null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return response;
        }
    }
}
