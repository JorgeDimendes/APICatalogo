using CatalogoProduto.Core.Models;

namespace CatalogoProduto.Assinc.DTOs.Mappgings;

public static class CategoriaDtoMappingExtensions
{
    public static IEnumerable<CategoriaDto> ToCategoriaDTOList(this IEnumerable<Categoria> categorias)
    {
        if (categorias is null || !categorias.Any())
        {
            return new List<CategoriaDto>();
        }
        return categorias.Select(categoria => new CategoriaDto
        {
            CategoriaId = categoria.CategoriaId,
            Nome = categoria.Nome,
            ImagemUrl = categoria.ImagemUrl
        }).ToList();
    }
    
    public static CategoriaDto? ToCategoriaDTO(this Categoria categoria)
    {
        if (categoria == null)
        {
            return null;
        }
        return new CategoriaDto
        {
            CategoriaId = categoria.CategoriaId,
            Nome = categoria.Nome,
            ImagemUrl = categoria.ImagemUrl
        };
    }

    public static Categoria? ToCategoria(this CategoriaDto categoriaDto)
    {
        if (categoriaDto == null) return null;

        return new Categoria
        {
            CategoriaId = categoriaDto.CategoriaId,
            Nome = categoriaDto.Nome,
            ImagemUrl = categoriaDto.ImagemUrl
        };
    }
}