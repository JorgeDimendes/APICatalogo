using CatalogoProduto.Core.Models;
using CatalogoProduto.RepositoryUnitOfWork.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoProduto.RepositoryUnitOfWork
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriasController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            var categorias = _unitOfWork.CategoriaRepository.GetAll();
            return Ok(categorias);
        }


        [HttpGet("{id}")]
        public ActionResult<Categoria> Get(int id)
        {

            var categoria = _unitOfWork.CategoriaRepository.Get(c => c.CategoriaId == id);
            if (categoria is null)
            {
                return NotFound($"Categoria comm id: {id} não encontrado...");
            }
            return Ok(categoria);
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            var categoriaCriada = _unitOfWork.CategoriaRepository.Create(categoria);
            _unitOfWork.Commit();
            return Ok(categoriaCriada);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest("Dados invalidos"); // Erro 400 Bad Request
            }
            _unitOfWork.CategoriaRepository.Update(categoria);
            _unitOfWork.Commit();
            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var categoria = _unitOfWork.CategoriaRepository.Get(c => c.CategoriaId == id);
            if (categoria is null)
            {
                return NotFound("Categoria não localizado...");
            }
            var categoriaRemovida = _unitOfWork.CategoriaRepository.Delete(categoria);
            _unitOfWork.Commit();
            return Ok(categoriaRemovida);
        }
    }
}