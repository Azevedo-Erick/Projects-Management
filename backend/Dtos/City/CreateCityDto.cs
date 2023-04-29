using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectsManagement.Dtos.City;

public record CreateCityDto
{
    [Display(Name = "Nome")]
    [Required(ErrorMessage = "O {0} é necessário")]
    [StringLength(60, ErrorMessage = "O {0} deve ter no máximo 60 caracteres")]
    public string Name { get; set; }

    [Display(Name = "StateId")]
    [Required(ErrorMessage = "O {0} é necessário")]
    [RegularExpression(@"\d+", ErrorMessage = "O {0} deve ser um número inteiro.")]
    public int StateId { get; set; }
}

