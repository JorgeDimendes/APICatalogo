using APICatalogo.Models;
using APICatalogo.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var result = _produtoRepository.GetProdutos().ToList();
            if(result is null)
            {
                return NotFound("Produtos não encontrado");
            }
            return Ok(result);
        }


        [HttpGet("{id}")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _produtoRepository.GetProdutoId(id);

            if (produto is null)
            {
                return NotFound("Produto não encontrado...");
            }
            return Ok(produto);
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
                return BadRequest("Erro ao cadastrar produto");

            var novoProduto = _produtoRepository.PostProduto(produto);

            return Ok(novoProduto);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if(id != produto.ProdutoId)
            {
                return BadRequest("Erro ao atualizar produto");
            }

            bool atualizado = _produtoRepository.PutProduto(produto);
            if (atualizado)
            {
                return Ok(produto);
            }
            else
            {
                return StatusCode(500, $"Falha ao atualizar o produto do id = {id}");
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            bool deletado = _produtoRepository.DeleteProduto(id);
            if (deletado)
            {
                return Ok($"O produto do id = {id} foi excluido com sucesso.");
            }
            else
            {
                return StatusCode(500, $"Falha ao excluir o produto do id = {id}");
            }
        }
    }
}