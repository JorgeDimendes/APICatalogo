using CatalogoProduto.Core.Context;
using CatalogoProduto.Core.Models;
using CatalogoProduto.DTOMapster.Pagination;
using CatalogoProduto.DTOMapster.Repositories.Interfaces;

namespace CatalogoProduto.DTOMapster.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext context) : base(context)
        {
        }

        public PagedList<Categoria> GetCategorias(CategoriasParameters categoriasParams)
        {
            var categorias = GetAll()
                .OrderBy(p => p.CategoriaId)
                .AsQueryable();
            
            var categoriasOrdenadas = PagedList<Categoria>.ToPagedList(categorias, 
                categoriasParams.PageNumber, categoriasParams.PageSize);
            return categoriasOrdenadas;
        }
    }
}