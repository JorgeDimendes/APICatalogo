using System.Linq.Expressions;

namespace CatalogoProduto.Assinc.Repositories.Interfaces;

// Repository generico
public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAll();
    Task<T?> Get(Expression<Func<T, bool>> predicate);
    T Create(T entity);
    T Update(T entity);
    T Delete(T entity);
}