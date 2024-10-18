using APICatalogo.Context;
using APICatalogo.Models;

namespace APICatalogo.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        //classe criada para ter a lógica de acesso aos dados
        //tirando a responsabilidade do Controller implementar 2 lógicas (acesso aos dados e negócios)

        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }



        public IEnumerable<Categoria> GetCategorias()
        {
           return _context.Categorias.ToList();
        }
        public Categoria GetCategoria(int id)
        {
            return _context.Categorias.FirstOrDefault(c => c.Id == id);
        }

        public Categoria Create(Categoria categoria)
        {
            if (categoria == null)
            {
                throw new ArgumentNullException(nameof(categoria));
            }
                _context.Categorias.Add(categoria);
                _context.SaveChanges();

                return categoria;
        }
        public Categoria Update(Categoria categoria)
        {
            if (categoria == null)
            {
                throw new ArgumentNullException(nameof(categoria));
            }
            _context.Entry(categoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return categoria;

        }

        public Categoria Delete(int id)
        {
            var categoria = _context.Categorias.Find(id);
            if (categoria == null)
            {
                throw new ArgumentNullException(nameof(categoria));
            }
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return categoria;
        }

    }
}
