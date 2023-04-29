using System.ComponentModel.DataAnnotations;

namespace ProjectsManagement.Dtos.Role;

public record CreateRoleDto
{
    [Display(Name = "Nome")]
    [Required(ErrorMessage = "O {0} é necessário")]
    [StringLength(60, ErrorMessage = "O {0} deve ter no máximo 60 caracteres")]
    public string Name { get; set; }
    public List<int> Permissions { get; set; }
    public CreateRoleDto()
    {
        // constructor logic here
    }

    // class members here
}
