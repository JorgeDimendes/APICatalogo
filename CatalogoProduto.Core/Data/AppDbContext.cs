using CatalogoProduto.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

//namespace APICatalogo.Context;
namespace CatalogoProduto.Core.Context;
public class AppDbContext : IdentityDbContext
{
    //ctor
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
    }
    public DbSet<Categoria>? Categorias { get; set; }
    public DbSet<Produto>? Produtos { get; set; }
}