using CatalogoProduto.Core.Models;

namespace CatalogoProduto.DTOAutoMapper.Repositories.Interfaces;

public interface IProdutoRepository : IRepository<Produto>
{
    IEnumerable<Produto> GetProdutoPorCategoria(int id);
}