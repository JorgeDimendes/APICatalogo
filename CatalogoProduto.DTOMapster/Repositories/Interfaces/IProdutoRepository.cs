using CatalogoProduto.Core.Models;
using CatalogoProduto.DTOMapster.Pagination;

namespace CatalogoProduto.DTOMapster.Repositories.Interfaces;

public interface IProdutoRepository : IRepository<Produto>
{
    //Paginação simples
    //IEnumerable<Produto> GetProdutos(ProdutosParameters produtosParams);
    
    //Paginação avançada
    PagedList<Produto> GetProdutos(ProdutosParameters produtosParams);
    
    IEnumerable<Produto> GetProdutoPorCategoria(int id);
}