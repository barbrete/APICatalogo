using APICatalogo.Models;
using APICatalogo.Pagination;
using MySqlX.XDevAPI.CRUD;

namespace APICatalogo.Repositories
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        PagedList<Categoria> GetCategorias(CategoriasParameters categoriasParams);
    }
}
