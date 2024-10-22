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
        private readonly IProdutoRepository _produtoRepository;
        private readonly IRepository<Produto> _repository;
        public ProdutosController(IRepository<Produto> repository, IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> GetProdutosCategorias(int id)
        {
            var produtos = _produtoRepository.GetProdutosPorCategoria;
            if (produtos is null)
            {
                return NotFound();
            }
            return Ok(produtos);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _repository.GetAll().ToList();
            if (produtos is null)
            {
                return NotFound();
            }
            return Ok(produtos);
        }

        [HttpGet("{id}", Name="ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produtos = _repository.GetId(c => c.ProdutoId == id);
            if (produtos is null)
            {
                return BadRequest();
            }
            return Ok(produtos);
        }

        [HttpPost]
        public ActionResult Post(Produto produto) //está recebendo um produto para a criação
        {
            if (produto is null)
            {
                return BadRequest();
            }

            var novoProduto = _repository.Create(produto);

            return new CreatedAtRouteResult("ObterProduto",
                new { id = novoProduto.ProdutoId }, produto);
        
        }

        [HttpPut("{id:int}")]//parametro para identificar o id que deve ser alterado
        public ActionResult Put(int id, Produto produto) //envia o id e o body do produto para fazer a atualização
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }
            var produtoAtualizado = _repository.Update(produto);
            return Ok(produtoAtualizado);   
        }

        [HttpDelete("{id:int}")]//parametro para identificar o id que deve ser alterado
        public ActionResult Delete(int id) 
        {
            var produto = _repository.GetId(p => p.ProdutoId == id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado...");
            }
            var produtoDeletado = _repository.Delete(produto);
            return Ok(produtoDeletado);
        }

    }
}
