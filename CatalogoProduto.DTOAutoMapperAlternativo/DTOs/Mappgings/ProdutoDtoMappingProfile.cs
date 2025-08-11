using AutoMapper;
using CatalogoProduto.Core.Models;

namespace CatalogoProduto.DTOAutoMapperAlternativo.DTOs.Mappgings;

public class ProdutoDtoMappingProfile : Profile
{
    public ProdutoDtoMappingProfile()
    {
        //Produto
        CreateMap<Produto, ProdutoDto>().ReverseMap();
        CreateMap<Produto, ProdutoDTOUpdateRequest>().ReverseMap();
        CreateMap<Produto, ProdutoDTOUpdateResponse>().ReverseMap();
        
        //Categoria
        CreateMap<Categoria, CategoriaDto>().ReverseMap();
    }
}