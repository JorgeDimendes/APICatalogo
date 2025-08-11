using CatalogoProduto.Core.Context;
using CatalogoProduto.DTOMapster.Repositories.Interfaces;

namespace CatalogoProduto.DTOMapster.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IProdutoRepository _produtoRepo;
        private ICategoriaRepository _categoriaRepo;

        public AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IProdutoRepository ProdutoRepository
        {
            get
            {
                //return _produtoRepo = _produtoRepo ?? new ProdutoRepository(_context);
                //ou
                if (_produtoRepo == null)
                {
                    _produtoRepo = new ProdutoRepository(_context);
                }
                return _produtoRepo;
            }
        }
        public ICategoriaRepository CategoriaRepository
        {
            get
            {
                return _categoriaRepo = _categoriaRepo ?? new CategoriaRepository(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}