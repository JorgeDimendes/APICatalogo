using APICatalogo.Models;

//namespace APICatalogo.Repositories.Interfaces;
namespace CatalogoProdutoRepositoryUnico.Interfaces;

public interface ICategoriaRepository
{
    IEnumerable<Categoria> GetCategorias();
    Categoria GetCategoriaId(int id);
    Categoria PostCategoria(Categoria categoria);
    Categoria PutCategoria(Categoria categoria);
    Categoria DeleteCategoria(int id);
}