using CatalogoProduto.Core.Models;
using CatalogoProduto.RepositoryUnitOfWork.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoProduto.RepositoryUnitOfWork
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProdutosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("categoria/{id}")]
        public ActionResult<IEnumerable<Produto>> GetProdutosCategoria(int id)
        {
            var produtos = _unitOfWork.ProdutoRepository.GetProdutoPorCategoria(id);
            if (produtos is null)
            {
                return NotFound("Nenhum produto encontrado com os critérios informados.");
            }
            return Ok(produtos);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var result = _unitOfWork.ProdutoRepository.GetAll();
            if (result is null)
            {
                return NotFound("Produtos não encontrado");
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _unitOfWork.ProdutoRepository.Get(p => p.ProdutoId == id);

            if (produto is null)
            {
                return NotFound($"Produto com id: {id} não encontrado...");
            }
            return Ok(produto);
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
                return BadRequest("Erro ao cadastrar produto");

            var novoProduto = _unitOfWork.ProdutoRepository.Create(produto);
            _unitOfWork.Commit();
            return Ok(novoProduto);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if(id != produto.ProdutoId)
            {
                return BadRequest("Erro ao atualizar produto");
            }

            var atualizado = _unitOfWork.ProdutoRepository.Update(produto);
            _unitOfWork.Commit();
            return Ok(atualizado);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var localiza = _unitOfWork.ProdutoRepository.Get(p => p.ProdutoId == id);
            if (localiza == null)
            {
                return BadRequest($"Falha ao excluir o produto do id = {id}");
            }
            var produtoRemovido = _unitOfWork.ProdutoRepository.Delete(localiza);
            _unitOfWork.Commit();
            return Ok(produtoRemovido);
        }
    }
}