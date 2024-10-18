using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using MySqlX.XDevAPI.CRUD;

namespace APICatalogo.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        //criando a injeção de dependência 
        public ProdutoRepository(AppDbContext contexto)
        {
            _context = contexto;
        }

        public IQueryable<Produto> GetProdutos()
        {
            return _context.Produtos;
        }

        public Produto GetProduto(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

            if (produto == null)
            {
                throw new InvalidOperationException(nameof(ProdutoRepository));
            }

            return produto;
        }

        public Produto Create(Produto produto)
        {
            if (produto == null)
            {
                throw new InvalidOperationException(nameof(ProdutoRepository));
            }
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return produto;
        }
        public bool Update(Produto produto)
        {
            if (produto == null)
            {
                throw new ArgumentNullException(nameof(ProdutoRepository));
            }
            if(_context.Produtos.Any(p=>p.ProdutoId == produto.ProdutoId))
            {
                _context.Produtos.Update(produto);
                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            var produtos = _context.Produtos.Find(id);

            if (produtos is not null)
            { 
                _context.Produtos.Remove(produtos);
                _context.SaveChanges();
                return true;               
            }
            return false;
        }
    }
}
