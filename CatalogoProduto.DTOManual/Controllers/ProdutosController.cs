using CatalogoProduto.Core.Models;
using CatalogoProduto.DTOManual.DTOs;
using CatalogoProduto.DTOManual.DTOs.Mappgings;
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
        public ActionResult<IEnumerable<ProdutoDto>> GetProdutosCategoria(int id)
        {
            var produtos = _unitOfWork.ProdutoRepository.GetProdutoPorCategoria(id);
            if (produtos is null || !produtos.Any())
            {
                return NotFound("Nenhum produto encontrado com os critérios informados.");
            }

            var produtoDto = produtos.Select(p => p.MapearParaDto());
            return Ok(produtoDto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProdutoDto>> Get()
        {
            var produtos = _unitOfWork.ProdutoRepository.GetAll();
            if (produtos is null || !produtos.Any())
            {
                return NotFound("Produtos não encontrado");
            }
            var produtosDto = produtos
                .Select(p => p.MapearParaDto())
                .ToList();
            return Ok(produtosDto);
        }

        [HttpGet("{id}")]
        public ActionResult<ProdutoDto> Get(int id)
        {
            var produto = _unitOfWork.ProdutoRepository.Get(p => p.ProdutoId == id);

            if (produto is null)
            {
                return NotFound($"Produto com id: {id} não encontrado...");
            }
            var produtoDto = produto.MapearParaDto();
            return Ok(produtoDto);
        }

        [HttpPost]
        public ActionResult Post(ProdutoDto produto)
        {
            if (produto is null)
                return BadRequest("Erro ao cadastrar produto");

            var produtoDto = produto.MapearParaEntidade();
            var novoProduto = _unitOfWork.ProdutoRepository.Create(produtoDto);
            _unitOfWork.Commit();
            return Ok(novoProduto);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, ProdutoDto produto)
        {
            if(id != produto.ProdutoId)
            {
                return BadRequest("Erro ao atualizar produto");
            }
            
            var produtoDto = produto.MapearParaEntidade();
            
            _unitOfWork.Commit();
            var atualizado = _unitOfWork.ProdutoRepository.Update(produtoDto);
            return Ok(atualizado);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<ProdutoDto> Delete(int id)
        {
            var localiza = _unitOfWork.ProdutoRepository.Get(p => p.ProdutoId == id);
            if (localiza == null)
            {
                return BadRequest($"Falha ao excluir o produto do id = {id}");
            }
            
            var produtoRemovido = _unitOfWork.ProdutoRepository.Delete(localiza);
            _unitOfWork.Commit();
            
            var produtoRemovidoDto = produtoRemovido.MapearParaDto();
            return Ok(produtoRemovidoDto);
        }
    }
}