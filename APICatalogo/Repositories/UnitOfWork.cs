using APICatalogo.Context;
using Org.BouncyCastle.Asn1.Mozilla;

namespace APICatalogo.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProdutoRepository _produtoRepo;

        public ICategoriaRepository? _categoriaRepo;
        public AppDbContext? _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IProdutoRepository ProdutoRepository
        {
            get
            {
                return _produtoRepo = _produtoRepo ?? new ProdutoRepository(_context); //?? é o operador de coalescência nula
            }
        }
        public ICategoriaRepository CategoriaRepository
        {
            get
            {
                return _categoriaRepo = _categoriaRepo ?? new CategoriaRepository(_context); //?? é o operador de coalescência nula
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
