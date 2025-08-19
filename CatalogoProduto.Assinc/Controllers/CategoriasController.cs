using CatalogoProduto.Assinc.DTOs;
using CatalogoProduto.Assinc.Pagination;
using CatalogoProduto.Assinc.Repositories.Interfaces;
using CatalogoProduto.Core.Models;
using CatalogoProduto.Assinc.DTOs.Mappgings;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CatalogoProduto.Assinc
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
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> Get()
        {
            var categorias = await _unitOfWork.CategoriaRepository.GetAll();

            if(categorias == null)
                return NotFound("Nenhuma categoria foi encontrada.");

            #region DTO Manual 
            /*
              foreach (var categoria in categorias)
              {
                  var categoriaDto = new CategoriaDTO()
                  {
                      CategoriaId = categoria.CategoriaId,
                      Nome = categoria.Nome,
                      ImagemUrl = categoria.ImagemUrl
                  };
                  categoriasDto.Add(categoriaDto);
              }
              */
            #endregion
            
            var CategoriasDTO = categorias.ToCategoriaDTOList();
            return Ok(CategoriasDTO);
        }

        [HttpGet("pagination")]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> GetPagination([FromQuery] CategoriasParameters categoriasParams)
        {
            var categorias = await _unitOfWork.CategoriaRepository.GetCategorias(categoriasParams);

            return ObterCategorias(categorias);
        }
        
        [HttpGet("filter/nome/pagination")]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> GetCategoriasFiltradas([FromQuery] CategoriasFiltroNome categoriasFiltro)
        {
            var categoriasFiltradas = await _unitOfWork.CategoriaRepository.GetCategoriasFiltroNome(categoriasFiltro);

            return ObterCategorias(categoriasFiltradas);
        }
        
        private ActionResult<IEnumerable<CategoriaDto>> ObterCategorias(PagedList<Categoria> categorias)
        {
            var metadata = new
            {
                categorias.TotalCount,
                categorias.PageSize,
                categorias.CurrentPage,
                categorias.TotalPages,
                categorias.HasNext,
                categorias.HasPrevious
            };
            Response.Headers["X-Pagination"] = JsonConvert.SerializeObject(metadata);
            
            var categoriasDto = categorias.ToCategoriaDTOList();
            return Ok(categoriasDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaDto>> Get(int id)
        {

            var categoria = await _unitOfWork.CategoriaRepository.Get(c => c.CategoriaId == id);
            if (categoria is null)
            {
                return NotFound($"Categoria comm id: {id} não encontrado...");
            }
            var CategoriasDTO = categoria.ToCategoriaDTO();
            return Ok(CategoriasDTO);
        }

        [HttpPost]
        public ActionResult<CategoriaDto> Post(CategoriaDto categoriaDto)
        {
            if(categoriaDto == null)
            {
                return BadRequest("Dados invalidos");
            }
            
            var categoria = categoriaDto.ToCategoria();

            var categoriaCriada = _unitOfWork.CategoriaRepository.Create(categoria);
            _unitOfWork.Commit();

            var novaCategoriaDto =  categoriaCriada.ToCategoriaDTO();
            return Ok(novaCategoriaDto);
        }

        [HttpPut("{id:int}")]
        public ActionResult<CategoriaDto> Put(int id, CategoriaDto categoriaDto)
        {
            if (id != categoriaDto.CategoriaId)
            {
                return BadRequest("Dados invalidos"); // Erro 400 Bad Request
            }
            
            var categoria = categoriaDto.ToCategoria();
            
            var categoriaAtualizada = _unitOfWork.CategoriaRepository.Update(categoria);
            _unitOfWork.Commit();

            var categoriaAtualizadaDto = categoriaAtualizada.ToCategoriaDTO();
            
            return Ok(categoriaAtualizadaDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoriaDto>> Delete(int id)
        {
            var categoria = await _unitOfWork.CategoriaRepository.Get(c => c.CategoriaId == id);
            if (categoria is null)
            {
                return NotFound("Categoria não localizado...");
            }
            var categoriaRemovida = _unitOfWork.CategoriaRepository.Delete(categoria);
            _unitOfWork.Commit();

            var categoriaRemovidaDto = categoriaRemovida.ToCategoriaDTO();
            return Ok(categoriaRemovidaDto);
        }
    }
}