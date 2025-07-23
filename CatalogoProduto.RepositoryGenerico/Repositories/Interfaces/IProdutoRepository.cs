using APICatalogo.Models;
using APICatalogo.Repositories.Interfaces;

//namespace APICatalogo.Repositories.Interfaces;
namespace CatalogoProduto.RepositoryGenerico.Interfaces;

public interface IProdutoRepository : IRepository<Produto>
{
    IEnumerable<Produto> GetProdutoPorCategoria(int id);
}