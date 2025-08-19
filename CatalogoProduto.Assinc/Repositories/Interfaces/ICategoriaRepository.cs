using CatalogoProduto.Assinc.Pagination;
using CatalogoProduto.Core.Models;

namespace CatalogoProduto.Assinc.Repositories.Interfaces
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        //Paginação
        Task<PagedList<Categoria>> GetCategorias(CategoriasParameters categoriasParams);
        
        //Filtro Nome
        Task<PagedList<Categoria>> GetCategoriasFiltroNome(CategoriasFiltroNome categoriasParams);
    }
}