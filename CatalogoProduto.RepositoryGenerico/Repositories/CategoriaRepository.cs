using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Repositories;
using APICatalogo.Repositories.Interfaces;
using CatalogoProduto.RepositoryGenerico.Interfaces;

//namespace APICatalogo.Repositories
namespace CatalogoProduto.RepositoryGenerico
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext context) : base(context)
        {
        }
    }
}