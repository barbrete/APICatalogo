using APICatalogo.Context;
using APICatalogo.Filters;
using APICatalogo.Models;
using APICatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepository _repository;
        private readonly ILogger<CategoriasController> _logger;

        public CategoriasController(ICategoriaRepository repository, ILogger<CategoriasController> logger) // construtor
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public  ActionResult<IEnumerable<Categoria>> Get()
        {
            var categorias = _repository.GetCategorias();
            return Ok(categorias);
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _repository.GetCategoria(id);
           _logger.LogInformation($"=====================GET api/categorias/id = {id}==================");

            if (categoria == null)
            {
                _logger.LogWarning($"Categoria com id= {id} não encontrada...");
                return NotFound(value: "Categorias não encontrados");
            }
            
            return Ok(categoria);
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            _logger.LogInformation("=====================POST /categorias==================");

            if (categoria == null)
            {
                _logger.LogWarning("Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            var categoriaCriada = _repository.Create(categoria);

            return new CreatedAtRouteResult("ObterCategoria",
                new { id = categoriaCriada.Id }, categoriaCriada);

        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            _logger.LogInformation("=====================PUT Categorias/id==================");

            if (id != categoria.Id)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            _repository.Update(categoria);
            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            _logger.LogInformation("=====================DELETE Categorias/id==================");

            var categoria = _repository.GetCategoria(id);

            if (categoria is null)
            {
                return NotFound("Categoria não encontrada");
            }

            var categoriaDeletada = _repository.Delete(id);

            return Ok(categoriaDeletada);
        }
    }
}
