using APICatalogo.Repositories.Interfaces;
using CatalogoProduto.Core.Models;

namespace CatalogoProduto.RepositoryGenerico.Repositories.Interfaces;

public interface IProdutoRepository : IRepository<Produto>
{
    IEnumerable<Produto> GetProdutoPorCategoria(int id);
}