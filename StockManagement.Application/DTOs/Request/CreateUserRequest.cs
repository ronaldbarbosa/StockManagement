using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StockManagement.Application.DTOs.Request
{
    public class CreateUserRequest
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Senha")]
        [JsonPropertyName("senha")]
        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "A Senha deve conter no mínimo 6 caracteres.")]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Confirmação Senha")]
        [JsonPropertyName("confirmacaoSenha")]
        [Required(ErrorMessage = "O campo Confirmação Senha é obrigatório.")]
        [Compare(nameof(Password), ErrorMessage = "Confirmação de Senha inválida.")]
        public string PasswordConfirm { get; set; } = string.Empty;
    }
}
