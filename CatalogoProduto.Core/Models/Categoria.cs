using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

//namespace APICatalogo.Models;
namespace CatalogoProduto.Core.Models;

[Table("Categorias")]
public class Categoria
{
    //Inicializado a propriedade Produto
    public Categoria()
    {
        Produtos = new Collection<Produto>();
    }

    [Key]
    public int CategoriaId { get; set; }

    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }

    //Propriedade de navegação para produtos
    [JsonIgnore]
    public ICollection<Produto>? Produtos { get; set; }
}