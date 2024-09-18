using System.ComponentModel.DataAnnotations;

namespace StockManagement.Application.DTOs.Request
{
    public class CreateUserRequest
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "A Senha deve conter no mínimo 6 caracteres.")]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Confirmação Senha")]
        [Required(ErrorMessage = "O campo Confirmação Senha é obrigatório.")]
        [Compare(nameof(Password), ErrorMessage = "As senhas não são iguais.")]
        public string PasswordConfirm { get; set; } = string.Empty;
    }
}
