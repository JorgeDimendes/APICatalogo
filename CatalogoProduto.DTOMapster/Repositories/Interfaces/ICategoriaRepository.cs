using CatalogoProduto.Core.Models;
using CatalogoProduto.DTOMapster.Pagination;

namespace CatalogoProduto.DTOMapster.Repositories.Interfaces
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        //Paginação
        PagedList<Categoria> GetCategorias(CategoriasParameters categoriasParams);
    }
}