using APICatalogo.Repositories.Interfaces;
using CatalogoProduto.Core.Models;
using CatalogoProduto.RepositoryGenerico.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IRepository<Produto> _produtoRepository;
        private readonly IProdutoRepository _pRepository;

        public ProdutosController(IRepository<Produto> produtoRepository, IProdutoRepository pRepository)
        {
            _produtoRepository = produtoRepository;
            _pRepository = pRepository;
        }

        [HttpGet("produtos/{id}")]
        public ActionResult<IEnumerable<Produto>> GetProdutosCategoria(int id)
        {
            var produtos = _pRepository.GetProdutoPorCategoria(id);
            if (produtos is null)
            {
                return NotFound("Nenhum produto encontrado com os critérios informados.");
            }
            return Ok(produtos);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var result = _produtoRepository.GetAll();
            if (result is null)
            {
                return NotFound("Produtos não encontrado");
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _produtoRepository.Get(p => p.ProdutoId == id);

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

            var novoProduto = _produtoRepository.Create(produto);

            return Ok(novoProduto);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if(id != produto.ProdutoId)
            {
                return BadRequest("Erro ao atualizar produto");
            }

            var atualizado = _produtoRepository.Update(produto);
            return Ok(atualizado);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var localiza = _produtoRepository.Get(p => p.ProdutoId == id);
            if (localiza == null)
            {
                return BadRequest($"Falha ao excluir o produto do id = {id}");
            }
            var produtoRemovido = _produtoRepository.Delete(localiza);
            return Ok(produtoRemovido);
        }
    }
}