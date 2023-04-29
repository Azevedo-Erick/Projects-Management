using System.ComponentModel.DataAnnotations;

namespace ProjectsManagement.Dtos.ContactType;

public record CreateContactTypeDto
{
    [Display(Name = "Name")]
    [Required(ErrorMessage = "O {0} é necessário")]
    [StringLength(int.MaxValue, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo 10 caracteres")]
    public string Name { get; set; }
    public CreateContactTypeDto()
    {
    }
}
