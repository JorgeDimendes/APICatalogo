using System.ComponentModel.DataAnnotations;

namespace CatalogoProduto.DTOAutoMapperAlternativo.DTOs;

public class ProdutoDTOUpdateRequest : IValidatableObject
{
    [Range(1, 9999, ErrorMessage = "Estoque deve ter entre 1 e 9999.")]
    public float Estoque { get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.Now;
    
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (DataCadastro <= DateTime.Now)
        {
            yield return new ValidationResult("A data deve ser maior que a data atual",
            new[] { nameof(this.DataCadastro) });
        }
    }
}