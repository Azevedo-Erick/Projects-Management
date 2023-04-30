using System.ComponentModel.DataAnnotations;

namespace ProjectsManagement.Dtos.Person;

public record CreatePersonDto
{
    [Display(Name = "Nome")]
    [Required(ErrorMessage = "O {0} é necessário")]
    [StringLength(60, ErrorMessage = "O {0} deve ter no máximo 60 caracteres")]
    public string Name { get; set; }

    [Display(Name = "Email")]
    [Required(ErrorMessage = "O {0} é necessário")]
    [EmailAddress(ErrorMessage = "O valor do {0} deve ser um endereço de e-mail válido.")]
    public string Email { get; set; }

    [Display(Name = "Password")]
    [Required(ErrorMessage = "O {0} é necessário")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,16}$", ErrorMessage = "O {0} deve ter entre 8 e 16 caracteres e deve conter pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial.")]
    public string Password { get; set; }

    [Display(Name = "DateOfBirth")]
    [Required(ErrorMessage = "O {0} é necessário")]
    [DataType(DataType.DateTime, ErrorMessage = "O {0} deve ser uma data válida.")]
    public DateTime DateOfBirth { get; set; }

    [Display(Name = "ProfileImage")]
    [Required(ErrorMessage = "O {0} é necessário")]
    [DataType(DataType.Upload, ErrorMessage = "O {0} deve ser enviado.")]
    public string ProfileImage { get; set; }
    public List<int>? Contacts { get; set; }
    public List<int>? Addresses { get; set; }

}