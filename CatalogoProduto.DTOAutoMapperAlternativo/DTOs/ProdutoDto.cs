using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CatalogoProduto.Core.Models;

namespace CatalogoProduto.DTOAutoMapperAlternativo.DTOs;

public class ProdutoDto
{
    public int ProdutoId { get; set; }

    [Required(ErrorMessage = "O Nome é obrigatorio")]
    [StringLength(80)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(300)]
    public string? Descricao { get; set; }

    [Required]
    public decimal Preco { get; set; }

    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }

    //Vincular e propriedade de navegação
    public int CategoriaId { get; set; }
}