using CatalogoProduto.Core.Context;
using CatalogoProduto.Core.Models;
using CatalogoProduto.DTOAutoMapperAlternativo.Repositories.Interfaces;

namespace CatalogoProduto.DTOAutoMapperAlternativo.Repositories;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{
    public ProdutoRepository(AppDbContext context) : base(context)
    {
    }

    public IEnumerable<Produto> GetProdutoPorCategoria(int id)
    {
        return GetAll().Where(c => c.CategoriaId == id);
    }
}