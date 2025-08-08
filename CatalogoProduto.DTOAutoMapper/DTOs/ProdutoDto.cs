using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CatalogoProduto.Core.Models;

namespace CatalogoProduto.DTOAutoMapper.DTOs;

public class ProdutoDto
{
    [Key]
    public int ProdutoId { get; set; }

    [Required(ErrorMessage = "O Nome é obrigatorio")]
    [StringLength(80)]
    //[PrimeiraLetraMaiuscula]
    public string? Nome { get; set; }

    [Required]
    [StringLength(300)]
    public string? Descricao { get; set; }

    [Required]
    [Column(TypeName ="decimal(10,2)")]
    public decimal Preco { get; set; }

    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }
    public float Estoque { get; set; }
    public DateTime DataCadastro { get; set; } = new DateTime();

    //Vincular e propriedade de navegação
    public int CategoriaId { get; set; }

    //[JsonIgnore]
    public Categoria? Categoria { get; set; }
}