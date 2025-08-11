using CatalogoProduto.Core.Models;

namespace CatalogoProduto.DTOAutoMapperAlternativo.Repositories.Interfaces;

public interface IProdutoRepository : IRepository<Produto>
{
    IEnumerable<Produto> GetProdutoPorCategoria(int id);
}