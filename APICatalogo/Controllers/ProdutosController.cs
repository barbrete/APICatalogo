using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get() // ActionResult == Executa a operação de resultado do método de ação de forma assíncrona.
        {
            var produtos = _context.Produtos.ToList();

            if (produtos is null)
            {
                return NotFound("Produtos não encontrados");
            }
            return produtos;

        }

        [HttpGet("{id:int}", Name="ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id); //está indo na tabela produtos e vai pegar o primeiro
                                                                                    //elemento que cumpra a regra definida entre parenteses,
                                                                                    //onde o id do produto tem que ser igual a do id enviado
            if(produto is null)
            {
                return NotFound(value: "Produtos não encontrados");
            }
            return produto;
        }

        [HttpPost]
        public ActionResult Post(Produto produto) //está recebendo um produto para a criação
        {
            if (produto is null)
            {
                return BadRequest();
            }

            _context.Produtos.Add(produto); //ele adiciona o novo produto digitado no body do request
            _context.SaveChanges(); //e persiste as alterações

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
            //ele aciona essa rota, para enviar o novo produto para
            //a rota get. Para que assim, se a rota get for
            //chamada denovo ela mostre o produto atualizado


        }

        [HttpPut("{id:int}")]//parametro para identificar o id que deve ser alterado
        public ActionResult Put(int id, Produto produto) //envia o id e o body do produto para fazer a atualização
        {
            if(id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
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
