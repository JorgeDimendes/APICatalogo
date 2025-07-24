using CatalogoProduto.Core.Models;

namespace CatalogoProduto.RepositoryUnitOfWork.Repositories.Interfaces;

public interface IProdutoRepository : IRepository<Produto>
{
    IEnumerable<Produto> GetProdutoPorCategoria(int id);
}