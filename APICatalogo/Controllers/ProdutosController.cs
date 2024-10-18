using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _repository;
        public ProdutosController(IProdutoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _repository.GetProdutos().ToList();
            if (produtos is null)
            {
                return NotFound();
            }
            return Ok(produtos);
        }

        [HttpGet("{id}", Name="ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produtos = _repository.GetProduto(id);
            if (produtos is null)
            {
                return BadRequest();
            }
            return Ok(produtos);
        }

        [HttpPost]
        public ActionResult Post(Produto produto) //está recebendo um produto para a criação
        {
            var produtos = _repository.Create(produto);

            if (produtos is null)
            {
                return BadRequest();
            }

            

            return new CreatedAtRouteResult("ObterProduto",
                new { id = produto.ProdutoId }, produto);
        
        }

        [HttpPut("{id:int}")]//parametro para identificar o id que deve ser alterado
        public ActionResult Put(int id, Produto produto) //envia o id e o body do produto para fazer a atualização
        {
            var produtoAtualizado = _repository.Update(produto);
            if(id != produtoAtualizado.ProdutoId)
            {
                return BadRequest();
            }

            return Ok(produtoAtualizado);
        }

        [HttpDelete("{id:int}")]//parametro para identificar o id que deve ser alterado
        public ActionResult Delete(int id) 
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);  
            
            if (produto is null)
            {
                return NotFound("Produto não encontrados");
            }
            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);
        }

    }
}
