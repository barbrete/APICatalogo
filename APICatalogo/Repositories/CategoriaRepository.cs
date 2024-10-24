using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Pagination;

namespace APICatalogo.Repositories
{
    public class CategoriaRepository : Repository<Categoria>,ICategoriaRepository
    {
        //classe criada para ter a lógica de acesso aos dados
        //tirando a responsabilidade do Controller implementar 2 lógicas (acesso aos dados e negócios)

        public CategoriaRepository(AppDbContext context) : base(context)
        {

        }
        public PagedList<Categoria> GetCategorias(CategoriasParameters categoriasParams)
        {
            var categorias = GetAll().OrderBy(p => p.Id).AsQueryable();
            var categoriasOrdenadas = PagedList<Categoria>.ToPagedList(categorias,
                categoriasParams.PageNumber,
                categoriasParams.PageSize);

            return categoriasOrdenadas;
        }

    }
}
