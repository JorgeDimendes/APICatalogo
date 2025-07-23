using APICatalogo.Repositories.Interfaces;
using CatalogoProduto.Core.Context;
using CatalogoProduto.Core.Models;

namespace APICatalogo.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext context) : base(context)
        {
        }
    }
}