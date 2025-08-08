using CatalogoProduto.Core.Models;

namespace CatalogoProduto.DTOAutoMapper.DTOs.Mappgings;

public static class ProdutoDtoMappingExtensions
{
    public static ProdutoDto? MapearParaDto(this Produto produto)
    {
        //Entidade -> DTO (Vai enviar algo pro cliente)
        return new ProdutoDto
        {
            ProdutoId = produto.ProdutoId,
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            Preco = produto.Preco,
            ImagemUrl = produto.ImagemUrl,
            Estoque = produto.Estoque,
            DataCadastro = produto.DataCadastro,
            CategoriaId = produto.CategoriaId,
            Categoria = produto.Categoria
        };
    }
    
    //DTO → Entidade ou atualização (Vai receber algo do cliente)
    public static Produto? MapearParaEntidade(this ProdutoDto dto)
    {
        return new Produto
        {
            ProdutoId = dto.ProdutoId,
            Nome = dto.Nome,
            Descricao = dto.Descricao,
            Preco = dto.Preco,
            ImagemUrl = dto.ImagemUrl,
            Estoque = dto.Estoque,
            DataCadastro = dto.DataCadastro,
            CategoriaId = dto.CategoriaId
            // Categoria: geralmente não se mapeia diretamente, só o ID
        };
    }
}