using AutoMapper;
using CatalogoProduto.Core.Models;
using CatalogoProduto.DTOMapster.DTOs;
using CatalogoProduto.DTOMapster.Repositories.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoProduto.DTOMapster
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProdutosController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("categoria/{id}")]
        public ActionResult<IEnumerable<ProdutoDto>> GetProdutosCategoria(int id)
        {
            var produtos = _unitOfWork.ProdutoRepository.GetProdutoPorCategoria(id);
            if (produtos is null || !produtos.Any())
            {
                return NotFound("Nenhum produto encontrado com os critérios informados.");
            }

            var produtosDto = _mapper.Map<IEnumerable<ProdutoDto>>(produtos);
            return Ok(produtosDto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProdutoDto>> Get()
        {
            var produtos = _unitOfWork.ProdutoRepository.GetAll();
            if (produtos is null || !produtos.Any())
            {
                return NotFound("Produtos não encontrado");
            }
            var produtosDto = _mapper.Map<IEnumerable<ProdutoDto>>(produtos);
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
            
            var produtoDto = _mapper.Map<ProdutoDto>(produto);
            return Ok(produtoDto);
        }

        [HttpPost]
        public ActionResult<ProdutoDto> Post(ProdutoDto produtoDto)
        {
            if (produtoDto is null)
                return BadRequest("Erro ao cadastrar produto");

            var produto = _mapper.Map<Produto>(produtoDto);
            
            var novoProduto = _unitOfWork.ProdutoRepository.Create(produto);
            _unitOfWork.Commit();
            
            var novoProdutoDto = _mapper.Map<ProdutoDto>(novoProduto);
            return Ok(novoProdutoDto);
        }

        [HttpPatch("{id}/updatePartial")]
        public ActionResult<ProdutoDTOUpdateResponse> Patch(int id, JsonPatchDocument<ProdutoDTOUpdateRequest> patchProdutoDTO)
        {
            if (patchProdutoDTO is null || id <= 0)
            {
                return BadRequest();
            }
            var produto = _unitOfWork.ProdutoRepository.Get(p => p.ProdutoId == id);
            
            if (produto is null) return NotFound();
            
            var produtoUpdateRequest = _mapper.Map<ProdutoDTOUpdateRequest>(produto);
            
            patchProdutoDTO.ApplyTo(produtoUpdateRequest, ModelState);
            
            if (!ModelState.IsValid || !TryValidateModel(produtoUpdateRequest))
                return BadRequest(ModelState);
            
            _mapper.Map(produtoUpdateRequest, produto);
            
            _unitOfWork.ProdutoRepository.Update(produto);
            _unitOfWork.Commit();
            
            var mapeado = _mapper.Map<ProdutoDTOUpdateResponse>(produto);
            return Ok(mapeado);
        }

        [HttpPut("{id:int}")]
        public ActionResult<ProdutoDto> Put(int id, ProdutoDto produtoDto)
        {
            if(id != produtoDto.ProdutoId)
            {
                return BadRequest("Erro ao atualizar produto");
            }
            
            var produto = _mapper.Map<Produto>(produtoDto);
            
            var atualizado = _unitOfWork.ProdutoRepository.Update(produto);
            _unitOfWork.Commit();
            
            var atualizadoDto = _mapper.Map<ProdutoDto>(atualizado);
            
            return Ok(atualizadoDto);
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
            
            var produtoRemovidoDto = _mapper.Map<ProdutoDto>(produtoRemovido);
            return Ok(produtoRemovidoDto);
        }
    }
}