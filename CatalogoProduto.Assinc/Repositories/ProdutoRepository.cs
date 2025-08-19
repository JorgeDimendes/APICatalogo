using CatalogoProduto.Assinc.Pagination;
using CatalogoProduto.Assinc.Repositories.Interfaces;
using CatalogoProduto.Core.Context;
using CatalogoProduto.Core.Models;

namespace CatalogoProduto.Assinc.Repositories;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{
    public ProdutoRepository(AppDbContext context) : base(context)
    {
    }

    //Paginação simples
    #region PaginaçãoSimples()
    
    /*public IEnumerable<Produto> GetProdutos(ProdutosParameters produtosParams)
    {
        return GetAll()
            .OrderBy(produto => produto.Nome)
            .Skip((produtosParams.PageNumber -1) *  produtosParams.PageSize)
            .Take(produtosParams.PageSize).ToList();
    }*/
    #endregion

    public async Task<PagedList<Produto>> GetProdutos(ProdutosParameters produtosParams)
    {
        var produtos = await GetAll();
            
        var produtosOrdenados =  produtos.OrderBy(p => p.ProdutoId).AsQueryable();
        
        var resultado = PagedList<Produto>.ToPagedList(produtosOrdenados, produtosParams.PageNumber, produtosParams.PageSize);
        
        return resultado;
    }

    //Filtro Preco
    public async Task<PagedList<Produto>> GetProdutosFiltroPreco(ProdutosFiltroPreco produtosFiltroParams)
    {
        var produtos = await GetAll();
        
        if (produtosFiltroParams.Preco.HasValue && !string.IsNullOrEmpty(produtosFiltroParams.PrecoCriterio))
        {
            if (produtosFiltroParams.PrecoCriterio.Equals("maior", StringComparison.OrdinalIgnoreCase))
            {
                produtos = produtos.Where(p => p.Preco > produtosFiltroParams.Preco.Value).OrderBy(p => p.Preco);
            }
            else if (produtosFiltroParams.PrecoCriterio.Equals("menor", StringComparison.OrdinalIgnoreCase))
            {
                produtos = produtos.Where(p => p.Preco < produtosFiltroParams.Preco.Value).OrderBy(p => p.Preco);
            }
            else if (produtosFiltroParams.PrecoCriterio.Equals("igual", StringComparison.OrdinalIgnoreCase))
            {
                produtos = produtos.Where(p => p.Preco == produtosFiltroParams.Preco.Value).OrderBy(p => p.Preco);
            }
        }
        var produtosFiltrados = PagedList<Produto>.ToPagedList(produtos.AsQueryable(), produtosFiltroParams.PageNumber, produtosFiltroParams.PageSize);
        return produtosFiltrados;
    }

    public async Task<IEnumerable<Produto>> GetProdutoPorCategoria(int id)
    {
        var produtos = await GetAll();
        var produtosOrdenados =  produtos.Where(p => p.CategoriaId == id);
        return produtosOrdenados;
    }
}