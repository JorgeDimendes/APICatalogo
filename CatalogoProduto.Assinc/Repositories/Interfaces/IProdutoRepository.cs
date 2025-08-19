using CatalogoProduto.Assinc.Pagination;
using CatalogoProduto.Core.Models;

namespace CatalogoProduto.Assinc.Repositories.Interfaces;

public interface IProdutoRepository : IRepository<Produto>
{
    //Paginação simples
    //IEnumerable<Produto> GetProdutos(ProdutosParameters produtosParams);
    
    //Paginação avançada
    Task<PagedList<Produto>> GetProdutos(ProdutosParameters produtosParams);
    
    //Filtro Produtos
    Task<PagedList<Produto>> GetProdutosFiltroPreco(ProdutosFiltroPreco produtosFiltroParams);
    
    Task<IEnumerable<Produto>> GetProdutoPorCategoria(int id);
}