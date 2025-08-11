using CatalogoProduto.Core.Models;

namespace CatalogoProduto.DTOMapster.Repositories.Interfaces;

public interface IProdutoRepository : IRepository<Produto>
{
    IEnumerable<Produto> GetProdutoPorCategoria(int id);
}