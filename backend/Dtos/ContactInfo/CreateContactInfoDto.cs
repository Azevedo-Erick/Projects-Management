using System.ComponentModel.DataAnnotations;

namespace ProjectsManagement.Dtos.ContactInfo;

public record CreateContactInfoDto
{

    [Display(Name = "Value")]
    [Required(ErrorMessage = "O {0} é necessário")]
    [StringLength(int.MaxValue, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo 10 caracteres")]
    public string Value { get; set; }

    [Display(Name = "ContactTypeId")]
    [Required(ErrorMessage = "O {0} é necessário")]
    [RegularExpression(@"\d+", ErrorMessage = "O {0} deve ser um número inteiro.")]
    public int ContactTypeId { get; set; }
    public CreateContactInfoDto()
    {
    }
}
