using CatalogoProduto.Core.Context;
using CatalogoProduto.Core.Models;
using CatalogoProduto.DTOMapster.Pagination;
using CatalogoProduto.DTOMapster.Repositories.Interfaces;

namespace CatalogoProduto.DTOMapster.Repositories;

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

    public PagedList<Produto> GetProdutos(ProdutosParameters produtosParams)
    {
        var produtos = GetAll()
            .OrderBy(p => p.ProdutoId)
            .AsQueryable();
        
        var produtosOrdenado = PagedList<Produto>.ToPagedList(produtos, produtosParams.PageNumber, produtosParams.PageSize);
        
        return produtosOrdenado;
    }

    //Filtro Preco
    public PagedList<Produto> GetProdutosFiltroPreco(ProdutosFiltroPreco produtosFiltroParams)
    {
        var produtos = GetAll().AsQueryable();
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
        var produtosFiltrados = PagedList<Produto>.ToPagedList(produtos, produtosFiltroParams.PageNumber, produtosFiltroParams.PageSize);
        return produtosFiltrados;
    }

    public IEnumerable<Produto> GetProdutoPorCategoria(int id)
    {
        return GetAll().Where(c => c.CategoriaId == id);
    }
}