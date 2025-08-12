using CatalogoProduto.Core.Models;
using CatalogoProduto.DTOMapster.Pagination;

namespace CatalogoProduto.DTOMapster.Repositories.Interfaces;

public interface IProdutoRepository : IRepository<Produto>
{
    //Paginação
    IEnumerable<Produto> GetProdutos(ProdutosParameters produtosParams);
    
    IEnumerable<Produto> GetProdutoPorCategoria(int id);
}