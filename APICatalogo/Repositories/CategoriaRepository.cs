using APICatalogo.Context;
using APICatalogo.Models;

namespace APICatalogo.Repositories
{
    public class CategoriaRepository : Repository<Categoria>,ICategoriaRepository
    {
        //classe criada para ter a lógica de acesso aos dados
        //tirando a responsabilidade do Controller implementar 2 lógicas (acesso aos dados e negócios)

        public CategoriaRepository(AppDbContext context) : base(context)
        {

        }

    }
}
