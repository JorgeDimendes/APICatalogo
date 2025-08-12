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

    public IEnumerable<Produto> GetProdutos(ProdutosParameters produtosParams)
    {
        return GetAll()
            .OrderBy(produto => produto.Nome)
            .Skip((produtosParams.PageNumber -1) *  produtosParams.PageSize)
            .Take(produtosParams.PageSize).ToList();
    }

    public IEnumerable<Produto> GetProdutoPorCategoria(int id)
    {
        return GetAll().Where(c => c.CategoriaId == id);
    }
}