using CatalogoProduto.Core.Models;

namespace CatalogoProduto.DTOManual.DTOs.Mappgings;

public static class CategoriaDTOMappingExtensions
{
    public static CategoriaDTO? ToCategoriaDTO(this Categoria categoria)
    {
        if (categoria == null)
        {
            return null;
        }

        return new CategoriaDTO
        {
            CategoriaId = categoria.CategoriaId,
            Nome = categoria.Nome,
            ImagemUrl = categoria.ImagemUrl
        };
    }

    public static Categoria? ToCategoria(this CategoriaDTO categoriaDto)
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