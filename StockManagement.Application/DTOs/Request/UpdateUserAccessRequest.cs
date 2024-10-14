using System.ComponentModel.DataAnnotations;

namespace StockManagement.Application.DTOs.Request
{
    public class UpdateUserAccessRequest
    {
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string? NewEmail { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "A Senha deve conter no mínimo 6 caracteres.")]
        public string? NewPassword { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "A Senha deve conter no mínimo 6 caracteres.")]
        public string? OldPassword { get; set; }
    }
}
