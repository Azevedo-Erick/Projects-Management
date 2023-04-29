using System.ComponentModel.DataAnnotations;

namespace ProjectsManagement.Dtos.Notification;

public record CreateNotificationDto
{
    [Display(Name = "Message")]
    [Required(ErrorMessage = "A {0} é necessário")]
    [StringLength(int.MaxValue, MinimumLength = 10, ErrorMessage = "A {0} deve ter no mínimo 10 caracteres")]
    public string Message { get; set; }
    [Display(Name = "RecipientId")]
    [Required(ErrorMessage = "O {0} é necessário")]
    [RegularExpression(@"\d+", ErrorMessage = "O {0} deve ser um número inteiro.")]
    public int RecipientId { get; set; }
    [Display(Name = "TypeId")]
    [Required(ErrorMessage = "O {0} é necessário")]
    [RegularExpression(@"\d+", ErrorMessage = "O {0} deve ser um número inteiro.")]
    public int TypeId { get; set; }
}