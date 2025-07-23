using APICatalogo.Models;

namespace APICatalogo.Repositories.Interfaces;

public interface IProdutoRepository : IRepository<Produto>
{
    #region Repositorio Normal
    /*
    IQueryable<Produto> GetProdutos();
    Produto GetProduto(int id);
    Produto Create(Produto produto);
    bool Update(Produto produto);
    bool Delete(int id);
    */
    #endregion

    IEnumerable<Produto> GetProdutoPorCategoria(int id);
}