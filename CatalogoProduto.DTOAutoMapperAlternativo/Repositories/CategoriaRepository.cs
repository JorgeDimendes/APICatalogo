using CatalogoProduto.Core.Context;
using CatalogoProduto.Core.Models;
using CatalogoProduto.DTOAutoMapperAlternativo.Repositories.Interfaces;

namespace CatalogoProduto.DTOAutoMapperAlternativo.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext context) : base(context)
        {
        }
    }
}