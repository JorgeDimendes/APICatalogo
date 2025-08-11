using CatalogoProduto.DTOMapster.DTOs.Mappgings;
using CatalogoProduto.DTOMapster.DTOs;
using CatalogoProduto.DTOMapster.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoProduto.DTOMapster
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
        public ActionResult<IEnumerable<CategoriaDto>> Get()
        {
            var categorias = _unitOfWork.CategoriaRepository.GetAll();

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

        [HttpGet("{id}")]
        public ActionResult<CategoriaDto> Get(int id)
        {

            var categoria = _unitOfWork.CategoriaRepository.Get(c => c.CategoriaId == id);
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
        public ActionResult<CategoriaDto> Delete(int id)
        {
            var categoria = _unitOfWork.CategoriaRepository.Get(c => c.CategoriaId == id);
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