namespace APICatalogo.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        //Ou para Repository Genericos
        //IRepository<Produto> ProdutoRepository { get; }
        //IRepository<Categoria> CategoriaRepository { get; }


        IProdutoRepository ProdutoRepository { get; }
        ICategoriaRepository CategoriaRepository { get; }

        void Commit();
    }
}