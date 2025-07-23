using APICatalogo.Models;

namespace APICatalogo.Repositories.Interfaces;

public interface IProdutoRepository
{
    IQueryable<Produto> GetProdutos();
    Produto GetProdutoId(int id);
    Produto PostProduto(Produto produto);
    bool PutProduto(Produto produto);
    bool DeleteProduto(int id);
}