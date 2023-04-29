using System.ComponentModel.DataAnnotations;

namespace ProjectsManagement.Dtos.Country
{
    public record CreateCountryDto
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O {0} é necessário")]
        [StringLength(60, ErrorMessage = "O {0} deve ter no máximo 60 caracteres")]
        public string Name { get; set; }
        public CreateCountryDto()
        {
        }

    }
}