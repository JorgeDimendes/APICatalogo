namespace CatalogoProduto.DTOMapster.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        //IRepository<Produto> ProdutoRepository { get; }
        //IRepository<Categoria> CategoriaRepository { get; }

        //Ou
        IProdutoRepository ProdutoRepository { get; }
        ICategoriaRepository CategoriaRepository { get; }
        void Commit();
    }
}