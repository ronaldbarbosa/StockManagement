using System.ComponentModel.DataAnnotations;

namespace StockManagement.Application.DTOs.Response
{
    public class CreateUserResponse : ResponseBase
    {
        [Display(Name = "Sucesso")]
        public bool Succeded { get; set; }
    }
}
