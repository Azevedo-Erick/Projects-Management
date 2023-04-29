using System.ComponentModel.DataAnnotations;
using ProjectsManagement.validators;

namespace ProjectsManagement.Dtos.Tag;

public record CreateTagDto
{
    [Display(Name = "Nome")]
    [Required(ErrorMessage = "O {0} é necessário")]
    [StringLength(60, ErrorMessage = "O {0} deve ter no máximo 60 caracteres")]
    public string Title { get; set; }

    [Display(Name = "HexColor")]
    [Required(ErrorMessage = "O {0} é necessário")]
    [Hexadecimal(ErrorMessage = "O {0} deve ser um número hexadecimal.")]
    public string HexColor { get; set; }
    public CreateTagDto()
    {
        // constructor logic here
    }

    // class members here
}
