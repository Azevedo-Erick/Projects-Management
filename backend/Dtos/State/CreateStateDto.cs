using System.ComponentModel.DataAnnotations;

namespace ProjectsManagement.Dtos.State;

public record CreateStateDto
{
    [Display(Name = "Nome")]
    [Required(ErrorMessage = "O {0} é necessário")]
    [StringLength(60, ErrorMessage = "O {0} deve ter no máximo 60 caracteres")]
    public string Name { get; set; }

    [Display(Name = "CountryId")]
    [Required(ErrorMessage = "O {0} é necessário")]
    [RegularExpression(@"\d+", ErrorMessage = "O {0} deve ser um número inteiro.")]
    public int CountryId { get; set; }
}
