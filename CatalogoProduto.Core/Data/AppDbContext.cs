using CatalogoProduto.Core.Models;
using Microsoft.EntityFrameworkCore;

//namespace APICatalogo.Context;
namespace CatalogoProduto.Core.Context;
public class AppDbContext: DbContext
{
    //ctor
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
    }

    public DbSet<Categoria>? Categorias { get; set; }
    public DbSet<Produto>? Produtos { get; set; }
}