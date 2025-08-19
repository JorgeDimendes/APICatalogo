using CatalogoProduto.Assinc.Pagination;
using CatalogoProduto.Assinc.Repositories.Interfaces;
using CatalogoProduto.Core.Context;
using CatalogoProduto.Core.Models;

namespace CatalogoProduto.Assinc.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PagedList<Categoria>> GetCategorias(CategoriasParameters categoriasParams)
        {
            var categorias = await GetAll();
                
            var categoriasOrdenadas = categorias.OrderBy(p => p.CategoriaId)
                .AsQueryable();
            
            var resultado = PagedList<Categoria>.ToPagedList(categoriasOrdenadas, 
                categoriasParams.PageNumber, categoriasParams.PageSize);
            return resultado;
        }

        //Filtro Nome
        public async Task<PagedList<Categoria>> GetCategoriasFiltroNome(CategoriasFiltroNome categoriasParams)
        {
            var categorias = await GetAll();
            
            if (!string.IsNullOrEmpty(categoriasParams.Nome))
            {
                categorias = categorias.Where(c => c.Nome.Contains(categoriasParams.Nome));
            }

            var categoriasFiltradas = PagedList<Categoria>.ToPagedList(
                categorias.AsQueryable(),
                categoriasParams.PageNumber,
                categoriasParams.PageSize
            );

            return categoriasFiltradas;
        }
    }
}