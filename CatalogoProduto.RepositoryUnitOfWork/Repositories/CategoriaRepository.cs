using CatalogoProduto.Core.Context;
using CatalogoProduto.Core.Models;
using CatalogoProduto.RepositoryUnitOfWork.Repositories.Interfaces;

namespace CatalogoProduto.RepositoryUnitOfWork.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext context) : base(context)
        {
        }
    }
}