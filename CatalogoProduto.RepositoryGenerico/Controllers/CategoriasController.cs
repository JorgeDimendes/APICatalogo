using APICatalogo.Repositories.Interfaces;
using CatalogoProduto.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly IRepository<Categoria> _repository;

        public CategoriasController(IRepository<Categoria> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            var categorias = _repository.GetAll();
            return Ok(categorias);
        }


        [HttpGet("{id}")]
        public ActionResult<Categoria> Get(int id)
        {

            var categoria = _repository.Get(c => c.CategoriaId == id);
            if (categoria is null)
            {
                return NotFound($"Categoria comm id: {id} não encontrado...");
            }
            return Ok(categoria);
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            var categoriaCriada = _repository.Create(categoria);
            return Ok(categoriaCriada);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest("Dados invalidos"); // Erro 400 Bad Request
            }
            _repository.Update(categoria);
            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var categoria = _repository.Get(c => c.CategoriaId == id);
            if (categoria is null)
            {
                return NotFound("Categoria não localizado...");
            }
            var categoriaRemovida = _repository.Delete(categoria);
            return Ok(categoriaRemovida);
        }
    }
}